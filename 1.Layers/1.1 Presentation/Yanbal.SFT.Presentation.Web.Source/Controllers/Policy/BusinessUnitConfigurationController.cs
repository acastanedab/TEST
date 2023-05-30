using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.BusinessUnitConfiguration;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controladora de la opción Configuración de Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140918 <br />
    /// Modificación: 	       <br />
    /// </remarks>
    [SystemAuthentication]
    public class BusinessUnitConfigurationController : BaseController
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BusinessUnitConfigurationController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="id">Código de Unidad de Negocio</param>
        /// <returns>Vista Principal de la opción Configuración de Unidad de Negocio</returns>
        [CustomHandleError(typeof(BusinessUnitConfigurationModel))]
        public ActionResult Index(int id)
        {
            BusinessUnitConfigurationModel businessUnitConfigurationModel = new BusinessUnitConfigurationContext(SessionContext.GetYanbalSession()).Index(id);
            return View(businessUnitConfigurationModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de registro de Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitConfigurationRequest">Configuración de Unidad de Negocio</param>
        /// <returns>Vista parcial del registro de Configuración de Unidad de Negocio</returns>
        [CustomHandleError(typeof(BusinessUnitConfigurationModel))]
        public ActionResult Create(BusinessUnitConfigurationRequest businessUnitConfigurationRequest)
        {
            BusinessUnitConfigurationModel businessUnitConfigurationModel = new BusinessUnitConfigurationContext(SessionContext.GetYanbalSession()).Create(businessUnitConfigurationRequest.BusinessUnitCode);
            businessUnitConfigurationModel.OptionalBusinessUnitCode = businessUnitConfigurationRequest.OptionalBusinessUnitCode;
            businessUnitConfigurationModel.CultureCode = businessUnitConfigurationRequest.CultureCode;
            return PartialView("Create", businessUnitConfigurationModel);
        }

        /// <summary>
        /// Muestra la vista de modificación de Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitConfigurationCode">Código de Configuración de Unidad de Negocio</param>
        /// <returns>Vista parcial de modificación de Configuración de Unidad de Negocio</returns>
        [CustomHandleError(typeof(BusinessUnitConfigurationModel))]
        public ActionResult Edit(int businessUnitConfigurationCode)
        {
            BusinessUnitConfigurationModel businessUnitConfigurationModel = new BusinessUnitConfigurationContext(SessionContext.GetYanbalSession()).Edit(businessUnitConfigurationCode);
            return PartialView("Edit", businessUnitConfigurationModel);
        }

        /// <summary>
        /// Permite realizar el registro de Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitConfiguration">Configuración de Unidad de Negocio</param>
        /// <param name="cultureCode">Código de Cultura</param>
        /// <param name="timeZoneCode">Código de Zona Horaria</param>
        /// <param name="charactersMinimumGloss">Mínimo de Caracteres para Glosa</param>
        /// <param name="vowelsMinimumGloss">Mínimo de Vocales para Glosa</param>
        /// <param name="indicatorAcquiringMainMenu">Indicador de Contraer Menú</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult RegisterBusinessUnitConfiguration(string businessUnitConfiguration, string cultureCode, int timeZoneCode, byte? charactersMinimumGloss, byte? vowelsMinimumGloss, bool? indicatorAcquiringMainMenu)
        {
            BusinessUnitConfigurationRequest configuration = Newtonsoft.Json.JsonConvert.DeserializeObject<BusinessUnitConfigurationRequest>(businessUnitConfiguration);
            var result = new BusinessUnitConfigurationContext(SessionContext.GetYanbalSession()).RegisterBusinessUnitConfiguration(configuration, cultureCode, timeZoneCode, charactersMinimumGloss, vowelsMinimumGloss, indicatorAcquiringMainMenu, Request);
            return Json(result);
        }

        /// <summary>
        /// Permite realizar el registro de Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitConfiguration">Configuración de Unidad de Negocio</param>
        /// <param name="cultureCode">Código de Cultura</param>
        /// <param name="timeZoneCode">Código de Zona Horaria</param>
        /// <param name="charactersMinimumGloss">Mínimo de Caracteres para Glosa</param>
        /// <param name="vowelsMinimumGloss">Mínimo de Vocales para Glosa</param>
        /// <param name="indicatorAcquiringMainMenu">Indicador de Contraer Menú</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult ModifyBusinessUnitConfiguration(string businessUnitConfiguration, string cultureCode, int timeZoneCode, byte? charactersMinimumGloss, byte? vowelsMinimumGloss, bool? indicatorAcquiringMainMenu)
        {
            BusinessUnitConfigurationRequest configuration = Newtonsoft.Json.JsonConvert.DeserializeObject<BusinessUnitConfigurationRequest>(businessUnitConfiguration);
            var result = new BusinessUnitConfigurationContext(SessionContext.GetYanbalSession()).ModifyBusinessUnitConfiguration(configuration, cultureCode, timeZoneCode, charactersMinimumGloss, vowelsMinimumGloss, indicatorAcquiringMainMenu, Request);
            return Json(result);
        }

        /// <summary>
        /// Muestra la vista que contiene el Logo de Compañía
        /// </summary>
        /// <param name="businessUnitConfigurationCode">Código de Configuración de Unidad de Negocio</param>
        /// <returns>Vista parcial de Logo de Compañía</returns>
        [CustomHandleError(typeof(BusinessUnitConfigurationModel))]
        public ActionResult ViewCompanyLogo(int businessUnitConfigurationCode)
        {
            byte[] imageByte = null;
            string contentType = "image/jpeg";
            BusinessUnitConfigurationModel model = new BusinessUnitConfigurationContext(SessionContext.GetYanbalSession()).ViewCompanyLogoImage(businessUnitConfigurationCode, imageByte, contentType);
            return PartialView("ViewCompanyLogo", model);
        }

        /// <summary>
        /// Muestra la vista que contiene el Logo de Reporte
        /// </summary>
        /// <param name="businessUnitConfigurationCode">Código de Configuración de Unidad de Negocio</param>
        /// <returns>Vista parcial de Logo de Reporte</returns>
        [CustomHandleError(typeof(BusinessUnitConfigurationModel))]
        public ActionResult ViewReportLogo(int businessUnitConfigurationCode)
        {
            byte[] imageByte = null;
            string contentType = "image/jpeg";
            BusinessUnitConfigurationModel model = new BusinessUnitConfigurationContext(SessionContext.GetYanbalSession()).ViewReportLogoImage(businessUnitConfigurationCode, imageByte, contentType);
            return PartialView("ViewReportLogo", model);
        }
        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitConfigurationRequest">Configuración de Unidad de Negocio</param>
        /// <returns>Json con la lista de Unidad de Negocio Configuración</returns>
        [CustomHandleError()]
        public JsonResult Search(BusinessUnitConfigurationRequest businessUnitConfigurationRequest)
        {
            List<BusinessUnitConfigurationEL> businessUnitConfiguration = new BusinessUnitConfigurationContext(SessionContext.GetYanbalSession()).Search(businessUnitConfigurationRequest);
            var json = Json(businessUnitConfiguration.ToList());
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
        #endregion

        #region FileContentResult
        /// <summary>
        /// Muestra la imagen generada
        /// </summary>
        /// <param name="businessUnitConfigurationCode">Código de Unidad de Negocio Configuración</param>
        /// <returns>File con la imagen generada</returns>
        public FileContentResult ViewCompanyLogoImage(int businessUnitConfigurationCode)
        {
            byte[] imageByte = null;
            string contentType = "image/jpeg";
            BusinessUnitConfigurationModel businessUnitConfigurationModel = new BusinessUnitConfigurationContext(SessionContext.GetYanbalSession()).ViewCompanyLogoImage(businessUnitConfigurationCode, imageByte, contentType);
            return File(businessUnitConfigurationModel.CompanyLogoImage, contentType);
        }

        /// <summary>
        /// Muestra la imagen generada
        /// </summary>
        /// <param name="businessUnitConfigurationCode">Código de Unidad de Negocio Configuración</param>
        /// <returns>File con la imagen generada</returns>
        public FileContentResult ViewReportLogoImage(int businessUnitConfigurationCode)
        {
            byte[] imageByte = null;
            string contentType = "image/jpeg";
            BusinessUnitConfigurationModel businessUnitConfigurationModel = new BusinessUnitConfigurationContext(SessionContext.GetYanbalSession()).ViewReportLogoImage(businessUnitConfigurationCode, imageByte, contentType);
            return File(businessUnitConfigurationModel.ReportLogoImage, contentType);
        }
        #endregion
    }
}
