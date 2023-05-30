using System;
using System.Collections.Generic;
using Yanbal.SFT.Domain.Entities.Policy.Combination;

namespace Yanbal.SFT.Domain.Entities.Policy.ParameterCombination
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Combinación Parámetro
    /// </summary>
    /// <remarks>
    /// Creación: GMD  20140904 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IParameterCombination : IDisposable
    {
        /// <summary>
        /// ParameterCombinationRegister
        /// </summary>
        int ParameterCombinationRegister(ParameterCombinationEN register);
        /// <summary>
        /// ParameterCombinationUpdate
        /// </summary>
        int ParameterCombinationUpdate(ParameterCombinationEN register);
        /// <summary>
        /// ParameterCombinationSearch
        /// </summary>
        List<ParameterCombinationEN> ParameterCombinationSearch(int? codeParameterCombination, List<CombinationTableEN> codeCombinationList, int? businessUnitCode, int? codeParameter, int? combinationOrder, string value, string registrationStatus, string registrationStatusCombination, int? pageNo, int? pageSize);
        /// <summary>
        /// ParameterCombinationSearchService
        /// </summary>
        List<ParameterCombinationEN> ParameterCombinationSearchService(int? codeParameterCombination, List<CombinationTableEN> codeCombinationList, int? businessUnitCode, int? codeParameter, int? combinationOrder, string value, string registrationStatus, string registrationStatusCombination);
    }
}
