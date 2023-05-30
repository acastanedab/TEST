using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using System.Diagnostics;
using Yanbal.SFT.FreightManagement.Common.Response;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.Culture;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.ParameterSection
{
    /// <summary>
    /// Contexto de la vista de Sección de Parámetro
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140717 <br />
    /// Modificación: 
    /// </remarks>
    public class ParameterSectionContext
    {
        #region Properties
        //Inicio Sonar 15/08/2016
        readonly IPolicyDomain applicationPolicy;
        readonly YanbalSession yanbalSession;
        //Fin Sonar
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de implementación de la clase
        /// </summary>
        /// <param name="yanbalSession">YanbalSession</param>
        public ParameterSectionContext(YanbalSession yanbalSession)
        {
            applicationPolicy = new PolicyDomain();
            this.yanbalSession = yanbalSession;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Sección de Parámetro
        /// </summary>
        /// <param name="codeParameter">Código de Parámetro</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public ParameterSectionModel Index(int codeParameter)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ParameterSectionModel parameterSectionModel = new ParameterSectionModel();
            try
            {
                string controllerName = "ParameterSection";

                parameterSectionModel.Create = new ButtonControl();
                parameterSectionModel.Create.Id = "btnCreateParameterSection";
                BaseContext.GetAccessControl(parameterSectionModel.Create.Id, controllerName, parameterSectionModel.Create);

                parameterSectionModel.Edit = new ImageControl();
                parameterSectionModel.Edit.Id = "ibtEditParameterSection";
                BaseContext.GetAccessControl(parameterSectionModel.Edit.Id, controllerName, parameterSectionModel.Edit);

                ParameterEL parameterEl = applicationPolicy.ParameterSearch(new ParameterRequest() { CodeParameter = codeParameter, BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode }).Result.FirstOrDefault();
                parameterSectionModel.NameParameter = parameterEl.NameParameter;
                parameterSectionModel.Code = parameterEl.Code;
                parameterSectionModel.CodeParameter = parameterEl.CodeParameter;
                parameterSectionModel.ParamterType = parameterEl.CodeParameterType;
                parameterSectionModel.DescriptionParamterType = parameterEl.DescriptionParameterType;

                parameterSectionModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                parameterSectionModel.ListSectionType = GetListParameterSectionType();
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return parameterSectionModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para registrar Sección de Parámetro
        /// </summary>
        /// <param name="codeParameter">Código de Parámetro</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public ParameterSectionModel Create(int codeParameter)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ParameterSectionModel parameterSectionModel = new ParameterSectionModel();
            try
            {
                string controllerName = "ParameterSection";
                parameterSectionModel.CodeParameter = codeParameter;

                parameterSectionModel.Save = new ButtonControl();
                parameterSectionModel.Save.Id = "btnSaveParameterSection";
                BaseContext.GetAccessControl(parameterSectionModel.Save.Id, controllerName, parameterSectionModel.Save);

                parameterSectionModel.Cancel = new ButtonControl();
                parameterSectionModel.Cancel.Id = "btnCancelParameterSection";
                BaseContext.GetAccessControl(parameterSectionModel.Cancel.Id, controllerName, parameterSectionModel.Cancel);

                parameterSectionModel.ListSectionType = GetListParameterSectionType();
                parameterSectionModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                parameterSectionModel.LabelRegistrationStatus = ((parameterSectionModel.ListRegistrationStatus.Count <= 0) ? "" : parameterSectionModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return parameterSectionModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Sección de Parámetro
        /// </summary>
        /// <param name="codeParameter">Código de Parámetro</param>
        /// <param name="codeParamterSection">Código de Sección de Parámetro</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public ParameterSectionModel Edit(int codeParameter, int codeParamterSection)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ParameterSectionModel parameterSectionModel = new ParameterSectionModel();
            try
            {
                string controllerName = "ParameterSection";

                parameterSectionModel.Save = new ButtonControl();
                parameterSectionModel.Save.Id = "btnSaveEditParameterSection";
                BaseContext.GetAccessControl(parameterSectionModel.Save.Id, controllerName, parameterSectionModel.Save);

                parameterSectionModel.Cancel = new ButtonControl();
                parameterSectionModel.Cancel.Id = "btnCancelEditParameterSection";
                BaseContext.GetAccessControl(parameterSectionModel.Cancel.Id, controllerName, parameterSectionModel.Cancel);

                parameterSectionModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                parameterSectionModel.ListSectionType = GetListParameterSectionType();

                ParameterSectionEL parameterSectionEL = applicationPolicy.ParameterSectionSearch(new ParameterSectionRequest() { BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode, CodeParameter = codeParameter, CodeParameterSection = codeParamterSection }).Result.FirstOrDefault();
                parameterSectionModel.CodeParameter = parameterSectionEL.CodeParameter;
                parameterSectionModel.CodeSection = parameterSectionEL.CodeSection;
                parameterSectionModel.NameSection = parameterSectionEL.NameSection;
                parameterSectionModel.SectionType = parameterSectionEL.CodeParameterSectionType;
                parameterSectionModel.ReadOnlyIndicator = parameterSectionEL.ReadOnlyIndicator;
                parameterSectionModel.RequiredIndicator = parameterSectionEL.RequiredIndicator;
                parameterSectionModel.CreationIndicator = parameterSectionEL.CreationIndicator;
                parameterSectionModel.RegistrationStatus = parameterSectionEL.RegistrationStatus;
                parameterSectionModel.LabelRegistrationStatus = parameterSectionModel.ListRegistrationStatus.Where(item => item.Id == parameterSectionModel.RegistrationStatus).Select(item => item.Name).FirstOrDefault();
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return parameterSectionModel;
        }

        /// <summary>
        /// Permite realizar la búsqueda de Sección de Parámetro
        /// </summary>
        /// <param name="parameterRequest">Sección de Parámetro</param>
        /// <returns>Lista de resultado de Sección de Parámetro</returns>
        public List<ParameterSectionEL> Search(ParameterSectionRequest parameterRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            List<ParameterSectionEL> resultParameters = new List<ParameterSectionEL>();
            try
            {
                if (yanbalSession.ListRegistrationStatus != null && yanbalSession.ListRegistrationStatus.Count > 0)
                {
                    parameterRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                    resultParameters = applicationPolicy.ParameterSectionSearch(parameterRequest).Result;
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
        /// Permite el registro de Sección de Parámetro
        /// </summary>
        /// <param name="parameterSectionRequest">Sección de Parámetro</param>
        /// <returns>Indicador de conformidad</returns>
        public string Register(ParameterSectionRequest parameterSectionRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ProcessResult<string> resul = new ProcessResult<string>();
            try
            {
                parameterSectionRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                parameterSectionRequest.UserCreation = yanbalSession.User.Login;
                parameterSectionRequest.TerminalCreation = yanbalSession.User.Ip;
                resul = applicationPolicy.ParameterSectionRegister(parameterSectionRequest);
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return resul.Result;
        }

        /// <summary>
        /// Permite la modificación de Sección de Parámetro
        /// </summary>
        /// <param name="parameterSectionRequest">Sección de Parámetro</param>
        /// <returns>Indicador de conformidad</returns>
        public string Modify(ParameterSectionRequest parameterSectionRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ProcessResult<string> resul = new ProcessResult<string>();
            try
            {
                parameterSectionRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                parameterSectionRequest.UserModification = yanbalSession.User.Login;
                parameterSectionRequest.TerminalModification = yanbalSession.User.Ip;
                resul = applicationPolicy.ParameterSectionUpdate(parameterSectionRequest);
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
        private List<SelectType> GetListParameterSectionType()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = applicationPolicy.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Enumerated.Parameter.SectionType.ToString(),
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