using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.AuditReport;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controladora de la opción Reporte de Auditoría
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140916 <br />
    /// Modificación: 	 <br />
    /// </remarks>
    [SystemAuthentication]
    public class AuditReportController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public AuditReportController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Reporte de Auditoría
        /// </summary>
        /// <returns>Vista principal de la opción Reporte de Auditoría</returns>
        public ActionResult Index()
        {
            AuditReportModel auditReportModel = new AuditReportContext(SessionContext.GetYanbalSession()).Index();
            return View(auditReportModel);
        }
        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Columnas de Tablas
        /// </summary>
        /// <param name="tableCode">Código de Tabla</param>
        /// <returns>Json con la lista de Columnas de Tablas</returns>
        public JsonResult ChangeAuditTable(int? tableCode)
        {
            int inputTableCode = (tableCode != null) ? Convert.ToInt32(tableCode) : 0;
            List<SelectType> result = new AuditReportContext(SessionContext.GetYanbalSession()).ChangeAuditTable(inputTableCode);
            return Json(result);
        }
        #endregion
    }
}
