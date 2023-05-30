using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa el Orde de la Combinación
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class CombinationOrderRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CombinationOrderRequest()
        {
        }

        /// <summary>
        /// Código de Orden de Combinación
        /// </summary>
        public int? OrderCodeCombination { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int? BusinessUnitCode { get; set; }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int? ParameterCode { get; set; }

        /// <summary>
        /// Código de Parámetro Manual
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Orden del Párametro en la Combinación
        /// </summary>
        public byte? Order { get; set; }
    }
}
