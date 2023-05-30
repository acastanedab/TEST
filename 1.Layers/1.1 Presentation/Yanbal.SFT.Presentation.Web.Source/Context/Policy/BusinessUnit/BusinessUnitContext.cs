using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManagement.Common.Response;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.BusinessUnit
{
    /// <summary>
    /// Contexto de la vista de Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140917 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class BusinessUnitContext
    {
        #region Properties
        //Inicio Sonar 15/08/2016
        readonly IPolicyDomain policyDomain;
        readonly YanbalSession yanbalSession;
        //Fin Sonar
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de implementación de la clase
        /// </summary>
        /// <param name="yanbalSession">Objeto mantenido en Sesión</param>
        public BusinessUnitContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            this.policyDomain = new PolicyDomain();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Unidad de Negocio
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public BusinessUnitModel Index()
        {
            Exception exc;
            ArgumentNullException exArg;
            StackTrace tracenom = new StackTrace();
            ILogging ilog4Net = new Logging();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitContext).FullName);

            BusinessUnitModel businessUnitModel = new BusinessUnitModel();
            string controllerName = "BusinessUnit";
            try
            {
                businessUnitModel.Search = new ButtonControl();
                businessUnitModel.Search.Id = "btnSearch";
                BaseContext.GetAccessControl(businessUnitModel.Search.Id, controllerName, businessUnitModel.Search);

                businessUnitModel.Create = new ButtonControl();
                businessUnitModel.Create.Id = "btnCreate";
                BaseContext.GetAccessControl(businessUnitModel.Create.Id, controllerName, businessUnitModel.Create);

                businessUnitModel.Edit = new ImageControl();
                businessUnitModel.Edit.Id = "ibtEdit";
                BaseContext.GetAccessControl(businessUnitModel.Edit.Id, controllerName, businessUnitModel.Edit);

                businessUnitModel.GoConfiguration = new ImageControl();
                businessUnitModel.GoConfiguration.Id = "lnkGoConfiguration";
                BaseContext.GetAccessControl(businessUnitModel.GoConfiguration.Id, controllerName, businessUnitModel.GoConfiguration);

                businessUnitModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                businessUnitModel.ListCountry = GetListCountry();

                if (yanbalSession.FilterBusinessUnitRequest != null)
                {
                    businessUnitModel.CountryCode = yanbalSession.FilterBusinessUnitRequest.CountryCode;
                    businessUnitModel.BusinessUnitName = yanbalSession.FilterBusinessUnitRequest.BusinessUnitName;
                    businessUnitModel.RegistrationStatus = yanbalSession.FilterBusinessUnitRequest.RegistrationStatus;
                }
                else
                {
                    businessUnitModel.CountryCode = "";
                    businessUnitModel.BusinessUnitName = "";
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
return businessUnitModel;
        }

        /// <summary>
        /// Permite realizar la búsqueda de Fórmula
        /// </summary>
        /// <param name="businessUnitRequest">Filtro de Fórmula</param>
        /// <returns>Lista de resultado de Fórmula</returns>
        public List<BusinessUnitEL> Search(BusinessUnitRequest businessUnitRequest)
        {
            Exception exc;
            ArgumentNullException exArg;
            StackTrace tracenom = new StackTrace();
            ILogging ilog4Net = new Logging();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitContext).FullName);
            List<BusinessUnitEL> resultBusinessUnit = new List<BusinessUnitEL>();
            try
            {
                businessUnitRequest.BusinessUnitCodeContext = yanbalSession.BusinessUnit.BusinessUnitCode;
                resultBusinessUnit = new List<BusinessUnitEL>();

                if (yanbalSession.ListRegistrationStatus != null && yanbalSession.ListRegistrationStatus.Count > 0)
                {
                    resultBusinessUnit = policyDomain.BusinessUnitSearch(businessUnitRequest).Result;
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return resultBusinessUnit;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para registrar Unidad de Negocio
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public BusinessUnitModel Create()
        {
            Exception exc;
            ArgumentNullException exArg;
            StackTrace tracenom = new StackTrace();
            ILogging ilog4Net = new Logging();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitContext).FullName);
            BusinessUnitModel businessUnitModel = new BusinessUnitModel();
            try
            {
                string controllerName = "BusinessUnit";

                businessUnitModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                businessUnitModel.LabelRegistrationStatus = ((businessUnitModel.ListRegistrationStatus.Count <= 0) ? "" : businessUnitModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());

                businessUnitModel.Save = new ButtonControl();
                businessUnitModel.Save.Id = "btnSaveCreate";
                BaseContext.GetAccessControl(businessUnitModel.Save.Id, controllerName, businessUnitModel.Save);

                businessUnitModel.Cancel = new ButtonControl();
                businessUnitModel.Cancel.Id = "btnCancelCreate";
                BaseContext.GetAccessControl(businessUnitModel.Cancel.Id, controllerName, businessUnitModel.Cancel);

                businessUnitModel.ListCountry = GetListCountry();
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
            return businessUnitModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitCode">Código de unidad de Negocio</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public BusinessUnitModel Edit(int businessUnitCode)
        {
            Exception exc;
            ArgumentNullException exArg;
            StackTrace tracenom = new StackTrace();
            ILogging ilog4Net = new Logging();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitContext).FullName);

            BusinessUnitModel businessUnitModel = new BusinessUnitModel();
            try
            {
                string controllerName = "BusinessUnit";

                businessUnitModel.Save = new ButtonControl();
                businessUnitModel.Save.Id = "btnSaveEdit";
                BaseContext.GetAccessControl(businessUnitModel.Save.Id, controllerName, businessUnitModel.Save);

                businessUnitModel.Cancel = new ButtonControl();
                businessUnitModel.Cancel.Id = "btnCancelEdit";
                BaseContext.GetAccessControl(businessUnitModel.Cancel.Id, controllerName, businessUnitModel.Cancel);

                BusinessUnitEL businessUnitEl = policyDomain.BusinessUnitSearch(new BusinessUnitRequest() { BusinessUnitCode = businessUnitCode, BusinessUnitCodeContext = yanbalSession.BusinessUnit.BusinessUnitCode }).Result.FirstOrDefault();

                businessUnitModel.ListCountry = GetListCountry();
                businessUnitModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

                if (businessUnitEl != null)
                {
                    businessUnitModel.BusinessUnitCode = businessUnitEl.BusinessUnitCode;
                    businessUnitModel.Name = businessUnitEl.Name;
                    businessUnitModel.CountryCode = businessUnitEl.CountryCode;
                    businessUnitModel.BusinessUnitName = businessUnitEl.BusinessName;
                    businessUnitModel.BusinessAddress = businessUnitEl.BusinessAddress;
                    businessUnitModel.CountryDescription = businessUnitEl.CountryName;
                    businessUnitModel.RegistrationStatus = businessUnitEl.RegistrationStatus;
                    businessUnitModel.DescriptionRegistrationStatus = businessUnitEl.DescriptionRegistrationStatus;
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return businessUnitModel;
        }

        /// <summary>
        /// Permite el registro de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitRequest">Unidad de Negocio</param>
        /// <returns>Indicador de Conformidad</returns>
        public string RegisterBusinessUnit(BusinessUnitRequest businessUnitRequest)
        {
            Exception exc;
            ArgumentNullException exArg;
            StackTrace tracenom = new StackTrace();
            ILogging ilog4Net = new Logging();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitContext).FullName);
            var restultProcess = new ProcessResult<string>();


            try
            {
                businessUnitRequest.BusinessUnitCodeContext = yanbalSession.BusinessUnit.BusinessUnitCode;
                businessUnitRequest.UserCreation = yanbalSession.User.Login;
                businessUnitRequest.TerminalCreation = yanbalSession.User.Ip;
                restultProcess = policyDomain.BusinessUnitRegister(businessUnitRequest);

            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return restultProcess.Result;
        }

        /// <summary>
        /// Permite la modificación de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitRequest">Unidad de Negocio</param>
        /// <returns>Indicador de Conformidad</returns>
        public string ModifyBusinessUnit(BusinessUnitRequest businessUnitRequest)
        {
            Exception exc;
            ArgumentNullException exArg;
            StackTrace tracenom = new StackTrace();
            ILogging ilog4Net = new Logging();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(BusinessUnitContext).FullName);
            var restultProcess = new ProcessResult<string>();

            try
            {
                businessUnitRequest.BusinessUnitCodeContext = yanbalSession.BusinessUnit.BusinessUnitCode;
                businessUnitRequest.UserModification = yanbalSession.User.Login;
                businessUnitRequest.TerminalModification = yanbalSession.User.Ip;
                restultProcess = policyDomain.BusinessUnitUpdate(businessUnitRequest);
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return restultProcess.Result;
        }
        #endregion

        #region Adapters
        /// <summary>
        /// Adaptador de lista de opciones a lista de combos
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListCountry()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.CountrySearch(new CountryRequest() { }).Result;

            foreach (var item in listResult)
            {
                listSelect.Add(new SelectType() { Id = item.CountryCode, Name = item.CountryName });
            }
            return listSelect;
        }
        #endregion
    }
}
