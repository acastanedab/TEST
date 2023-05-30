using System.Web.Mvc;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Freight.Combination;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.AuditReport;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.UbigeoZoneType;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.General
{
    /// <summary>
    /// Contoladora de la vista de Reporte de Visualización
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140916 <br />
    /// Modificación:          <br />
    /// </remarks>
    //[SFTAuthentication]
    public class ReportController : BaseController
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ReportController()
        {
        }

        /// <summary>
        /// Permite la Visualización de la Vista Index
        /// </summary>
        /// <param name="filter">Reporte de Auditoría</param>
        /// <returns>Vista principal de la opción Reporte de Auditoría</returns> 
        [HttpPost]
        public ActionResult AuditPolicy(AuditReportRequest filter)
        {
            var model = new AuditReportContext(SessionContext.GetYanbalSession()).Report(filter);
            return View("Index", model);
        }

        /// <summary>
        /// Permite la Visualización de la Vista Index
        /// </summary>
        /// <param name="filter">Reporte de Auditoría</param>
        /// <returns>Vista principal de la opción Reporte de Auditoría</returns> 
        [HttpPost]
        public ActionResult AllocationAreas(UbigeoZoneTypeRequest filter)
        {
            var model = new UbigeoZoneTypeContext(SessionContext.GetYanbalSession()).Report(filter);
            return View("Index", model);
        }

        /// <summary>
        /// Permite la Visualización de la Vista Index
        /// </summary>
        /// <param name="filter">Reporte de Auditoría</param>
        /// <returns>Vista principal de la opción Reporte de Auditoría</returns> 
        [HttpPost]
        public ActionResult Combination(CombinationRequest filter)
        {
            var model = new CombinationContext(SessionContext.GetYanbalSession()).Report(filter);
            return View("Index", model);
        }

    }
}
