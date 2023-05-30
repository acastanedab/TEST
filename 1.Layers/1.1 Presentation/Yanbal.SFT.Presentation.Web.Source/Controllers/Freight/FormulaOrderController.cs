using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Freight.FormulaOrder;
using Yanbal.SFT.Presentation.Web.Source.Models.Freight;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Freight
{
    /// <summary>
    /// Controladora de la opción Orden de Combinación
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140910 <br />
    /// Modificación: 
    /// </remarks>
    [SystemAuthentication]
    public class FormulaOrderController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FormulaOrderController()
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
            var combinationOrderModel = new FormulaOrderContext(SessionContext.GetYanbalSession()).Index();
            return View(combinationOrderModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de modificación de Orden de Combinación
        /// </summary>
        /// <param name="formulaCode">Código de Orden de Combinación</param>
        /// <returns>Vista parcial de modificación de Orden de Combinación</returns>
        public ActionResult Edit(int formulaCode)
        {
            var combinationOrderModel = new FormulaOrderContext(SessionContext.GetYanbalSession()).Edit(formulaCode);
            return PartialView("Edit", combinationOrderModel);
        }
        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Orden de Combinación
        /// </summary>
        /// <param name="filterSearch">Orden de Combinación</param>
        /// <returns>Json con la lista de Orden de Combinación</returns>
        public JsonResult Search(FormulaRequest filterSearch)
        {
            var response = new FormulaOrderContext(SessionContext.GetYanbalSession()).Search(filterSearch);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar el registro de Orden de Combinación
        /// </summary>
        /// <param name="formulaRequest">Orden de Combinación</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult RegisterFormulaOrder(FormulaRequest formulaRequest)
        {
            var result = new FormulaOrderContext(SessionContext.GetYanbalSession()).RegisterFormulaOrder(formulaRequest);
            return Json(result);
        }

        /// <summary>
        /// Permite realizar la modificación de Orden de Combinación
        /// </summary>
        /// <param name="formulaRequest">Orden de Combinación</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult ModifyFormulaOrder(FormulaRequest formulaRequest)
        {
            var result = new FormulaOrderContext(SessionContext.GetYanbalSession()).ModifyFormulaOrder(formulaRequest);
            return Json(result);
        }
        #endregion
    }
}
