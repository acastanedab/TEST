using System;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Report;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Reports
{
    /// <summary>
    /// Controladora Ver informe de control
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140716 <br />
    /// Modificación: 
    /// </remarks>
    public partial class ReportViewControl : System.Web.Mvc.ViewUserControl
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ReportViewControl()
        {
        }

        /// <summary>
        /// Método Página Entera
        /// </summary>
        /// <param name="sender">Remitente</param>
        /// <param name="e">Evento</param>
        protected void Page_Init(object sender, EventArgs e)
        {
            Context.Handler = Page;
        }

        /// <summary>
        /// Página de carga
        /// </summary>
        /// <param name="sender">Remitente</param>
        /// <param name="e">Evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Model != null && Model is ReportModel && !IsPostBack)
                {
                    var yanbalSession = SessionContext.GetYanbalSession();
                    var reportingSessionUrl = yanbalSession != null ? yanbalSession.ReportingUrl : "";

                    var model = (ReportModel)Model;
                    MyCredencial myCredencial = new Reports.MyCredencial();
                    ReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                    ReportViewer.ShowParameterPrompts = false;
                    ReportViewer.ServerReport.ReportServerCredentials = myCredencial;
                    ReportViewer.ServerReport.ReportPath = model.PathReport;
                    ReportViewer.ServerReport.ReportServerUrl = new Uri(reportingSessionUrl);
                    ReportViewer.ServerReport.SetParameters(model.Parameters);
                    ReportViewer.ServerReport.Refresh();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }

    /// <summary>
    /// Controladora Credencial
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140716 <br />
    /// Modificación: 
    /// </remarks>
    [Serializable]
    public class MyCredencial : Microsoft.Reporting.WebForms.IReportServerCredentials
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public MyCredencial()
        {
        }

        /// <summary>
        /// Permite obtener credenciales para formularios
        /// </summary>
        /// <param name="authCookie">Cookies de autenticación</param>
        /// <param name="userName">Nombre de usuario</param>
        /// <param name="password">Contraseña</param>
        /// <param name="authority">Autoridad</param>
        /// <returns>Credenciales</returns>
        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string userName, out string password, out string authority)
        {
            authCookie = null;
            userName = null;
            password = null;
            authority = null;

            return false;
        }

        /// <summary>
        /// Suplantación de Usuario
        /// </summary>
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        /// <summary>
        /// Credenciales de red
        /// </summary>
        public System.Net.ICredentials NetworkCredentials
        {
            get {
                string reportingUser = "", reportingPassword = "", reportingDomain = "";
                var yanbalSession = SessionContext.GetYanbalSession();
                if (yanbalSession != null)
                {
                    reportingUser = yanbalSession.ReportingUser;
                    reportingPassword = yanbalSession.ReportingPassword;
                    reportingDomain = yanbalSession.ReportingDomain;
                }
                return new System.Net.NetworkCredential(reportingUser, reportingPassword, reportingDomain); 
            }
        }
    }
}