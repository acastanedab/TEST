namespace Yanbal.SFT.Presentation.Web.Source.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Web.Mvc;
    using Yanbal.SFT.Infrastructure.CrossCutting.Log;
    using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
    using Yanbal.SFT.Presentation.Web.Source.Models.Base;
    using Yanbal.SFT.Presentation.Web.Source.Session;
    using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;

    /// <summary>
    /// Model Login
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140715 <br />
    /// Modificacion: 
    /// </remarks>

    public class CustomHandleError : HandleErrorAttribute
    {
        /// <summary>
        /// Tipo de Modelo
        /// </summary>
        public Type typeModel { get; set; }

        /// <summary>
        /// Manejador de Error
        /// </summary>
        /// <param name="typeModel">Tipo de Modelo</param>
        public CustomHandleError(Type typeModel) { this.typeModel = typeModel; }

        /// <summary>
        /// Manejador de Error
        /// </summary>
        public CustomHandleError() { }

        /// <summary>
        /// Excepción
        /// </summary>
        /// <param name="exceptionContext">Contexto de Excepción</param>
        public override void OnException(ExceptionContext exceptionContext)
        {
            YanbalSession yanbalSession = SessionContext.GetYanbalSession();
            string actionName = exceptionContext.RouteData.Values["action"].ToString();
            string controllerName = exceptionContext.Controller.ToString();
            Type controllerType = exceptionContext.Controller.GetType();
            var method = controllerType.GetMethod(actionName);
            var returnType = method.ReturnType;
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = !string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? yanbalSession.BusinessUnit.CountryCode : string.Empty;
            StackTrace tracenom = new StackTrace();
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CustomHandleError).FullName);
            ILogging ilog4Net = new Logging();

            //TO DO : pendiente de definir ubicacion
            ILogging logging = new Logging();
            logging.Add(exceptionContext.Exception.Message, System.Diagnostics.TraceEventType.Error, "Controller: " + controllerName + " - " + "Action: " + actionName);
            /*Error*/
            ilog4Net.AddLog4Net(string.Concat("Ingresó a exceptionContext: ", "actionName: ", actionName), traceOrder, LogLevel.INFO.ToString());

            var model2 = new HandleErrorInfo(exceptionContext.Exception, "Error", "File");
            var result = new ViewResult
            {
                ViewName = "Error",
                MasterName = "",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model2),
                TempData = exceptionContext.Controller.TempData
            };
            /*---------*/
            dynamic model = null;

            if (typeModel != null)
            {

                model = Activator.CreateInstance(typeModel);
                model.Error.Code = 1;
                model.Error.Message = exceptionContext.Exception.Message;
            }
            else
            {
                model = new ErrorModel { Code = 1, Message = exceptionContext.Exception.Message };
            }

            var mensajeErrorLog = $"{exceptionContext.Exception.Message} - stackTrace {exceptionContext.Exception.StackTrace} - innerException {exceptionContext.Exception.InnerException} ";
            ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());

            if (returnType.Equals(typeof(ActionResult)))
            {

                exceptionContext.Result = result;
                exceptionContext.ExceptionHandled = true;
                return;

            }

            //TO DO PENDIENTE DEFINIR COMO MOSTRAR EL ERROR EN LLAMADAS AJAX
            if (returnType.Equals(typeof(JsonResult)))
            {
                exceptionContext.Result = new JsonResult()
                {
                    Data = new { Error = model }
                };
            }

            exceptionContext.ExceptionHandled = true;


        }
    }
}
