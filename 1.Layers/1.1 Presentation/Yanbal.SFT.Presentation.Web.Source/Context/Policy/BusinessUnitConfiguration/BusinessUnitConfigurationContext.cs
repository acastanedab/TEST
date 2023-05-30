using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Yanbal.SFT.FreightManagement.Common.File;
using Yanbal.SFT.Domain.Entities.Logic.Common;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using System.Diagnostics;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using Yanbal.SFT.FreightManagement.Common.Response;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.BusinessUnitConfiguration
{
    /// <summary>
    /// Contexto de la vista de Configuracion de Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140918 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class BusinessUnitConfigurationContext
    {
        #region Properties
        //Inicio Sonar 15/08/2016
        readonly private YanbalSession yanbalSession;
        readonly private EnvironmentEL environment;
        readonly private IPolicyDomain policyDomain;
        //Fin Sonar
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de implementación de la clase
        /// </summary>
        /// <param name="yanbalSession">Objeto mantenido en sessión</param>
        public BusinessUnitConfigurationContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            environment = BaseContext.EnvironmentAdapter(yanbalSession);
            this.policyDomain = new PolicyDomain(environment);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public BusinessUnitConfigurationModel Index(int businessUnitCode)
        {
            BusinessUnitRequest businessUnitRequest = new BusinessUnitRequest();
            businessUnitRequest.BusinessUnitCodeContext = yanbalSession.BusinessUnit.BusinessUnitCode;
            businessUnitRequest.BusinessUnitCode = businessUnitCode;

            string controllerName = "BusinessUnitConfiguration";

            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitConfigurationContext).FullName);
            BusinessUnitConfigurationModel businessUnitConfigurationModel = new BusinessUnitConfigurationModel();
            try
            {
                var businessUnitConfiguration = policyDomain.BusinessUnitSearch(businessUnitRequest).Result;

              
                if (businessUnitConfiguration.Count > 0)
                {
                    businessUnitConfigurationModel.BusinessUnitName = businessUnitConfiguration.FirstOrDefault().Name;
                    businessUnitConfigurationModel.BusinessUnitCode = businessUnitConfiguration.FirstOrDefault().BusinessUnitCode;
                }

                businessUnitConfigurationModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

                businessUnitConfigurationModel.Create = new ButtonControl();
                businessUnitConfigurationModel.Create.Id = "btnCreate";
                BaseContext.GetAccessControl(businessUnitConfigurationModel.Create.Id, controllerName, businessUnitConfigurationModel.Create);

                businessUnitConfigurationModel.Edit = new ImageControl();
                businessUnitConfigurationModel.Edit.Id = "lnkEditarBusinessUnitConfiguration";
                BaseContext.GetAccessControl(businessUnitConfigurationModel.Edit.Id, controllerName, businessUnitConfigurationModel.Edit);

                businessUnitConfigurationModel.SelectCompanyLogo = new ImageControl();
                businessUnitConfigurationModel.SelectCompanyLogo.Id = "lnkSelectCompanyLogo";
                BaseContext.GetAccessControl(businessUnitConfigurationModel.SelectCompanyLogo.Id, controllerName, businessUnitConfigurationModel.SelectCompanyLogo);

                businessUnitConfigurationModel.SelectReportLogo = new ImageControl();
                businessUnitConfigurationModel.SelectReportLogo.Id = "lnkSelectReportLogo";
                BaseContext.GetAccessControl(businessUnitConfigurationModel.SelectReportLogo.Id, controllerName, businessUnitConfigurationModel.SelectReportLogo);

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
            return businessUnitConfigurationModel;
        }

        /// <summary>
        /// Permite realizar la búsqueda de Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitConfigurationRequest">Filtro de Configuración de Unidad de Negocio</param>
        /// <returns>Lista de Configuración de Unidad de Negocio</returns>
        public List<BusinessUnitConfigurationEL> Search(BusinessUnitConfigurationRequest businessUnitConfigurationRequest)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitConfigurationContext).FullName);

            List<BusinessUnitConfigurationEL> resultBusinessUnitConfiguration = new List<BusinessUnitConfigurationEL>();
            try
            {
                if (yanbalSession.ListRegistrationStatus != null && yanbalSession.ListRegistrationStatus.Count > 0)
                {
                    businessUnitConfigurationRequest.BusinessUnitCodeContext = yanbalSession.BusinessUnit.BusinessUnitCode;
                    businessUnitConfigurationRequest.RegistrationStatus = Enumerated.RegistrationStatus.Active;
                    resultBusinessUnitConfiguration = policyDomain.BusinessUnitConfigurationSearch(businessUnitConfigurationRequest).Result;
                    if (resultBusinessUnitConfiguration.Count > 0)
                    {
                        resultBusinessUnitConfiguration.FirstOrDefault().NumberRows = "1";
                    }
                }
            }
            catch (Exception ex)
            {
                exc = ex;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return resultBusinessUnitConfiguration;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para registrar Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public BusinessUnitConfigurationModel Create(int? businessUnitCode)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitConfigurationContext).FullName);

            BusinessUnitConfigurationModel businessUnitConfigurationModel = new BusinessUnitConfigurationModel();
            try
            {
                string controllerName = "BusinessUnitConfiguration";

                businessUnitConfigurationModel.ListCulture = GetListCulture();
                businessUnitConfigurationModel.ListTimeZone = GetListTimeZone();
                businessUnitConfigurationModel.ListDisplayFormReport = GetListDisplayFormReport();

                businessUnitConfigurationModel.Save = new ButtonControl();
                businessUnitConfigurationModel.Save.Id = "btnSave";
                BaseContext.GetAccessControl(businessUnitConfigurationModel.Save.Id, controllerName, businessUnitConfigurationModel.Save);

                businessUnitConfigurationModel.Cancel = new ButtonControl();
                businessUnitConfigurationModel.Cancel.Id = "btnCancel";
                BaseContext.GetAccessControl(businessUnitConfigurationModel.Cancel.Id, controllerName, businessUnitConfigurationModel.Cancel);

                businessUnitConfigurationModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                businessUnitConfigurationModel.LabelRegistrationStatus = ((businessUnitConfigurationModel.ListRegistrationStatus.Count <= 0) ? "" : businessUnitConfigurationModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());

                businessUnitConfigurationModel.BusinessUnitCode = Convert.ToInt32(businessUnitCode);
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
            return businessUnitConfigurationModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitConfigurationCode">Código de Unidad de Negocio de Configuración</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public BusinessUnitConfigurationModel Edit(int businessUnitConfigurationCode)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitConfigurationContext).FullName);


            BusinessUnitConfigurationModel businessUnitConfigurationModel = new BusinessUnitConfigurationModel();
            
            try
            {
                string controllerName = "BusinessUnitConfiguration";

                businessUnitConfigurationModel.Save = new ButtonControl();
                businessUnitConfigurationModel.Save.Id = "btnSaveEdit";
                BaseContext.GetAccessControl(businessUnitConfigurationModel.Save.Id, controllerName, businessUnitConfigurationModel.Save);

                businessUnitConfigurationModel.Cancel = new ButtonControl();
                businessUnitConfigurationModel.Cancel.Id = "btnCancelEdit";
                BaseContext.GetAccessControl(businessUnitConfigurationModel.Cancel.Id, controllerName, businessUnitConfigurationModel.Cancel);

                BusinessUnitConfigurationEL businessUnitConfigurationEl = policyDomain.BusinessUnitConfigurationSearch(new BusinessUnitConfigurationRequest() { BusinessUnitConfigurationCode = businessUnitConfigurationCode, BusinessUnitCodeContext = yanbalSession.BusinessUnit.BusinessUnitCode }).Result.FirstOrDefault();

                businessUnitConfigurationModel.ListCulture = GetListCulture();
                businessUnitConfigurationModel.ListTimeZone = GetListTimeZone();
                businessUnitConfigurationModel.ListDisplayFormReport = GetListDisplayFormReport();
                businessUnitConfigurationModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                businessUnitConfigurationModel.LabelRegistrationStatus = ((businessUnitConfigurationModel.ListRegistrationStatus.Count <= 0) ? "" : businessUnitConfigurationModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());

                if (businessUnitConfigurationEl != null)
                {
                    businessUnitConfigurationModel.BusinessUnitConfigurationCode = businessUnitConfigurationEl.BusinessUnitConfigurationCode;
                    businessUnitConfigurationModel.BusinessUnitCode = businessUnitConfigurationEl.BusinessUnitCode;
                    businessUnitConfigurationModel.CultureCode = businessUnitConfigurationEl.Culture.CultureCode;
                    businessUnitConfigurationModel.TimeZoneCode = businessUnitConfigurationEl.TimeZoneCode;
                    businessUnitConfigurationModel.DisplayFormReport = businessUnitConfigurationEl.DisplayFormReport;
                    businessUnitConfigurationModel.RowsPerPage = businessUnitConfigurationEl.RowsPerPage;
                    businessUnitConfigurationModel.CharactersMinimumGloss = businessUnitConfigurationEl.MinimumNumberCharactersGloss;
                    businessUnitConfigurationModel.VowelsMinimumGloss = businessUnitConfigurationEl.MinimumNumberVowelGloss;
                    businessUnitConfigurationModel.IndicatorDisplayMenu = businessUnitConfigurationEl.CollapseMenuIndicator;
                    businessUnitConfigurationModel.RegistrationStatus = businessUnitConfigurationEl.RegistrationStatus;
                    businessUnitConfigurationModel.DescriptionRegistrationStatus = businessUnitConfigurationEl.DescriptionRegistrationStatus;
                }
            }
            catch (Exception ex)
            {
                exc = ex;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return businessUnitConfigurationModel;
        }

        /// <summary>
        /// Permite el registro de Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="register">Configuración de Unidad de Negocio</param>
        /// <param name="cultureCode">Código de Cultura</param>
        /// <param name="timeZoneCode">Código de Zona Horaria</param>
        /// <param name="charactersMinimumGloss">Mínimo de Caracteres de Glosa</param>
        /// <param name="vowelsMinimumGloss">Mínimo de Vocales de Glosa</param>
        /// <param name="indicatorAcquiringMainMenu">Indicador de Contraer el menú</param>
        /// <param name="request">Información enviada desde el navegador</param>
        /// <returns>Indicador de conformidad</returns>
        public string RegisterBusinessUnitConfiguration(BusinessUnitConfigurationRequest register, string cultureCode, int timeZoneCode, byte? charactersMinimumGloss, byte? vowelsMinimumGloss, bool? indicatorAcquiringMainMenu, HttpRequestBase request)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitConfigurationContext).FullName);

            var result = new ProcessResult<string>();
            try
            {
                HttpPostedFileBase fileCompanyLogo = request.Files["fileCompanyLogo"];
                HttpPostedFileBase fileReportLogo = request.Files["fileReportLogo"];

                register.BusinessUnitCodeContext = yanbalSession.BusinessUnit.BusinessUnitCode;
                register.UserCreation = yanbalSession.User.Login;
                register.TerminalCreation = yanbalSession.User.Ip;

                if (fileCompanyLogo != null)
                {
                    register.CompanyLogo = CustomFileManager.ReadFully(fileCompanyLogo.InputStream);
                }
                if (fileReportLogo != null)
                {
                    register.ReportLogo = CustomFileManager.ReadFully(fileReportLogo.InputStream);
                }

                register.TimeZoneCode = timeZoneCode;
                register.CultureCode = cultureCode;
                register.MinimumNumberCharactersGloss = charactersMinimumGloss;
                register.MinimumNumberVowelsGloss = vowelsMinimumGloss;
                register.CollapseMenuIndicator = indicatorAcquiringMainMenu;
                result = policyDomain.BusinessUnitConfigurationRegister(register);
            }
            catch (Exception ex)
            {
                exc = ex;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return result.Result;
        }

        /// <summary>
        /// Permite la modificación de Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="register">Configuración de Unidad de Negocio</param>
        /// <param name="cultureCode">Código de Cultura</param>
        /// <param name="timeZoneCode">Código de Zona Horaria</param>
        /// <param name="charactersMinimumGloss">Mínimo de Caracteres de Glosa</param>
        /// <param name="vowelsMinimumGloss">Mínimo de Vocales de Glosa</param>
        /// <param name="indicatorAcquiringMainMenu">Indicador de Contraer el menú</param>
        /// <param name="request">Información enviada desde el navegador</param>
        /// <returns>Indicador de conformidad</returns>
        public string ModifyBusinessUnitConfiguration(BusinessUnitConfigurationRequest register, string cultureCode, int timeZoneCode, byte? charactersMinimumGloss, byte? vowelsMinimumGloss, bool? indicatorAcquiringMainMenu, HttpRequestBase request)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitConfigurationContext).FullName);

            var result = new ProcessResult<string>();
            try
            {
                HttpPostedFileBase fileCompanyLogo = request.Files["fileCompanyLogo"];
                HttpPostedFileBase fileReportLogo = request.Files["fileReportLogo"];
                register.RegistrationStatus = Enumerated.RegistrationStatus.Active;
                register.BusinessUnitCodeContext = yanbalSession.BusinessUnit.BusinessUnitCode;
                register.UserModification = yanbalSession.User.Login;
                register.TerminalModification = yanbalSession.User.Ip;

                if (fileCompanyLogo != null)
                {
                    register.CompanyLogo = CustomFileManager.ReadFully(fileCompanyLogo.InputStream);
                }
                if (fileReportLogo != null)
                {
                    register.ReportLogo = CustomFileManager.ReadFully(fileReportLogo.InputStream);
                }

                register.TimeZoneCode = timeZoneCode;
                register.CultureCode = cultureCode;
                register.MinimumNumberCharactersGloss = charactersMinimumGloss;
                register.MinimumNumberVowelsGloss = vowelsMinimumGloss;
                register.CollapseMenuIndicator = indicatorAcquiringMainMenu;
                result = policyDomain.BusinessUnitConfigurationUpdate(register);
            }
            catch (Exception ex)
            {
                exc = ex;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return result.Result;
        }

        /// <summary>
        /// Permite la visualización del Logo de la Compañia
        /// </summary>
        /// <param name="businessUnitConfigurationCode">Código de Configuración de Unidad de Negocio</param>
        /// <param name="imageByte">Arreglo de bytes que contiene el Logo</param>
        /// <param name="contentType">Tipo de Contenido</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public BusinessUnitConfigurationModel ViewCompanyLogoImage(int businessUnitConfigurationCode, byte[] imageByte, string contentType)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitConfigurationContext).FullName);

            BusinessUnitConfigurationModel businessUnitConfigurationModel = new BusinessUnitConfigurationModel();

            try
            {
                List<BusinessUnitConfigurationEL> businessUnitConfiguration = policyDomain.GetLogoBusinessUnitConfiguration(new BusinessUnitConfigurationRequest { BusinessUnitConfigurationCode = businessUnitConfigurationCode }).ToList();

                foreach (var item in businessUnitConfiguration)
                {
                    businessUnitConfigurationModel.BusinessUnitConfigurationCode = businessUnitConfigurationCode;
                    businessUnitConfigurationModel.CompanyLogoImage = item.CompanyLogo;
                    imageByte = businessUnitConfigurationModel.CompanyLogoImage;
                }

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
            return businessUnitConfigurationModel;
        }

        /// <summary>
        /// Permite la visualización del Logo de la Reporte
        /// </summary>
        /// <param name="businessUnitConfigurationCode">Código de Configuración de Unidad de Negocio</param>
        /// <param name="imageByte">Arreglo de bytes que contiene el Logo</param>
        /// <param name="contentType">Tipo de Contenido</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public BusinessUnitConfigurationModel ViewReportLogoImage(int businessUnitConfigurationCode, byte[] imageByte, string contentType)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitConfigurationContext).FullName);

            BusinessUnitConfigurationModel businessUnitConfigurationModel = new BusinessUnitConfigurationModel();
            
            try
            {
                List<BusinessUnitConfigurationEL> businessUnitConfigurationEl = policyDomain.GetLogoBusinessUnitConfiguration(new BusinessUnitConfigurationRequest { BusinessUnitConfigurationCode = businessUnitConfigurationCode }).ToList();

                foreach (var item in businessUnitConfigurationEl)
                {
                    businessUnitConfigurationModel.BusinessUnitConfigurationCode = businessUnitConfigurationCode;
                    businessUnitConfigurationModel.ReportLogoImage = item.ReportLogo;
                    imageByte = businessUnitConfigurationModel.ReportLogoImage;
                }
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
            return businessUnitConfigurationModel;
        }
        #endregion

        #region Adapters
        /// <summary>
        /// Adaptador de lista de opciones a lista de combos
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListDisplayFormReport()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Enumerated.Parameter.DisplayFormReport.ToString(),
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult.Select(itemResult => itemResult.RecordValueString))
            {
                listSelect.Add(new SelectType() { Id = item["1"], Name = item["2"] });
            }
            return listSelect;
        }

        /// <summary>
        /// Adaptador de lista de opciones a lista de combos
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListCulture()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.CultureSearch(new CultureRequest()
            {
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult)
            {
                listSelect.Add(new SelectType() { Id = item.CultureCode, Name = item.CultureCode });
            }
            return listSelect;
        }

        /// <summary>
        /// Adaptador de lista de opciones a lista de combos
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListTimeZone()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.TimeZoneSearch(new TimeZoneRequest()
            {
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult)
            {
                listSelect.Add(new SelectType() { Id = Convert.ToString(item.TimeZoneCode), Name = item.FullDescription });
            }
            return listSelect;
        }
        #endregion
    }
}
