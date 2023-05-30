using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.CombinationOrder
{
    /// <summary>
    /// Interfaz que Define la Entidad de Orden de Combinación
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface ICombinationOrder : IDisposable
    {
        /// <summary>
        /// CombinationOrderSearch
        /// </summary>
        List<CombinationOrderEN> CombinationOrderSearch(
            int? orderCodeCombination,
            int? businessUnitCode,
            int? parameterCode,
            string code,
            byte? order,
            string status);
        /// <summary>
        /// CombinationOrderSearch
        /// </summary>
        List<CombinationOrderEN> CombinationOrderSearch(
            int? orderCodeCombination,
            int? businessUnitCode,
            int? parameterCode,
            string code,
            byte? order,
            string status,
            int? pageNo,
            int? pageSize );
        /// <summary>
        /// CombinationOrderRegister
        /// </summary>
        int CombinationOrderRegister(CombinationOrderEN combinationOrder);
        /// <summary>
        /// CombinationOrderUpdate
        /// </summary>
        int CombinationOrderUpdate(CombinationOrderEN combinationOrder);
    }
}
