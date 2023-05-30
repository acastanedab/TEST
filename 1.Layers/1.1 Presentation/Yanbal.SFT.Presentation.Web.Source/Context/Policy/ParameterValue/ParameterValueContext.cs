using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.Logic.Common;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManagement.Common.Response;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.Culture;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.ParameterValue
{
    /// <summary>
    /// Contexto de la vista de Parámetro
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140822 <br />
    /// Modificación: 
    /// </remarks>
    public class ParameterValueContext
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
        /// <param name="yanbalSession">YanbalSession</param>
        public ParameterValueContext(YanbalSession yanbalSession)
        {
            EnvironmentEL environment = BaseContext.EnvironmentAdapter(yanbalSession);
            policyDomain = new PolicyDomain(environment);
            this.yanbalSession = yanbalSession;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Valor de Parámetro
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public ParameterValueModel Index()
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ParameterValueModel parameterValueModel = new ParameterValueModel();
            try
            {
                string controllerName = "Parameter";

                parameterValueModel.Search = new ButtonControl();
                parameterValueModel.Search.Id = "btnSearchParameterValue";
                BaseContext.GetAccessControl(parameterValueModel.Search.Id, controllerName, parameterValueModel.Search);

                parameterValueModel.Create = new ButtonControl();
                parameterValueModel.Create.Id = "btnCreateParameterValue";
                BaseContext.GetAccessControl(parameterValueModel.Create.Id, controllerName, parameterValueModel.Create);

                parameterValueModel.Edit = new ImageControl();
                parameterValueModel.Edit.Id = "ibtEditParameterValue";
                BaseContext.GetAccessControl(parameterValueModel.Edit.Id, controllerName, parameterValueModel.Edit);


                parameterValueModel.ListParameter = GetListParameter();
                parameterValueModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;


                if (yanbalSession.FilterParameterRequest != null)
                {
                    parameterValueModel.CodeParameterType = yanbalSession.FilterParameterRequest.CodeParameterType;
                    parameterValueModel.RegistrationStatus = yanbalSession.FilterParameterRequest.RegistrationStatus;
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return parameterValueModel;            
        }

        /// <summary>
        /// Permite realizar la búsqueda de Valor de Parámetro
        /// </summary>
        /// <param name="parameterValueRequest">Valor de Parámetro</param>
        /// <returns>Lista de resultado de Valor de Parámetro</returns>
        public ParameterValueModel Search(ParameterValueRequest parameterValueRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ParameterValueModel parameterValueModel = Index();
            try
            {
                parameterValueRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;

                parameterValueModel.Parameter = policyDomain.ParameterSearch(new ParameterRequest()
                {
                    BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                    Code = parameterValueRequest.Code,
                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                }).Result.FirstOrDefault();

                parameterValueModel.ListParameterSection = policyDomain.ParameterSectionSearch(new ParameterSectionRequest()
                {
                    BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                    CodeParameter = parameterValueModel.Parameter.CodeParameter,
                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                }).Result;
                parameterValueModel.ListParameterValue = policyDomain.ParameterValueSearch(parameterValueRequest).Result;
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return parameterValueModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para registrar Valor de Parámetro
        /// </summary>
        /// <param name="code">Código de Parámetro</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public ParameterValueModel Create(string code)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ParameterValueModel parameterValueModel = new ParameterValueModel();
          
            try
            {
                string controllerName = "Parameter";

                parameterValueModel.Save = new ButtonControl();
                parameterValueModel.Save.Id = "btnSaveParameterValue";
                BaseContext.GetAccessControl(parameterValueModel.Save.Id, controllerName, parameterValueModel.Save);

                parameterValueModel.Cancel = new ButtonControl();
                parameterValueModel.Cancel.Id = "btnCancelParameterValue";
                BaseContext.GetAccessControl(parameterValueModel.Cancel.Id, controllerName, parameterValueModel.Cancel);


                parameterValueModel.Parameter = policyDomain.ParameterSearch(new ParameterRequest()
                {
                    BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                    Code = code,
                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                }).Result.FirstOrDefault();

                parameterValueModel.CodeParameter = parameterValueModel.Parameter.CodeParameter;

                parameterValueModel.ListParameterSection = policyDomain.ParameterSectionSearch(new ParameterSectionRequest()
                {
                    BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                    CodeParameter = parameterValueModel.Parameter.CodeParameter,
                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                }).Result;

                parameterValueModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

                parameterValueModel.LabelRegistrationStatus = ((parameterValueModel.ListRegistrationStatus.Count <= 0) ? "" : parameterValueModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return parameterValueModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Valor de Parámetro
        /// </summary>
        /// <param name="codeParameter">Código del Parámetro</param>
        /// <param name="codeParameterValue">Código de Valor de Parámetro</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public ParameterValueModel Edit(int codeParameter,int codeParameterValue)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ParameterValueModel parameterValueModel = new ParameterValueModel();
            try
            {
                string controllerName = "ParameterValue";

                parameterValueModel.Save = new ButtonControl();
                parameterValueModel.Save.Id = "btnSaveEditParameterValue";
                BaseContext.GetAccessControl(parameterValueModel.Save.Id, controllerName, parameterValueModel.Save);

                parameterValueModel.Cancel = new ButtonControl();
                parameterValueModel.Cancel.Id = "btnCancelEditParameterValue";
                BaseContext.GetAccessControl(parameterValueModel.Cancel.Id, controllerName, parameterValueModel.Cancel);

                parameterValueModel.CodeParameter = codeParameter;

                parameterValueModel.Parameter = policyDomain.ParameterSearch(new ParameterRequest()
                {
                    BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                    CodeParameter = codeParameter,
                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                }).Result.FirstOrDefault();

                parameterValueModel.ListParameterSection = policyDomain.ParameterSectionSearch(new ParameterSectionRequest()
                {
                    BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                    CodeParameter = codeParameter,
                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                }).Result;

                parameterValueModel.ListParameterValue = policyDomain.ParameterValueSearch(new ParameterValueRequest()
                {
                    BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                    CodeParameter = codeParameter,
                    CodeValue = codeParameterValue
                }).Result;

                parameterValueModel.CodeValue = parameterValueModel.ListParameterValue.FirstOrDefault().CodeValue;
                parameterValueModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

                parameterValueModel.RegistrationStatus = parameterValueModel.ListParameterValue.FirstOrDefault().RegistrationStatus;
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return parameterValueModel;
        }

        /// <summary>
        /// Permite el registro de Valor de Parámetro
        /// </summary>
        /// <param name="parameterValueRequest">Valor de Parámetro</param>
        /// <returns>Indicador de conformidad</returns>
        public string Register(ParameterValueRequest parameterValueRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ProcessResult<string> resul = new ProcessResult<string>();
            try
            {
                parameterValueRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                parameterValueRequest.UserCreation = yanbalSession.User.Login;
                parameterValueRequest.TerminalCreation = yanbalSession.User.Ip;
                resul = policyDomain.ParameterValueRegister(parameterValueRequest);
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }

            return resul.Result;
        }

        /// <summary>
        /// Permite la modificación de Valor de Parámetro
        /// </summary>
        /// <param name="parameterValueRequest">Valor de Parámetro</param>
        /// <returns>Indicador de conformidad</returns>
        public string Modify(ParameterValueRequest parameterValueRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ProcessResult<string> resul = new ProcessResult<string>();
        
            try
            {
                parameterValueRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                parameterValueRequest.UserModification = yanbalSession.User.Login;
                parameterValueRequest.TerminalModification = yanbalSession.User.Ip;
                resul = policyDomain.ParameterValueUpdate(parameterValueRequest);
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return resul.Result;
        }
        #endregion

        #region Adapters

        /// <summary>
        /// Adaptador de lista de opciones a lista de combos
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListParameter()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.ParameterSearch(new ParameterRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult)
            {
                listSelect.Add(new SelectType() { Id = Convert.ToString(item.Code), Name = item.NameParameter });
            }
            return listSelect;
        }
        #endregion
    }
}
