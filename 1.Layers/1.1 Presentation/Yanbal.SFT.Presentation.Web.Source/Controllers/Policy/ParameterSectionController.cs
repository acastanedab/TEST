using System.Collections.Generic;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.ParameterSection;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controladora de la opción Sección de Parámetro
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140722 <br />
    /// Modificación:
    /// </remarks>
    [SystemAuthentication]
    public class ParameterSectionController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterSectionController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista inicial de la opción Sección de Parámetro
        /// </summary>
        /// <param name="id">Código de Parámetro</param>
        /// <returns>Vista principal de la opción Sección de Parámetro</returns>
        [CustomHandleError(typeof(ParameterSectionModel))]
        public ActionResult Index(int id)
        {
            ParameterSectionModel objModel = new ParameterSectionContext(SessionContext.GetYanbalSession()).Index(id);
            return View(objModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de registro de Sección de Parámetro
        /// </summary>
        /// <param name="codeParameter">Código de Parámetro</param>
        /// <returns>Vista parcial de registro de Sección de Parámetro</returns>
        [CustomHandleError(typeof(ParameterSectionModel))]
        public ActionResult Create(int codeParameter)
        {
            ParameterSectionModel parameterSectionModel = new ParameterSectionContext(SessionContext.GetYanbalSession()).Create(codeParameter);
            return PartialView("Create", parameterSectionModel);
        }

        /// <summary>
        /// Muestra la vista de modificación de Sección de Parámetro
        /// </summary>Vista parcial de modificación de Sección de Parámetro
        /// <param name="codeParameter">Código de Parámetro</param>
        /// <param name="codeSection">Código de Sección de Parámetro</param>
        /// <returns>Vista parcial de modificación de Sección de Parámetro</returns>
        [CustomHandleError(typeof(ParameterSectionModel))]
        public ActionResult Edit(int codeParameter, int codeSection)
        {
            ParameterSectionModel parameterSectionModel = new ParameterSectionContext(SessionContext.GetYanbalSession()).Edit(codeParameter, codeSection);
            return PartialView("Edit", parameterSectionModel);
        }
        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Sección de Parámetro
        /// </summary>
        /// <param name="parameterSectionRequest">Sección de Parámetro</param>
        /// <returns>Json con la lista de Sección de Parámetro</returns>
        [CustomHandleError(typeof(ParameterSectionModel))]
        public JsonResult Search(ParameterSectionRequest parameterSectionRequest)
        {
            List<ParameterSectionEL> parameterSectionEL = new ParameterSectionContext(SessionContext.GetYanbalSession()).Search(parameterSectionRequest);
            return Json(parameterSectionEL);
        }

        /// <summary>
        /// Permite realizar el registro de Sección de Parámetro
        /// </summary>
        /// <param name="parameterSectionRequest">Sección de Parámetro</param>
        /// <returns>Json con el indicador de confirmación</returns>
        [CustomHandleError()]
        public JsonResult RegisterParameterSection(ParameterSectionRequest parameterSectionRequest)
        {
            string result = new ParameterSectionContext(SessionContext.GetYanbalSession()).Register(parameterSectionRequest);
            return Json(result);
        }

        /// <summary>
        /// Permite realizar la modificación de Sección de Parámetro
        /// </summary>
        /// <param name="parameterSectionRequest">Sección de Parámetro</param>
        /// <returns>Json con el indicador de confirmación</returns>
        [CustomHandleError()]
        public JsonResult ModifyParameterSection(ParameterSectionRequest parameterSectionRequest)
        {
            var result = new ParameterSectionContext(SessionContext.GetYanbalSession()).Modify(parameterSectionRequest);
            return Json(result);
        }
        #endregion
    }
}
