using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.Parameter
{
    /// <summary>
    /// Contexto de la vista de Parámetro
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140717 <br />
    /// Modificación: 
    /// </remarks>
    public class ParameterContext
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
        public ParameterContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            policyDomain = new PolicyDomain();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Parámetro
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public ParameterModel Index()
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ParameterModel parameterModel = new ParameterModel();
            try
            {
                string controllerName = "Parameter";

                parameterModel.Search = new ButtonControl();
                parameterModel.Search.Id = "btnSearchParameter";
                BaseContext.GetAccessControl(parameterModel.Search.Id, controllerName, parameterModel.Search);

                parameterModel.Create = new ButtonControl();
                parameterModel.Create.Id = "btnCreateParameter";
                BaseContext.GetAccessControl(parameterModel.Create.Id, controllerName, parameterModel.Create);

                parameterModel.Edit = new ImageControl();
                parameterModel.Edit.Id = "ibtEditParameter";
                BaseContext.GetAccessControl(parameterModel.Edit.Id, controllerName, parameterModel.Edit);

                parameterModel.GoSection = new ImageControl();
                parameterModel.GoSection.Id = "lnkGoSection";
                BaseContext.GetAccessControl(parameterModel.GoSection.Id, controllerName, parameterModel.GoSection);

                parameterModel.ListParameterType = GetListParameterType();
                parameterModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

                if (yanbalSession.FilterParameterRequest != null)
                {
                    parameterModel.ParameterName = yanbalSession.FilterParameterRequest.ParameterName;
                    parameterModel.ParameterDescription = yanbalSession.FilterParameterRequest.ParameterDescription;
                    parameterModel.CodeParameterType = yanbalSession.FilterParameterRequest.CodeParameterType;
                    parameterModel.RegistrationStatus = yanbalSession.FilterParameterRequest.RegistrationStatus;
                }
                else
                {
                    parameterModel.ParameterName = "";
                    parameterModel.ParameterDescription = "";
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return parameterModel;
        }

        /// <summary>
        /// Permite realizar la búsqueda de Parámetro
        /// </summary>
        /// <param name="parameterRequest">Filtro de Parámetro</param>
        /// <returns>Lista de resultado de Parámetro</returns>
        public List<ParameterEL> Search(ParameterRequest parameterRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            List<ParameterEL> resultParameters = new List<ParameterEL>();
            try
            {
                if (yanbalSession.ListRegistrationStatus != null && yanbalSession.ListRegistrationStatus.Count > 0)
                {
                    parameterRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                    resultParameters = policyDomain.ParameterSearch(parameterRequest).Result;
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return resultParameters;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para registrar Parámetro
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public ParameterModel Create()
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ParameterModel parameterModel = new ParameterModel();
            try
            {
                string controllerName = "Parameter";

                parameterModel.Save = new ButtonControl();
                parameterModel.Save.Id = "btnSaveParameter";
                BaseContext.GetAccessControl(parameterModel.Save.Id, controllerName, parameterModel.Save);

                parameterModel.Cancel = new ButtonControl();
                parameterModel.Cancel.Id = "btnCancelParameter";
                BaseContext.GetAccessControl(parameterModel.Cancel.Id, controllerName, parameterModel.Cancel);

                parameterModel.ListParameterType = GetListParameterType();
                parameterModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                parameterModel.LabelRegistrationStatus = ((parameterModel.ListRegistrationStatus.Count <= 0) ? "" : parameterModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());

            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return parameterModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Parámetro
        /// </summary>
        /// <param name="codeParameter">Código de Parámetro</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public ParameterModel Edit(int codeParameter)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ParameterModel parameterModel = new ParameterModel();
            try
            {
                string controllerName = "Parameter";

                ParameterEL parameterEl = policyDomain.ParameterSearch(new ParameterRequest() { BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode, CodeParameter = codeParameter }).Result.FirstOrDefault();

                parameterModel.Save = new ButtonControl();
                parameterModel.Save.Id = "btnSaveEditParameter";
                BaseContext.GetAccessControl(parameterModel.Save.Id, controllerName, parameterModel.Save);

                parameterModel.Cancel = new ButtonControl();
                parameterModel.Cancel.Id = "btnCancelEditParameter";
                BaseContext.GetAccessControl(parameterModel.Cancel.Id, controllerName, parameterModel.Cancel);

                parameterModel.ListParameterType = GetListParameterType();
                parameterModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

                if (parameterEl != null)
                {
                    parameterModel.CodeParamater = parameterEl.CodeParameter;
                    parameterModel.Code = parameterEl.Code;
                    parameterModel.ParameterName = parameterEl.NameParameter;
                    parameterModel.ParameterDescription = parameterEl.DescriptionParameter;
                    parameterModel.CodeParameterType = parameterEl.CodeParameterType;
                    parameterModel.DescriptionParameterType = parameterEl.DescriptionParameterType;
                    parameterModel.AllowAddValue = parameterEl.AllowAddValueIndicator;
                    parameterModel.AllowModifyValue = parameterEl.AllowModifyValueIndicator;
                    parameterModel.SystemIndicator = parameterEl.ParameterSystemIndicator;
                    parameterModel.RegistrationStatus = parameterEl.RegistrationStatus;
                    parameterModel.LabelRegistrationStatus = parameterEl.DescriptionRegistrationStatus;
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return parameterModel;
        }

        /// <summary>
        /// Permite el registro de Parámetro
        /// </summary>
        /// <param name="parameterRequest">Parámetro</param>
        /// <returns>Indicador de conformidad</returns>
        public string Register(ParameterRequest parameterRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);


            ProcessResult<string> resul = new ProcessResult<string>();
            try
            {
                parameterRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                parameterRequest.UserCreation = yanbalSession.User.Login;
                parameterRequest.TerminalCreation = yanbalSession.User.Ip;
                parameterRequest.LabelCodeSection = Yanbal.SFT.Presentation.Web.Source.Resources.Policy.Parameter.IndexResource.LabelCodeSection;
                parameterRequest.LabelDescriptionSection = Yanbal.SFT.Presentation.Web.Source.Resources.Policy.Parameter.IndexResource.LabelDescriptionSection;
                parameterRequest.LabelBeginSection = Yanbal.SFT.Presentation.Web.Source.Resources.Policy.Parameter.IndexResource.LabelBeginSection;
                parameterRequest.LabelEndSection = Yanbal.SFT.Presentation.Web.Source.Resources.Policy.Parameter.IndexResource.LabelEndSection;
                resul = policyDomain.ParameterRegister(parameterRequest);
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return resul.Result;
        }

        /// <summary>
        /// Permite la modificación de Parámetro
        /// </summary>
        /// <param name="parameterRequest">Parámetro</param>
        /// <returns>Indicador de conformidad</returns>
        public string Modify(ParameterRequest parameterRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ProcessResult<string> resul = new ProcessResult<string>();
            try
            {
                parameterRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                parameterRequest.UserModification = yanbalSession.User.Login;
                parameterRequest.TerminalModification = yanbalSession.User.Ip;
                resul = policyDomain.ParameterUpdate(parameterRequest);
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
        private List<SelectType> GetListParameterType()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Enumerated.Parameter.ParameterType.ToString(),
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult.Select(itemResult => itemResult.RecordValueString))
            {
                listSelect.Add(new SelectType() { Id = item["1"], Name = item["2"] });
            }
            return listSelect;
        }
        #endregion
    }
}