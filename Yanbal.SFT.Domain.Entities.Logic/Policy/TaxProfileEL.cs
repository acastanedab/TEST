using Domain.Entities.Logic.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Logic.Policy
{
    public class TaxProfileEL : BaseEL
    {
        public int ProfileTaxCode { get; set; }
        public int BusinessUnitCode { get; set; }
        public string DiretorCode { get; set; }
        public string DirectorName { get; set; }
        public string PersonType { get; set; } 
        public int Autonomy { get; set; }
        public DateTime DeclarationDate   { get; set; }
        public string Affectation { get; set; } //regimen tributario
        public string Observation { get; set; }
        public string RegisterStatus { get; set; }
        public string Exoneration { get; set; }
        public Dictionary<string, string> RecordValueString { get; set; }
    }
}
