using System.Web.Mvc;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.ParameterValue;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controladora de la opción Valor de Parámetro
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140826 <br />
    /// Modificación:
    /// </remarks>
    [SystemAuthentication]
    public class ParameterValueController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterValueController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Valor de Parámetro
        /// </summary>
        /// <returns>Vista principal de la opción Valor de Parámetro</returns>
        [CustomHandleError(typeof(ParameterValueModel))]
        public ActionResult Index()
        {
            ParameterValueModel parameterValueModel = new ParameterValueContext(SessionContext.GetYanbalSession()).Index();
            return View(parameterValueModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de registro de Valor de Parámetro
        /// </summary>
        /// <param name="code">Código de Parámetro</param>
        /// <returns>Vista parcial de registro de Valor de Parámetro</returns>
        [CustomHandleError(typeof(ParameterValueModel))]
        public ActionResult Create(string code)
        {
            ParameterValueModel parameterValueModel = new ParameterValueContext(SessionContext.GetYanbalSession()).Create(code);
            return PartialView("Create", parameterValueModel);
        }

        /// <summary>
        /// Muestra la vista de registro de Valor de Parámetro
        /// </summary>
        /// <param name="codeParameter">Código de Parámetro</param>
        /// <param name="codeParameterValue">Código de Parámetro Valor</param>
        /// <returns>Vista parcial de registro de Valor de Parámetro</returns>
        [CustomHandleError(typeof(ParameterValueModel))]
        public ActionResult Edit(int codeParameter,int codeParameterValue)
        {
            ParameterValueModel parameterValueModel = new ParameterValueContext(SessionContext.GetYanbalSession()).Edit(codeParameter, codeParameterValue);
            return PartialView("Edit", parameterValueModel);
        }
        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Valor de Parámetro
        /// </summary>
        /// <param name="filterSearch">Valor de Parámetro</param>
        /// <returns>Json con la lista de Valor de Parámetro</returns>
        [CustomHandleError()]
        public JsonResult Search(ParameterValueRequest filterSearch)
        {
            var response = new ParameterValueContext(SessionContext.GetYanbalSession()).Search(filterSearch);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar el registro de Valor de Parámetro
        /// </summary>
        /// <param name="parameterValueRequest">Valor de Parámetro</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult RegisterParameterValue(ParameterValueRequest parameterValueRequest)
        {
            string result = new ParameterValueContext(SessionContext.GetYanbalSession()).Register(parameterValueRequest);
            return Json(result);
        }

        /// <summary>
        /// Permite realizar la modificación de Valor de Parámetro
        /// </summary>
        /// <param name="parameterValueRequest">Valor de Parámetro</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult ModifyParameterValue(ParameterValueRequest parameterValueRequest)
        {
            string result = new ParameterValueContext(SessionContext.GetYanbalSession()).Modify(parameterValueRequest);
            return Json(result);
        }
        #endregion
    }
}