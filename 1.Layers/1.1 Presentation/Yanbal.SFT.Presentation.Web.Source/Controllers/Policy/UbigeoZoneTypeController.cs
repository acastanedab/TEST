using System.Collections.Generic;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.UbigeoZoneType;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controladora de la opción Tipo de Zona de Ubigeo
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140827 <br />
    /// Modificación: 
    /// </remarks>
    [SystemAuthentication]
    public class UbigeoZoneTypeController : Controller
    {
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public UbigeoZoneTypeController()
        {
        }
        #endregion

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de la opción Tipo de Zona de Ubigeo
        /// </summary>
        /// <returns>Vista principal de la opción Tipo de Zona de Ubigeo</returns>
        [CustomHandleError(typeof(UbigeoZoneTypeModel))]
        public ActionResult Index()
        {
            UbigeoZoneTypeModel ubigeoZoneTypeModel = new UbigeoZoneTypeContext(SessionContext.GetYanbalSession()).Index();
            return View(ubigeoZoneTypeModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de registro de Parámetro
        /// </summary>
        /// <returns>Vista parcial del registro de Parámetro</returns>
        [CustomHandleError(typeof(ParameterModel))]
        public ActionResult Create()
        {
            UbigeoZoneTypeModel ubigeoZoneTypeModel = new UbigeoZoneTypeContext(SessionContext.GetYanbalSession()).Create();
            return PartialView("Create", ubigeoZoneTypeModel);
        }
        /// <summary>
        /// Muestra la vista de modificación de Tipo de Zona de Ubigeo
        /// </summary>
        /// <param name="codeTypeZoneUbigeo">Código de Tipo de Zona de Ubigeo</param>
        /// <returns>Vista parcial de modificación de Tipo de Zona de Ubigeo</returns>
        [CustomHandleError(typeof(UbigeoZoneTypeModel))]
        public ActionResult Edit(int codeTypeZoneUbigeo)
        {
            UbigeoZoneTypeModel ubigeoZoneTypeModel = new UbigeoZoneTypeContext(SessionContext.GetYanbalSession()).Edit(codeTypeZoneUbigeo);
            return PartialView("Edit", ubigeoZoneTypeModel);
        }
        #endregion

        #region JsonResult
        /// <summary>
        /// Permite realizar la búsqueda de Asignación de Zonas
        /// </summary>
        /// <param name="filterSearch">Filtro de búsqueda</param>
        /// <returns>Lista de Asignación de Zonas</returns>
        [CustomHandleError()]
        public JsonResult Search(UbigeoZoneTypeRequest filterSearch)
        {
            List<UbigeoZoneTypeEL> response = new UbigeoZoneTypeContext(SessionContext.GetYanbalSession()).Search(filterSearch);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar el registro de Asignación de Zonas
        /// </summary>
        /// <param name="register">Tipo de Zonas de Ubigeo</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult RegisterUbigeoZoneType(UbigeoZoneTypeRequest register)
        {
            var response = new UbigeoZoneTypeContext(SessionContext.GetYanbalSession()).RegisterUbigeoZoneType(register);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar la modificación de Asignación de Zonas
        /// </summary>
        /// <param name="register">Tipo de Zonas de Ubigeo</param>
        /// <returns>Json con el indicador de conformidad</returns>
        [CustomHandleError()]
        public JsonResult ModifyUbigeoZoneType(UbigeoZoneTypeRequest register)
        {
            var response = new UbigeoZoneTypeContext(SessionContext.GetYanbalSession()).ModifyUbigeoZoneType(register);
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
            var result = new UbigeoZoneTypeContext(SessionContext.GetYanbalSession()).GetListCity(codeZoneLevel1);
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
            var result = new UbigeoZoneTypeContext(SessionContext.GetYanbalSession()).GetListDistrict(codeZoneLevel1, codeZoneLevel2);
            return Json(result);
        }
        #endregion

    }
}
