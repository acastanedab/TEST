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
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.Culture;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controladora de la opción Cultura
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140922 <br />
    /// Modificación:          <br /> 
    /// </remarks>
    [SystemAuthentication]
    public class CultureController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CultureController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Cultura
        /// </summary>
        /// <returns>Vista Principal de la opción Cultura</returns>
        [CustomHandleError(typeof(CultureModel))]
        public ActionResult Index()
        {
            CultureModel cultureModel = new CultureContext(SessionContext.GetYanbalSession()).Index();
            return View(cultureModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de registro de Cultura
        /// </summary>
        /// <param name="cultureEl">Cultura</param>
        /// <returns>Vista parcial del registro de Cultura</returns>
        [CustomHandleError(typeof(CultureModel))]
        public ActionResult Create(CultureEL cultureEl)
        {
            CultureModel cultureModel = new CultureContext(SessionContext.GetYanbalSession()).Create();
            cultureModel.CountryCode = cultureEl.CountryCode;
            cultureModel.LanguageCode = cultureEl.LanguageCode;
            return PartialView("Create", cultureModel);
        }

        /// <summary>
        /// Muestra la vista de modificación de Cultura
        /// </summary>
        /// <param name="cultureCode">Código de Cultura</param>
        /// <returns>Vista parcial de modificación de Cultura</returns>
        [CustomHandleError(typeof(CultureModel))]
        public ActionResult Edit(string cultureCode)
        {
            CultureModel cultureModel = new CultureContext(SessionContext.GetYanbalSession()).Edit(cultureCode);
            return PartialView("Edit", cultureModel);
        }

        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Cultura
        /// </summary>
        /// <param name="cultureRequest">Cultura</param>
        /// <returns>Json con la lista de Cultura</returns>
        [CustomHandleError()]
        public JsonResult Search(CultureRequest cultureRequest)
        {
            List<CultureEL> response = new CultureContext(SessionContext.GetYanbalSession()).Search(cultureRequest);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar el registro de Cultura
        /// </summary>
        /// <param name="cultureRequest">Cultura</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult RegisterCulture(CultureRequest cultureRequest)
        {
            var response = new CultureContext(SessionContext.GetYanbalSession()).RegisterCulture(cultureRequest);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar la modificación de Cultura
        /// </summary>
        /// <param name="cultureRequest">Cultura</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult ModifyCulture(CultureRequest cultureRequest)
        {
            var response = new CultureContext(SessionContext.GetYanbalSession()).ModifyCulture(cultureRequest);
            return Json(response);
        }
        #endregion
    }
}
