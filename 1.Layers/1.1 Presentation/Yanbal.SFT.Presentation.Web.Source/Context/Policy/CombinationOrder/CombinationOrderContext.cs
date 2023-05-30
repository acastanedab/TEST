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

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.CombinationOrder
{
    /// <summary>
    /// Contexto de la vista de Orden de Combinación
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140910 <br />
    /// Modificación: 
    /// </remarks>
    public class CombinationOrderContext
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
        public CombinationOrderContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            this.policyDomain = new PolicyDomain();  
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Orden de Combinación
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public CombinationOrderModel Index()
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CombinationOrderContext).FullName);

            CombinationOrderModel combinationOrderModel = new CombinationOrderModel();
            try
            {
                string controllerName = "CombinationOrder";

                combinationOrderModel.Save = new ButtonControl();
                combinationOrderModel.Save.Id = "btnSaveCreate";
                BaseContext.GetAccessControl(combinationOrderModel.Save.Id, controllerName, combinationOrderModel.Save);

                combinationOrderModel.Edit = new ImageControl();
                combinationOrderModel.Edit.Id = "ibtEdit";
                BaseContext.GetAccessControl(combinationOrderModel.Edit.Id, controllerName, combinationOrderModel.Edit);

                combinationOrderModel.ListParameter = GetListParameter();
                combinationOrderModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
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
            return combinationOrderModel;
        }

        /// <summary>
        /// Permite realizar la búsqueda de Orden de Combinación
        /// </summary>
        /// <param name="combinatioOrderRequest">Orden de Combinación</param>
        /// <returns>Lista de resultado de Orden de Combinación</returns>
        public List<CombinationOrderEL> Search(CombinationOrderRequest combinatioOrderRequest)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CombinationOrderContext).FullName);

            List<CombinationOrderEL> resultCombinationOrder = new List<CombinationOrderEL>();
            try
            {
                if (yanbalSession.ListRegistrationStatus != null && yanbalSession.ListRegistrationStatus.Count > 0)
                {
                    combinatioOrderRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                    combinatioOrderRequest.RegistrationStatus = Enumerated.RegistrationStatus.Active;
                    resultCombinationOrder = policyDomain.CombinationOrderSearch(combinatioOrderRequest).Result;
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
            return resultCombinationOrder;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Orden de Combinación
        /// </summary>
        /// <param name="orderCodeCombination">Código de Orden de Combinación</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public CombinationOrderModel Edit(int orderCodeCombination)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CombinationOrderContext).FullName);

            CombinationOrderModel combinationOrderModel = new CombinationOrderModel();
            try
            {
                string controllerName = "CombinationOrder";

                CombinationOrderEL combinationOrderEl = policyDomain.CombinationOrderSearch(new CombinationOrderRequest() { BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode, OrderCodeCombination = orderCodeCombination }).Result.FirstOrDefault();

                combinationOrderModel.Save = new ButtonControl();
                combinationOrderModel.Save.Id = "btnSaveEdit";
                BaseContext.GetAccessControl(combinationOrderModel.Save.Id, controllerName, combinationOrderModel.Save);

                combinationOrderModel.Cancel = new ButtonControl();
                combinationOrderModel.Cancel.Id = "btnCancelEdit";
                BaseContext.GetAccessControl(combinationOrderModel.Cancel.Id, controllerName, combinationOrderModel.Cancel);

                if (combinationOrderEl != null)
                {
                    combinationOrderModel.OrderCodeCombination = combinationOrderEl.OrderCodeCombination;
                    combinationOrderModel.CodeParameter = combinationOrderEl.ParameterCode;
                    combinationOrderModel.Order = combinationOrderEl.Order;
                    combinationOrderModel.DescriptionParameter = combinationOrderEl.ParameterName;
                    combinationOrderModel.RegistrationStatus = combinationOrderEl.RegistrationStatus;
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
            return combinationOrderModel;
        }

        /// <summary>
        /// Permite el registro de Orden de Combinación
        /// </summary>
        /// <param name="register">Orden de Combinación</param>
        /// <returns>Indicador de Conformidad</returns>
        public string RegisterCombinationOrder(CombinationOrderRequest register)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CombinationOrderContext).FullName);


            ProcessResult<string> result = new ProcessResult<string>();
            try
            {
                register.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                register.UserCreation = yanbalSession.User.Login;
                register.TerminalCreation = yanbalSession.User.Ip;
                result = policyDomain.CombinationOrderRegister(register);
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
            return result.Result;
        } 

        /// <summary>
        /// Permite la modificación de Orden de Combinación
        /// </summary>
        /// <param name="register">Orden de Combinación</param>
        /// <returns>Indicador de Conformidad</returns>
        public string ModifyCombinationOrder(CombinationOrderRequest register)
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CombinationOrderContext).FullName);

            ProcessResult<string> result = new ProcessResult<string>();
            try
            {
                register.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                register.UserModification = yanbalSession.User.Login;
                register.TerminalModification = yanbalSession.User.Ip;
                register.RegistrationStatus = Enumerated.RegistrationStatus.Cancelled;
                result = policyDomain.CombinationOrderUpdate(register);
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
            return result.Result;
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
                ParameterSystemIndicator = false,
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult)
            {
                listSelect.Add(new SelectType() { Id = Convert.ToString(item.CodeParameter), Name = item.NameParameter });
            }
            return listSelect;
        }
        #endregion

    }
}
