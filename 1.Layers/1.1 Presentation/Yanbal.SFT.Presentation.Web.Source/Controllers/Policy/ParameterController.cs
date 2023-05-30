using System.Collections.Generic;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.Parameter;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controladora de la opción Parámetro
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140718 <br />
    /// Modificación: 
    /// </remarks>
    [SystemAuthentication]
    public class ParameterController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Parámetro
        /// </summary>
        /// <param name="indicatorFilterCleaning">Indicador de Filtro de Búsqueda</param>
        /// <returns>Vista principal de la opción Parámetro</returns>
        [CustomHandleError(typeof(ParameterModel))]
        public ActionResult Index(int? indicatorFilterCleaning)
        {
            if (indicatorFilterCleaning != 1)
            {
                YanbalSession yanbalSession = SessionContext.GetYanbalSession();
                yanbalSession.FilterParameterRequest = null;
                SessionContext.SetYanbalSession(yanbalSession);
            }
            ParameterModel parameterModel = new ParameterContext(SessionContext.GetYanbalSession()).Index();
            return View(parameterModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de registro de Parámetro
        /// </summary>
        /// <returns>Vista parcial del registro de Parámetro</returns>
        [CustomHandleError(typeof(ParameterModel))]
        public ActionResult Create()
        {
            ParameterModel parameterModel = new ParameterContext(SessionContext.GetYanbalSession()).Create();
            return PartialView("Create", parameterModel);
        }

        /// <summary>
        /// Muestra la vista de modificación de Parámetro
        /// </summary>
        /// <param name="codeParameter">Código de Parámetro</param>
        /// <returns>Vista parcial de modificación de Parámetro</returns>
        [CustomHandleError(typeof(ParameterModel))]
        public ActionResult Edit(int codeParameter)
        {
            ParameterModel parameterModel = new ParameterContext(SessionContext.GetYanbalSession()).Edit(codeParameter);
            return PartialView("Edit", parameterModel);
        }
        #endregion

        #region JsonResults
        /// <summary>
        /// Permite realizar la búsqueda de Parámetro
        /// </summary>
        /// <param name="filterSearch">Parámetro</param>
        /// <returns>Json con la lista de Parámetro</returns>
        [CustomHandleError()]
        public JsonResult Search(ParameterRequest filterSearch)
        {
            YanbalSession yanbalSession = SessionContext.GetYanbalSession();
            yanbalSession.FilterParameterRequest = filterSearch;
            SessionContext.SetYanbalSession(yanbalSession);

            List<ParameterEL> response = new ParameterContext(SessionContext.GetYanbalSession()).Search(filterSearch);
            return Json(response);
        }


        /// <summary>
        /// Permite realizar el registro de Parámetro
        /// </summary>
        /// <param name="parameterRequest">Parámetro</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult RegisterParameter(ParameterRequest parameterRequest)
        {
            string result = new ParameterContext(SessionContext.GetYanbalSession()).Register(parameterRequest);
            return Json(result);
        }

        /// <summary>
        /// Permite realizar la modificación de Parámetro
        /// </summary>
        /// <param name="parameterRequest">Parámetro</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult ModifyParameter(ParameterRequest parameterRequest)
        {
            string result = new ParameterContext(SessionContext.GetYanbalSession()).Modify(parameterRequest); 
            return Json(result);
        }
        #endregion
    }
}
