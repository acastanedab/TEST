using System.Collections.Generic;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.BusinessUnit;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controladora de la opción Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140917 <br />
    /// Modificación: 	       <br />
    /// </remarks>
    [SystemAuthentication]
    public class BusinessUnitController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BusinessUnitController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Unidad de Negocio
        /// </summary>
        /// <param name="indicatorFilterCleaning">Indicador de Filtro de Búsqueda</param>
        /// <returns>Vista principal de la opción Unidad de Negocio</returns>
        [CustomHandleError(typeof(BusinessUnitModel))]
        public ActionResult Index(int? indicatorFilterCleaning)
        {
            if (indicatorFilterCleaning != 1)
            {
                YanbalSession yanbalSession = SessionContext.GetYanbalSession();
                yanbalSession.FilterParameterRequest = null;
                SessionContext.SetYanbalSession(yanbalSession);
            }
            BusinessUnitModel businessUnitModel = new BusinessUnitContext(SessionContext.GetYanbalSession()).Index();
            return View(businessUnitModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de registro de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnit">Unidad de Negocio</param>
        /// <returns>Vista parcial de registro de Unidad de Negocio</returns>
        [CustomHandleError(typeof(BusinessUnitModel))]
        public ActionResult Create(BusinessUnitRequest businessUnit)
        {
            BusinessUnitModel businessUnitModel = new BusinessUnitContext(SessionContext.GetYanbalSession()).Create();
            businessUnitModel.CountryCode = businessUnit.CountryCode;
            return PartialView("Create", businessUnitModel);
        }

        /// <summary>
        /// Muestra la vista de modificación de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <returns>Vista parcial de modificación de Unidad de Negocio</returns>
        [CustomHandleError(typeof(BusinessUnitModel))]
        public ActionResult Edit(int businessUnitCode)
        {
            BusinessUnitModel businessUnitModel = new BusinessUnitContext(SessionContext.GetYanbalSession()).Edit(businessUnitCode);
            return PartialView("Edit", businessUnitModel);
        }
        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitRequest">Unidad de Negocio</param>
        /// <returns>Json con la lista de Unidad de Negocio</returns>
        [CustomHandleError()]
        public JsonResult Search(BusinessUnitRequest businessUnitRequest)
        {
            YanbalSession yanbalSession = SessionContext.GetYanbalSession();
            yanbalSession.FilterBusinessUnitRequest = businessUnitRequest;
            SessionContext.SetYanbalSession(yanbalSession);

            List<BusinessUnitEL> response = new BusinessUnitContext(SessionContext.GetYanbalSession()).Search(businessUnitRequest);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar el registro de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitRequest">Unidad de Negocio</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult RegisterBusinessUnit(BusinessUnitRequest businessUnitRequest)
        {
            var response = new BusinessUnitContext(SessionContext.GetYanbalSession()).RegisterBusinessUnit(businessUnitRequest);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar la modificación de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitRequest">Unidad de Negocio</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult ModifyBusinessUnit(BusinessUnitRequest businessUnitRequest)
        {
            var response = new BusinessUnitContext(SessionContext.GetYanbalSession()).ModifyBusinessUnit(businessUnitRequest);
            return Json(response);
        }
        #endregion
    }
}
