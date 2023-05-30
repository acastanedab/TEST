using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Yanbal.SFT.FreightManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.TaxProfile;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controladora de la opción Perfil de Impuesto Tributario
    /// </summary>
    /// <remarks>
    /// Creación: GMD(FHP) 26082014 <br />
    /// Modificación:
    /// </remarks>
    public class TaxProfileController  :BaseController
    {

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Perfil de Impuesto Tributario
        /// </summary>
        /// <returns>Vista principal de la opción Perfil de Impuesto Tributario</returns>
        [CustomHandleError(typeof(TaxProfileModel))]
        public ActionResult Index()
        {
            TaxProfileModel taxProfileModel = new TaxProfileContext(SessionContext.GetYanbalSession()).Index();
            return View(taxProfileModel);
        }
        #endregion

        #region JsonResult

        [CustomHandleError()]
        public JsonResult Search(TaxProfileRequest filterSearch)
        {
            var response = new TaxProfileContext(SessionContext.GetYanbalSession()).Search(filterSearch);
            return Json(response);
        }
            
        #endregion
    }
}