using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Logic.Tax
{
    /// <summary>
    /// Tax Administration Definition
    /// </summary>
    /// <remarks>
    /// Creacion: GMD(PBG) 17072014 <br />
    /// Modificacion: 
    /// </remarks>
    /// 
    public class TaxEL
    {
        public int CodeTax { get; set; }
        public string NameTax { get; set; }
        public string TaxType { get; set; }
        public string Formula { get; set; }
        public string RegistrationStatus { get; set; }
    }
}
