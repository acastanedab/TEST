using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.Formula
{
    /// <summary>
    /// Interfaz que Define la Entidad de Fórmula
    /// </summary>
    /// <remarks>
    /// Creación: GMD  20140910 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IFormula : IDisposable
    {
        /// <summary>
        /// FormulaSearch
        /// </summary>
        List<FormulaEN> FormulaSearch(
            int? formulaCode,
            int? businessUnitCode,
            int? parameterCode,
            string value,
            string operation,
            decimal? factor,
            string factorType,
            string registrationStatus
            );
        /// <summary>
        /// FormulaSearch
        /// </summary>
        List<FormulaEN> FormulaSearch(
            int? formulaCode,
            int? businessUnitCode,
            int? parameterCode,
            string value,
            string operation,
            decimal? factor,
            string factorType,
            string registrationStatus,
            int? pageNo,
            int? pageSize);
        /// <summary>
        /// FormulaRegister
        /// </summary>
        int FormulaRegister(FormulaEN formula);
        /// <summary>
        /// FormulaUpdate
        /// </summary>
        int FormulaUpdate(FormulaEN formula);
    }
}
