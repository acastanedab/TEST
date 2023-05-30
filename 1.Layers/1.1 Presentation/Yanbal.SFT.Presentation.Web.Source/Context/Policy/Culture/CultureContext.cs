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

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.Culture
{
    /// <summary>
    /// Contexto de la vista de Cultura
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140922 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class CultureContext
    {
        #region Properties
        //Inicio Sonar 15/08/2016
        readonly YanbalSession yanbalSession;
        readonly IPolicyDomain policyDomain;
        //Fin Sonar
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de implementación de la clase
        /// </summary>
        /// <param name="yanbalSession">Objeto mantenido en Sesión</param>
        public CultureContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            this.policyDomain = new PolicyDomain();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Cultura
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public CultureModel Index()
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            CultureModel cultureModel = new CultureModel();
            try
            {
                string controllerName = "Culture";
                cultureModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

                cultureModel.ListLanguage = GetListLanguage();
                cultureModel.ListCountry = GetListCountry();

                cultureModel.Search = new ButtonControl();
                cultureModel.Search.Id = "btnSearch";
                BaseContext.GetAccessControl(cultureModel.Search.Id, controllerName, cultureModel.Search);

                cultureModel.Create = new ButtonControl();
                cultureModel.Create.Id = "btnCreate";
                BaseContext.GetAccessControl(cultureModel.Create.Id, controllerName, cultureModel.Create);

                cultureModel.Edit = new ImageControl();
                cultureModel.Edit.Id = "ibtEdit";
                BaseContext.GetAccessControl(cultureModel.Edit.Id, controllerName, cultureModel.Edit);
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
            return cultureModel;
        }

        /// <summary>
        /// Permite la búsqueda de Cultura
        /// </summary>
        /// <param name="cultureRequest">Cultura</param>
        /// <returns>Lista de Cultura</returns>
        public List<CultureEL> Search(CultureRequest cultureRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            List<CultureEL> cultureEl = new List<CultureEL>();
           
            try
            {
                if (yanbalSession.ListRegistrationStatus != null && yanbalSession.ListRegistrationStatus.Count > 0)
                {
                    cultureRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                    cultureEl = policyDomain.CultureSearch(cultureRequest).Result;
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return (cultureEl);
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para registrar Cultura
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public CultureModel Create()
        {
            Exception exc;
            ArgumentNullException exArg;
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            CultureModel cultureModel = new CultureModel();
           
            try
            {
                string controllerName = "Culture";
                cultureModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                cultureModel.LabelRegistrationStatus = ((cultureModel.ListRegistrationStatus.Count <= 0) ? "" : cultureModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());

                cultureModel.ListLanguage = GetListLanguage();
                cultureModel.ListCountry = GetListCountry();
                cultureModel.ListShortDateFormat = GetListStringFormat(Enumerated.TypeFormatString.Date, Enumerated.TypeFormatString.Short);
                cultureModel.ListLongDateFormat = GetListStringFormat(Enumerated.TypeFormatString.Date, Enumerated.TypeFormatString.Long);
                cultureModel.ListShortTimeFormat = GetListStringFormat(Enumerated.TypeFormatString.Time, Enumerated.TypeFormatString.Short);
                cultureModel.ListLongTimeFormat = GetListStringFormat(Enumerated.TypeFormatString.Time, Enumerated.TypeFormatString.Long);
                cultureModel.ListFormatIntegerNumber = GetListStringFormat(Enumerated.TypeFormatString.Integer, null);
                cultureModel.ListFormatDecimalNumber = GetListStringFormat(Enumerated.TypeFormatString.Decimal, null);

                cultureModel.Save = new ButtonControl();
                cultureModel.Save.Id = "btnSave";
                BaseContext.GetAccessControl(cultureModel.Save.Id, controllerName, cultureModel.Save);

                cultureModel.Cancel = new ButtonControl();
                cultureModel.Cancel.Id = "btnCancel";
                BaseContext.GetAccessControl(cultureModel.Cancel.Id, controllerName, cultureModel.Cancel);
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
            return cultureModel;
        }

        /// <summary>
        /// Permite el registro de Cultura
        /// </summary>
        /// <param name="cultureRequest">Cultura</param>
        /// <returns>Indicador de conformidad</returns>
        public string RegisterCulture(CultureRequest cultureRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ProcessResult<string> result = new ProcessResult<string>();
            try
            {
                cultureRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                cultureRequest.UserCreation = yanbalSession.User.Login;
                cultureRequest.TerminalCreation = yanbalSession.User.Ip;
                result = policyDomain.CultureRegister(cultureRequest);
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return result.Result;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Cultura
        /// </summary>
        /// <param name="cultureCode">Código de Cultura</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public CultureModel Edit(string cultureCode)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            CultureModel cultureModel = new CultureModel();
            try
            {
                
                string controllerName = "Culture";
                cultureModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                cultureModel.ListLanguage = GetListLanguage();
                cultureModel.ListCountry = GetListCountry();
                cultureModel.ListShortDateFormat = GetListStringFormat(Enumerated.TypeFormatString.Date, Enumerated.TypeFormatString.Short);
                cultureModel.ListLongDateFormat = GetListStringFormat(Enumerated.TypeFormatString.Date, Enumerated.TypeFormatString.Long);
                cultureModel.ListShortTimeFormat = GetListStringFormat(Enumerated.TypeFormatString.Time, Enumerated.TypeFormatString.Short);
                cultureModel.ListLongTimeFormat = GetListStringFormat(Enumerated.TypeFormatString.Time, Enumerated.TypeFormatString.Long);
                cultureModel.ListFormatIntegerNumber = GetListStringFormat(Enumerated.TypeFormatString.Integer, null);
                cultureModel.ListFormatDecimalNumber = GetListStringFormat(Enumerated.TypeFormatString.Decimal, null);

                CultureEL cultureEl = policyDomain.CultureSearch(new CultureRequest { BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode, CultureCode = cultureCode }).Result.FirstOrDefault();
                if (cultureEl != null)
                {
                    cultureModel.CultureCode = cultureEl.CultureCode;
                    cultureModel.LanguageCode = cultureEl.LanguageCode;
                    cultureModel.CountryCode = cultureEl.CountryCode;
                    cultureModel.CodeShortDateFormat = cultureEl.CodeShortDateFormat;
                    cultureModel.CodeLongDateFormat = cultureEl.CodeLongDateFormat;
                    cultureModel.CodeShortTimeFormat = cultureEl.CodeShortTimeFormat;
                    cultureModel.CodeLongTimeFormat = cultureEl.CodeLongTimeFormat;
                    cultureModel.CodeFormatIntegerNumber = cultureEl.CodeFormatIntegerNumber;
                    cultureModel.CodeFormatDecimalNumber = cultureEl.CodeFormatDecimalNumber;
                    cultureModel.RegistrationStatus = cultureEl.RegistrationStatus;
                    cultureModel.UpperLimitYear = cultureEl.UpperLimitYear;
                    if (cultureEl.UpperLimitYear != null)
                        cultureModel.LowerLimitYear = (Convert.ToInt16(cultureEl.UpperLimitYear - 99));
                    else
                        cultureModel.LowerLimitYear = null;
                }

                cultureModel.Save = new ButtonControl();
                cultureModel.Save.Id = "btnSaveEdit";
                BaseContext.GetAccessControl(cultureModel.Save.Id, controllerName, cultureModel.Save);

                cultureModel.Cancel = new ButtonControl();
                cultureModel.Cancel.Id = "btnCancelEdit";
                BaseContext.GetAccessControl(cultureModel.Cancel.Id, controllerName, cultureModel.Cancel);
            }
            catch(Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return cultureModel;
        }

        /// <summary>
        /// Permite la modificación de Cultura
        /// </summary>
        /// <param name="cultureRequest">Cultura</param>
        /// <returns>Indicador de conformidad</returns>
        public string ModifyCulture(CultureRequest cultureRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ProcessResult<string> result = new ProcessResult<string>();
            try
            {
                cultureRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                cultureRequest.UserModification = yanbalSession.User.Login;
                cultureRequest.TerminalModification = yanbalSession.User.Ip;
                result = policyDomain.CultureUpdate(cultureRequest);
            }
            catch (Exception ex)
            {
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

        private List<SelectType> GetListStringFormat(string formatType, bool? longFormat)
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.StringFormatSearch(new StringFormatRequest() { FormatType = formatType, LongFormat = longFormat }).Result;

            foreach (var item in listResult)
            {
                listSelect.Add(new SelectType() { Id = Convert.ToString(item.StringFormatCode), Name = item.Format });
            }
            return listSelect;
        }

        /// <summary>
        /// Adaptador de lista de opciones a lista de combos
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListLanguage()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.LanguageSearch(new LanguageRequest() { RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

            foreach (var item in listResult)
            {
                listSelect.Add(new SelectType() { Id = item.LanguageCode, Name = item.Name });
            }
            return listSelect;
        }
        #endregion
    }
}
