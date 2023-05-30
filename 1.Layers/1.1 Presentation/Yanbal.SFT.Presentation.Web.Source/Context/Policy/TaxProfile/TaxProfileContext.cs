using Domain.Entities.Logic.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManager.Domain.Wrappers;
using Yanbal.SFT.FreightPolicy.Domain;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.TaxProfile
{
    public class TaxProfileContext
    {
        #region Properties        
        readonly IApplicationPolicy applicationPolicy;
        readonly YanbalSession yanbalSession;
        #endregion

        #region Contructor
        public TaxProfileContext(YanbalSession yanbalSession) 
        {
            applicationPolicy = new ApplicationPolicy();
            this.yanbalSession = yanbalSession;
        }
        #endregion


        public TaxProfileModel Index()
        {
            TaxProfileModel taxProfileModel = new TaxProfileModel();
            string controllerName = "TaxProfile";
            taxProfileModel.Search = new  ButtonControl();
            taxProfileModel.Search.ID = "btnSearch";
            BaseContext.GetAccessControl(taxProfileModel.Search.ID, controllerName, taxProfileModel.Search);

            taxProfileModel.Create = new ButtonControl();
            taxProfileModel.Create.ID = "btnCreate";
            BaseContext.GetAccessControl(taxProfileModel.Create.ID, controllerName, taxProfileModel.Create);

            taxProfileModel.Edit = new ImageControl();
            taxProfileModel.Edit.ID = "ibtEditParameter";
            BaseContext.GetAccessControl(taxProfileModel.Edit.ID, controllerName, taxProfileModel.Edit);

            taxProfileModel.ListRegistrationStatus = GetListRegistrationStatus();

            return taxProfileModel;
        }

        public List<TaxProfileEL> Search(TaxProfileRequest taxProfileRequest)
        {
            taxProfileRequest.BusinessUnitCode = yanbalSession.BusinessUnitCode;
            List<TaxProfileEL> resultTaxProfile = applicationPolicy.TaxProfileSearch(taxProfileRequest).Result;
            return resultTaxProfile;
        }

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

    }
}
