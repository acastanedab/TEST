using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.ParameterSection
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Parámetro Sección
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140810 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IParameterSection : IDisposable
    {
        /// <summary>
        /// ParameterSectionSearch
        /// </summary>
        List<ParameterSectionEN> ParameterSectionSearch(int? businessUnitCode, int? parameterCode, int? sectionCode, string name, bool? readOnlyIndicator, bool? requiredIndicator, string sectionType, string status);
        /// <summary>
        /// ParameterSectionSearch
        /// </summary>
        List<ParameterSectionEN> ParameterSectionSearch(int? businessUnitCode, int? parameterCode, int? sectionCode, string name, bool? readOnlyIndicator, bool? requiredIndicator, string sectionType, string status, int? pageNo, int? pageSize);
        /// <summary>
        /// ParameterSectionRegister
        /// </summary>
        int ParameterSectionRegister(ParameterSectionEN register);
        /// <summary>
        /// ParameterSectionUpdate
        /// </summary>
        int ParameterSectionUpdate(ParameterSectionEN register);
    }
}
