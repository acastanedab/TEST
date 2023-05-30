using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    public class TaxProfileModel : BaseModel
    {
        public TaxProfileModel()
        {
            this.ListTypePerson = new List<SelectType>();
            this.ListRegistrationStatus = new List<SelectType>();
            this.ListRegimeTax = new List<SelectType>();
        }
        //ListRegistrationStatus
        public List<SelectType> ListTypePerson { get; set; }
        public List<SelectType> ListRegistrationStatus { get; set; }
        public List<SelectType> ListRegimeTax { get; set; }

        public ButtonControl Clean { get; set; }
        public ButtonControl Search { get; set; }
        public ButtonControl Create { get; set; }
        public ImageControl Edit { get; set; }
        public ButtonControl Save { get; set; }
        public ButtonControl Cancel { get; set; }

    }
}
