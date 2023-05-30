using System.Collections.Generic;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Freight.Formula;
using Yanbal.SFT.Presentation.Web.Source.Models.Freight;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Freight
{
    /// <summary>
    /// Controladora de la opción Fórmula
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140911 <br />
    /// Modificación:          <br /> 
    /// </remarks>
    [SystemAuthentication]
    public class FormulaController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FormulaController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Fórmula
        /// </summary>
        /// <returns>Vista principal de la opción Fórmula</returns>
        public ActionResult Index()
        {
            FormulaModel formulaModel = new FormulaContext(SessionContext.GetYanbalSession()).Index();
            return View(formulaModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de registro de Fórmula
        /// </summary>
        /// <returns>Vista parcial de registro de Fórmula</returns>
        public ActionResult Create()
        {
            FormulaModel formulaModel = new FormulaContext(SessionContext.GetYanbalSession()).Create();
            return PartialView("Create", formulaModel);
        }

        /// <summary>
        /// Muestra la vista de modificación de Fórmula
        /// </summary>
        /// <param name="formulaCode">Código de Fórmula</param>
        /// <returns>Vista parcial de modificación de Fórmula</returns>
        public ActionResult Edit(int formulaCode)
        {
            FormulaModel formulaModel = new FormulaContext(SessionContext.GetYanbalSession()).Edit(formulaCode);
            return PartialView("Edit", formulaModel);
        }
        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Fórmula
        /// </summary>
        /// <param name="formulaRequest">Fórmula</param>
        /// <returns>Json con la lista de Fórmula</returns>
        public JsonResult Search(FormulaRequest formulaRequest)
        {
            List<FormulaEL> response = new FormulaContext(SessionContext.GetYanbalSession()).Search(formulaRequest);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar el registro de Fórmula
        /// </summary>
        /// <param name="formulaRequest">Fórmula</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult RegisterFormula(FormulaRequest formulaRequest)
        {
            var response = new FormulaContext(SessionContext.GetYanbalSession()).RegisterFormula(formulaRequest);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar la modificación de Fórmula
        /// </summary>
        /// <param name="formulaRequest">Fórmula</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult ModifyFormula(FormulaRequest formulaRequest)
        {
            var response = new FormulaContext(SessionContext.GetYanbalSession()).ModifyFormula(formulaRequest);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar el cambio de Parámetro Valor
        /// </summary>
        /// <param name="parameterCode">Código de Parámetro</param>
        /// <returns>Json con Lista de Parámetro Valor</returns>
        public JsonResult ChangeParameter(int parameterCode)
        {
            var response = new FormulaContext(SessionContext.GetYanbalSession()).GetListParameterValue(parameterCode);
            return Json(response);
        }
        #endregion
    }
}
