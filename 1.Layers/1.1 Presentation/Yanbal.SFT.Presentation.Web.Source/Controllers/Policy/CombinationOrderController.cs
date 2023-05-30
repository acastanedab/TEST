using System.Collections.Generic;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.CombinationOrder;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controladora de la opción Orden de Combinación
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140910 <br />
    /// Modificación: 
    /// </remarks>
    [SystemAuthentication]
    public class CombinationOrderController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CombinationOrderController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Orden de Combinación
        /// </summary>
        /// <returns>Vista principal de la opción Orden de Combinación</returns>
        public ActionResult Index()
        {
            CombinationOrderModel combinationOrderModel = new CombinationOrderContext(SessionContext.GetYanbalSession()).Index();
            return View(combinationOrderModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de modificación de Orden de Combinación
        /// </summary>
        /// <param name="orderCodeCombination">Código de Orden de Combinación</param>
        /// <returns>Vista parcial de modificación de Orden de Combinación</returns>
        public ActionResult Edit(int orderCodeCombination)
        {
            CombinationOrderModel combinationOrderModel = new CombinationOrderContext(SessionContext.GetYanbalSession()).Edit(orderCodeCombination);
            return PartialView("Edit", combinationOrderModel);
        }
        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Orden de Combinación
        /// </summary>
        /// <param name="filterSearch">Orden de Combinación</param>
        /// <returns>Json con la lista de Orden de Combinación</returns>
        public JsonResult Search(CombinationOrderRequest filterSearch)
        {
            List<CombinationOrderEL> response = new CombinationOrderContext(SessionContext.GetYanbalSession()).Search(filterSearch);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar el registro de Orden de Combinación
        /// </summary>
        /// <param name="combinationOrderRequest">Orden de Combinación</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult RegisterCombinationOrder(CombinationOrderRequest combinationOrderRequest)
        {
            var result = new CombinationOrderContext(SessionContext.GetYanbalSession()).RegisterCombinationOrder(combinationOrderRequest);
            return Json(result);
        }

        /// <summary>
        /// Permite realizar la modificación de Orden de Combinación
        /// </summary>
        /// <param name="combinationOrderRequest">Orden de Combinación</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult ModifyCombinationOrder(CombinationOrderRequest combinationOrderRequest)
        {
            var result = new CombinationOrderContext(SessionContext.GetYanbalSession()).ModifyCombinationOrder(combinationOrderRequest);
            return Json(result);
        }
        #endregion
    }
}
