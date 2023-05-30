using System;
using System.Collections.Generic;
using System.Linq;
using Yanbal.SFT.FreightManagement.Common.Custom;
using Yanbal.SFT.Domain.Entities.Logic.Common;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Models.Report;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using System.Diagnostics;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.AuditReport
{
    /// <summary>
    /// Contexto de la vista de Reporte de Auditoría
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140916 <br />
    /// Modificación: 
    /// </remarks>
    public class AuditReportContext
    {
        #region Properties
        //Inicio Sonar 15/08/2016
        readonly IPolicyDomain policyDomain;
        readonly YanbalSession yanbalSession;
        readonly EnvironmentEL environment;
        //Fin Sonar
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de implementación de la clase
        /// </summary>
        /// <param name="yanbalSession">Objeto mantenido en Sesión</param>
        public AuditReportContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            this.environment = BaseContext.EnvironmentAdapter(yanbalSession);
            this.policyDomain = new PolicyDomain(environment);
        }
        #endregion
        
        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Reporte de Auditoría
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public AuditReportModel Index()
        {
            AuditReportModel auditReportModel = new AuditReportModel();
            DateTime currentDate = Utility.GetDateTimeNow();
            string controllerName = "AuditReport";
            
            Exception exc;
            ArgumentNullException exArg = new ArgumentNullException();
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(AuditReportContext).FullName);

            try
            {


                auditReportModel.Visualize = new ButtonControl();
                auditReportModel.Visualize.Id = "btnVisualize";
                BaseContext.GetAccessControl(auditReportModel.Visualize.Id, controllerName, auditReportModel.Visualize);

                auditReportModel.Clean = new ButtonControl();
                auditReportModel.Clean.Id = "btnClean";
                BaseContext.GetAccessControl(auditReportModel.Clean.Id, controllerName, auditReportModel.Clean);

                var listAuditTables = LoadAuditTables();
                auditReportModel.ListTable = listAuditTables.ToList();

                auditReportModel.DateFrom = Utility.DatetimeFormatString(currentDate, yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionShortDateFormat);
                auditReportModel.DateTo = Utility.DatetimeFormatString(currentDate, yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionShortDateFormat);

                
            }
            catch (ArgumentNullException ex)
            {
                exArg = ex;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            catch (Exception ex)
            {
                exc = ex;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return auditReportModel;
        }
        
        /// <summary>
        /// Permite cargar las tablas de Auditoria de Politicas
        /// </summary>
        /// <returns>Lista de opciones</returns>
        private List<SelectType> LoadAuditTables()
        {
            List<SelectType> listTables = new List<SelectType>();
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(AuditReportContext).FullName);

            try
            {
                var auditTables = policyDomain.PolicyAuditTableSearch(Enumerated.RegistrationStatus.Active);
                listTables = auditTables.Select(x => new SelectType
                {
                    Id = x.CodeTableAudit.ToString(),
                    Name = x.TableName
                }).ToList();

            }
            catch (ArgumentNullException ex)
            {
                exArg = ex;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            catch (Exception ex)
            {
                exc = ex;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return listTables;
        }

        /// <summary>
        /// Permite cargar los campos de las tablas de Auditoria de Politicas
        /// </summary>
        /// <param name="tableCode">Código de Tabla</param>
        /// <returns>Lista de opciones</returns>
        public List<SelectType> ChangeAuditTable(int? tableCode)
        {
            List<SelectType> listColumns = new List<SelectType>();
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(AuditReportContext).FullName);

            try
            {
                var auditColumns = policyDomain.PolicyAuditColumnSearch(tableCode, Enumerated.RegistrationStatus.Active);
                listColumns = auditColumns.Select(x => new SelectType
                {
                    Id = x.CodeColumnAudit.ToString(),
                    Name = x.ColumnName
                }).ToList();
            }
            catch (ArgumentNullException ex)
            {
                exArg = ex;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            catch (Exception ex)
            {
                exc = ex;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return listColumns;
        }
        #endregion

        #region Reporte
        /// <summary>
        /// Permite generar el Modelo del Reporte
        /// </summary>
        /// <param name="filter">Reporte de Auditoría</param>
        /// <returns>Modelo a aplicar al Reporte</returns>
        public ReportModel Report(AuditReportRequest filter)
        {
            var yanbalSession = SessionContext.GetYanbalSession();
            var reportingSessionWorkspacePathPolicy = yanbalSession != null ? yanbalSession.ReportingWorkspacePathPolicy : "";
            ReportModel reportModel = new ReportModel();
            reportModel.PathReport = String.Format("{0}{1}", reportingSessionWorkspacePathPolicy, Enumerated.ReportFileName.PolicyAudit);
            reportModel.AddParameter("USUARIO", this.yanbalSession.User.Login);
            reportModel.AddParameter("AREA", "FLETES");
            reportModel.AddParameter("CODIGO_LENGUAJE", "");
            reportModel.AddParameter("NOMBRE_REPORTE", Resources.Policy.AuditReport.IndexResource.LabelTitleAuditReport.ToUpper());
            reportModel.AddParameter("CODIGO_UNIDAD_NEGOCIO", this.yanbalSession.BusinessUnit.BusinessUnitCode.ToString());
            reportModel.AddParameter("CODIGO_TABLA", (filter.TableCode.ToString() == "") ? null : filter.TableCode.ToString());
            reportModel.AddParameter("DESCRIPCION_TABLA", filter.TableDescription ?? string.Empty);
            reportModel.AddParameter("CODIGO_ATRIBUTO", (filter.AttributeCode.ToString() == "") ? null : filter.AttributeCode.ToString());
            reportModel.AddParameter("DESCRIPCION_ATRIBUTO", filter.AttributeDescription ?? string.Empty);
            reportModel.AddParameter("FECHA_HASTA_TEXTO", filter.DateTo ?? string.Empty);
            reportModel.AddParameter("FECHA_DESDE_TEXTO", filter.DateFrom ?? string.Empty);

            var dateFrom = Utility.StringFormatDatetime(filter.DateFrom, this.environment.ShortDateFormat);
            var dateTo = Utility.StringFormatDatetime(filter.DateTo, this.environment.ShortDateFormat);

            if (dateFrom.HasValue)
                filter.DateFrom = Utility.DatetimeFormatString(dateFrom);
            if (dateTo.HasValue)
                filter.DateTo = Utility.DatetimeFormatString(dateTo);

            reportModel.AddParameter("FECHA_REGISTRO_DESDE", filter.DateFrom ?? string.Empty);
            reportModel.AddParameter("FECHA_REGISTRO_HASTA", filter.DateTo ?? string.Empty);
            reportModel.AddParameter("USUARIO_OPERACION", filter.UserTransaction ?? string.Empty);
            reportModel.AddParameter("FORMATO_FECHA_CORTA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionShortDateFormat);
            reportModel.AddParameter("FORMATO_FECHA_LARGA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionLongDateFormat);
            reportModel.AddParameter("FORMATO_HORA_CORTA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionShortTimeFormat);
            reportModel.AddParameter("FORMATO_HORA_LARGA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionLongTimeFormat);
            reportModel.AddParameter("FORMATO_NUMERO_ENTERO", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionFormatIntegerNumber);
            reportModel.AddParameter("FORMATO_NUMERO_DECIMAL", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionFormatDecimalNumber);
            reportModel.AddParameter("COLUMNA_TABLA", Resources.Policy.AuditReport.IndexResource.LabelTable ?? string.Empty);
            reportModel.AddParameter("COLUMNA_ATRIBUTO", Resources.Policy.AuditReport.IndexResource.LabelAttribute ?? string.Empty);
            reportModel.AddParameter("COLUMNA_CODIGO_REGISTRO_TABLA", Resources.Policy.AuditReport.IndexResource.LabelRegistrationCodeTable ?? string.Empty);
            reportModel.AddParameter("COLUMNA_VALOR_ORIGINAL", Resources.Policy.AuditReport.IndexResource.LabelOriginalValue ?? string.Empty);
            reportModel.AddParameter("COLUMNA_VALOR_MODIFICADO", Resources.Policy.AuditReport.IndexResource.LabelModifiedValue ?? string.Empty);
            reportModel.AddParameter("COLUMNA_MOTIVO_MODIFICACION", Resources.Shared.GeneralResource.LabelModificationReason ?? string.Empty);
            reportModel.AddParameter("COLUMNA_FECHA_OPERACION", Resources.Policy.AuditReport.IndexResource.LabelTransactionDate ?? string.Empty);
            reportModel.AddParameter("COLUMNA_USUARIO_OPERACION", Resources.Policy.AuditReport.IndexResource.LabelUserOperation ?? string.Empty);
            reportModel.AddParameter("COLUMNA_FECHA_OPERACION_DESDE", Resources.Shared.GeneralResource.LabelFrom ?? string.Empty);
            reportModel.AddParameter("COLUMNA_FECHA_OPERACION_HASTA", Resources.Shared.GeneralResource.LabelTo ?? string.Empty);
            reportModel.AddParameter("COLUMNA_TODOS", Resources.Shared.GeneralResource.LabelSelectAll ?? string.Empty);
            reportModel.AddParameter("COLUMNA_USUARIO", Resources.Shared.GeneralResource.LabelUser ?? string.Empty);
            reportModel.AddParameter("COLUMNA_AREA", Resources.Shared.GeneralResource.LabelArea ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_HORA", Resources.Policy.AuditReport.IndexResource.LabelHour ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_FECHA", Resources.Policy.AuditReport.IndexResource.LabelDate ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_PAGINA", Resources.Policy.AuditReport.IndexResource.LabelPage ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_PAGINA_DE", Resources.Policy.AuditReport.IndexResource.LabelPageOf ?? string.Empty);
            reportModel.AddParameter("PIE_REPORTE", string.Format(Resources.Shared.GeneralResource.LabelReportEndOf, (Resources.Policy.AuditReport.IndexResource.LabelTitleAuditReport.ToUpper())));
            return reportModel;
        }
        #endregion
    }
}
