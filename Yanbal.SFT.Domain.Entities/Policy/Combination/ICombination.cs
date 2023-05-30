using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.Combination
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Combinación
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140810 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface ICombination : IDisposable
    {
        /// <summary>
        /// CombinationSearch
        /// </summary>
        List<CombinationEN> CombinationSearch(
            int? businessUnitCode,
            int? combinationCode,
            decimal? amountFreight,
            int? parameterCode,
            string value,
            string status,
            int? pageNo,
            int? pageSize);
        /// <summary>
        /// CombinationRegister
        /// </summary>
        int CombinationRegister(CombinationEN combination);
        /// <summary>
        /// CombinationUpdate
        /// </summary>
        int CombinationUpdate(CombinationEN combination);
    }
}
