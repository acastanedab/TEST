using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.TaxProduct;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.TaxManager.Domain.Wrappers;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Policy
{
    /// <summary>
    /// Controlador de la vista Impuesto por Tipo de Producto
    /// </summary>
    /// <remarks>
    /// Creacion: GMD(PBG) 22082014 <br />
    /// Modificacion: 
    /// </remarks>
    public class TaxProductController : BaseController
    {
        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de Impuesto por Tipo de Producto
        /// </summary>
        /// <returns>Vista principal de Impuesto por Tipo de Producto</returns>
        [CustomHandleError(typeof(TaxProductModel))]
        public ActionResult Index()
        {
            TaxProductModel taxProductModel = new TaxProductContext(SessionContext.GetYanbalSession()).Index();
            return View(taxProductModel);
        }
        #endregion

        #region PartialResult
        /// <summary>
        /// Muestra la vista de registro de Impuesto por tipo de producto
        /// </summary>
        /// <returns>Vista parcial del registro de Parámetro</returns>
        [CustomHandleError(typeof(TaxProductModel))]
        public ActionResult Create()
        {
            TaxProductModel taxProductModel = new TaxProductContext(SessionContext.GetYanbalSession()).Create();
            return PartialView("Create", taxProductModel);
        }

        /// <summary>
        /// Muestra la vista de modificación de Impuesto por tipo de producto
        /// </summary>
        /// <param name="codeParameter">Código de Producto</param>
        /// <returns>Vista parcial de modificación de Parámetro</returns>
        [CustomHandleError(typeof(TaxProductModel))]
        public ActionResult Edit(int codeProduct)
        {
            TaxProductModel taxProductModel = new TaxProductContext(SessionContext.GetYanbalSession()).Edit(codeProduct);
            return PartialView("Edit", taxProductModel);
        }
        #endregion

        #region JsonResults

        [CustomHandleError()]
        public JsonResult Search(TaxProductRequest filterSearch)
        {
            List<TaxProductEL> response = new TaxProductContext(SessionContext.GetYanbalSession()).Search(filterSearch);
            return Json(response);
        }

        #endregion
    }
}
