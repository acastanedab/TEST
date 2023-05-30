using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightPolicy.Domain;
using Yanbal.SFT.FreightManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.TaxManager.Domain.Wrappers;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.TaxProduct
{
    /// <summary>
    /// Contexto de la vista Impuesto por tipo de Producto
    /// </summary>
    /// <remarks>
    /// Creación: GMD(PBG) 22082014 <br />
    /// Modificación: 
    /// </remarks>
    public class TaxProductContext
    {
        #region Properties
        readonly IApplicationPolicy applicationPolicy;
        readonly YanbalSession yanbalSession;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        /// <param name="yanbalSession">YanbalSession</param>
        public TaxProductContext(YanbalSession yanbalSession)
        {
            applicationPolicy = new ApplicationPolicy();
            this.yanbalSession = yanbalSession;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Impuesto por tipo de Producto
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public TaxProductModel Index()
        {
            TaxProductModel taxProductModel = new TaxProductModel();
            string controllerName = "TaxProduct";

            taxProductModel.Search = new ButtonControl();
            taxProductModel.Search.ID = "btnSearch";
            BaseContext.GetAccessControl(taxProductModel.Search.ID, controllerName, taxProductModel.Search);

            taxProductModel.Create = new ButtonControl();
            taxProductModel.Create.ID = "btnCreate";
            BaseContext.GetAccessControl(taxProductModel.Create.ID, controllerName, taxProductModel.Create);

            taxProductModel.Edit = new ImageControl();
            taxProductModel.Edit.ID = "ibtEditParameter";
            BaseContext.GetAccessControl(taxProductModel.Edit.ID, controllerName, taxProductModel.Edit);

            taxProductModel.ListOrigin = GetListOrigin();
            taxProductModel.ListTaxType = GetListTaxType();
            taxProductModel.ListException = GetListException();
            taxProductModel.ListRegistrationStatus = GetListRegistrationStatus();

            return taxProductModel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxProductRequest"></param>
        /// <returns></returns>
        public List<TaxProductEL> Search(TaxProductRequest taxProductRequest)
        {
            taxProductRequest.BusinessUnitCode = yanbalSession.BusinessUnitCode;
            List<TaxProductEL> result = applicationPolicy.TaxProductSearch(taxProductRequest).Result;
            return result;
        }
        /// <summary>
        /// Permite generar un nuevo impuesto por tipo de producto
        /// </summary>
        /// <returns>Impuesto generado</returns>
        public TaxProductModel Create()
        {
            TaxProductModel taxProductModel = new TaxProductModel();
            string controllerName = "TaxProduct";

            taxProductModel.Save = new ButtonControl();
            taxProductModel.Save.ID = "btnSaveParameter";
            BaseContext.GetAccessControl(taxProductModel.Save.ID, controllerName, taxProductModel.Save);

            taxProductModel.Cancel = new ButtonControl();
            taxProductModel.Cancel.ID = "btnCancelParameter";
            BaseContext.GetAccessControl(taxProductModel.Cancel.ID, controllerName, taxProductModel.Cancel);

            return taxProductModel;
        }
        /// <summary>
        /// Pemrite editar un impuesto por tipo de producto
        /// </summary>
        /// <param name="codeProduct">Coódigo de producto</param>
        /// <returns>Impuesto por tipo de producto editado</returns>
        public TaxProductModel Edit(int codeProduct)
        {
            TaxProductModel taxProductModel = new TaxProductModel();
            return taxProductModel;
        }

        #endregion

        #region Adapters
        /// <summary>
        /// Lista de estado registro
        /// </summary>
        /// <returns>Lista de estados</returns>
        private List<SelectType> GetListRegistrationStatus()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = applicationPolicy.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnitCode,
                CodeParameter = Convert.ToInt32(Enumerated.Parameter.RegistrationStatus),
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult.Select(itemResult => itemResult.RecordValueString))
            {
                listSelect.Add(new SelectType() { Id = item["1"], Name = item["2"] });
            }
            return listSelect;
        }

        private List<SelectType> GetListException()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = applicationPolicy.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnitCode,
                CodeParameter = Convert.ToInt32(Enumerated.Parameter.Exception),
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult.Select(itemResult => itemResult.RecordValueString))
            {
                listSelect.Add(new SelectType() { Id = item["1"], Name = item["2"] });
            }
            return listSelect;
        }

        private List<SelectType> GetListOrigin()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = applicationPolicy.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnitCode,
                CodeParameter = Convert.ToInt32(Enumerated.Parameter.Origin),
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult.Select(itemResult => itemResult.RecordValueString))
            {
                listSelect.Add(new SelectType() { Id = item["1"], Name = item["2"] });
            }
            return listSelect;
        }

        private List<SelectType> GetListTaxType()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = applicationPolicy.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnitCode,
                CodeParameter = Convert.ToInt32(Enumerated.Parameter.Tax),
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult.Select(itemResult => itemResult.RecordValueString))
            {
                listSelect.Add(new SelectType() { Id = item["1"], Name = item["2"] });
            }
            return listSelect;
        }

        #endregion

    }
}