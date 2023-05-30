using System.Web.Mvc;
using Yanbal.SFT.FreightManager.Domain.Wrappers;
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
    /// Controladora de la opción Simulador
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140910 <br />
    /// Modificación: 
    /// </remarks>
    [SystemAuthentication]
    public class SimulatorController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public SimulatorController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Simulador
        /// </summary>
        /// <returns>Vista principal de la opción Orden de Combinación</returns>
        [CustomHandleError(typeof(CombinationModel))]
        public ActionResult Index()
        {
            var simulatorModel = new SimulatorContext(SessionContext.GetYanbalSession()).Index();
            return View(simulatorModel);
        }
        #endregion

        #region JsonResult

        /// <summary>
        /// Permite realizar la modificación de Orden de Combinación
        /// </summary>
        /// <param name="request">Orden de Simulador</param>
        /// <returns>Json con el indicador de conformidad</returns>
        public JsonResult Simulate(FreightRequest request)
        {
            var response = new SimulatorContext(SessionContext.GetYanbalSession()).Simulate(request);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar la búsqueda de Zona de Nivel 1
        /// </summary>
        /// <param name="codeZoneLevel1">Código de Zona de Nivel 1</param>
        /// <returns>Json con la lista de Zonas de Nivel 2</returns>
        [CustomHandleError()]
        public JsonResult ChangeZoneLevel1(string codeZoneLevel1)
        {
            var result = new SimulatorContext(SessionContext.GetYanbalSession()).GetListCity(codeZoneLevel1);
            return Json(result);
        }

        /// <summary>
        /// Permite realizar la búsqueda de Zona de Nivel 2
        /// </summary>
        /// <param name="codeZoneLevel1">Código de Zona de Nivel 1</param>
        /// <param name="codeZoneLevel2">Código de Zona de Nivel 2</param>
        /// <returns>Json con la lista de Zonas de Nivel 2</returns>
        [CustomHandleError()]
        public JsonResult ChangeZoneLevel2(string codeZoneLevel1, string codeZoneLevel2)
        {
            var result = new SimulatorContext(SessionContext.GetYanbalSession()).GetListDistrict(codeZoneLevel1, codeZoneLevel2);
            return Json(result);
        }
        #endregion
    }
}
