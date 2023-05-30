using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.Parameter
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Parámetro
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IParameter : IDisposable
    {
        /// <summary>
        /// ParameterSearch
        /// </summary>
        List<ParameterEN> ParameterSearch(
         int? businessUnitCode,
         int? parameterCode,
         string code,
         string codeApproximate,
         string name,
         string description,
         string typeParameter,
         bool? systemParameterIndicator,
         bool? allowAddValueIndicator,
         bool? allowModifyValueIndicator,
         string status);
        /// <summary>
        /// ParameterSearch
        /// </summary>
        List<ParameterEN> ParameterSearch(
            int? businessUnitCode,
            int? parameterCode,
            string code,
            string codeApproximate,
            string name,
            string description,
            string typeParameter,
            bool? systemParameterIndicator,
            bool? allowAddValueIndicator,
            bool? allowModifyValueIndicator,
            string status,
            int? pageNo,
            int? pageSize);
        /// <summary>
        /// ParameterRegister
        /// </summary>
        int ParameterRegister(ParameterEN parameter);
        /// <summary>
        /// ParameterUpdate
        /// </summary>
        int ParameterUpdate(ParameterEN parameter);
    }
}
