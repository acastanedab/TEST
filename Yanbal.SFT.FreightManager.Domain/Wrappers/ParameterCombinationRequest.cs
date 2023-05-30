using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Common.Base;
using Yanbal.SFT.Domain.Common.Paging;

namespace Yanbal.SFT.FreightManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Combinación Parámetro
    /// </summary>
    /// <remarks>
    /// Creación: GMD(EJHF) 04092014 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class ParameterCombinationRequest : BaseRequest
    {
        /// <summary>
        /// Código de Combinación Parámetro
        /// </summary>
        public int? CodeParameterCombination { get; set; }

        /// <summary>
        /// Código de Combinación
        /// </summary>
        public int? CodeCombination { get; set; }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int? CodeParameter { get; set; }

        /// <summary>
        /// Orden de Combinación
        /// </summary>
        public byte? OrderCombination { get; set; }

        /// <summary>
        /// Valor de Parámetro
        /// </summary>
        public string Value { get; set; }
    }
}
