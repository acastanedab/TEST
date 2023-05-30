using System.Web.Mvc;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Freight.Combination;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Freight;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Freight
{
    /// <summary>
    /// Controladora de la opción Combinación
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140904 <br />
    /// Modificación: 
    /// </remarks>
    [SystemAuthentication]
    public class CombinationController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CombinationController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Combination
        /// </summary>
        /// <returns>Vista principal de la opción Combinación</returns>
        [CustomHandleError(typeof(CombinationModel))]
        public ActionResult Index()
        {
            CombinationModel combinationModel = new CombinationContext(SessionContext.GetYanbalSession()).Index();
            return View(combinationModel);
        }
        #endregion

        #region PartialView
        /// <summary>
        /// Muestra la vista de registro de Combinación
        /// </summary>
        /// <returns>Vista parcial del registro de Combinación</returns>
        public ActionResult Create()
        {
            CombinationModel combinationModel = new CombinationContext(SessionContext.GetYanbalSession()).Create();
            return PartialView("Create", combinationModel);
        }

        /// <summary>
        /// Muestra la vista de registro de Combinación de Parámetros
        /// </summary>
        /// <param name="register">Combinación</param>
        /// <returns>Vista parcial del registro de Combinación de Parámetros</returns>
        public ActionResult CreateParameterCombination(CombinationRequest register)
        {
            CombinationModel combinationModel = new CombinationContext(SessionContext.GetYanbalSession()).CreateParameterCombination();
            return PartialView("CreateParameterCombination", combinationModel);
        }
        
        /// <summary>
        /// Muestra la vista de modificación de Combinación
        /// </summary>
        /// <param name="codeCombination">Código de Combinación</param>
        /// <returns>Vista parcial de modificación de Combinación</returns>
        public ActionResult Edit(int codeCombination)
        {
            CombinationModel combinationModel = new CombinationContext(SessionContext.GetYanbalSession()).Edit(codeCombination);
            return PartialView("Edit", combinationModel);
        }

        /// <summary>
        /// Muestra la vista de modificación de Combinación de Parámetros
        /// </summary>
        /// <param name="codeCombination">Código de Combinación</param>
        /// <returns>Vista parcial de modificación de Combinación de Parámetros</returns>
        public ActionResult EditParameterCombination(int codeCombination)
        {
            CombinationModel combinationModel = new CombinationContext(SessionContext.GetYanbalSession()).EditParameterCombination(codeCombination);
            return PartialView("EditParameterCombination", combinationModel);
        }
        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Combinación
        /// </summary>
        /// <param name="filterSearch">Combinación</param>
        /// <returns>Json con la lista de Combinación</returns>
        public JsonResult Search(CombinationRequest filterSearch)
        {
            var response = new CombinationContext(SessionContext.GetYanbalSession()).Search(filterSearch);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar el registro de Combinación y Combinación de Parámetros
        /// </summary>
        /// <param name="combinationRequest">Combinación</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult RegisterCombination(CombinationRequest combinationRequest)
        {
            var response = new CombinationContext(SessionContext.GetYanbalSession()).RegisterCombination(combinationRequest);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar la modificación de Combinación
        /// </summary>
        /// <param name="register">Combinación</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult ModifyCombination(CombinationRequest register)
        {
            var response = new CombinationContext(SessionContext.GetYanbalSession()).ModifyCombination(register);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar la modificación de Combinación
        /// </summary>
        /// <param name="register">Combinación</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult ModifyParameterCombination(CombinationRequest register)
        {
            var response = new CombinationContext(SessionContext.GetYanbalSession()).ModifyParameterCombination(register);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar el cambio de Parámetro Valor
        /// </summary>
        /// <param name="codeParameter">Código de Parámetro</param>
        /// <returns>Json con Lista de Parámetro Valor</returns>
        public JsonResult ChangeParameterValue(int codeParameter)
        {
            var response = new CombinationContext(SessionContext.GetYanbalSession()).GetListParameterValue(codeParameter);
            return Json(response);
        }
        #endregion
    }
}
