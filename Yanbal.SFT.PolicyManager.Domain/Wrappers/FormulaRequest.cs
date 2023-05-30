using System;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Fórmula
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140911 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class FormulaRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FormulaRequest()
        {
        }

        /// <summary>
        /// Código de Fórmula
        /// </summary>
        public int? FormulaCode { get; set; }

        /// <summary>
        /// Valor de tipo de envio
        /// </summary>
        public string ValueSendType { get; set; }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int? ParameterCode { get; set; }

        /// <summary>
        /// Valor de Parámetro
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Operación
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Factor
        /// </summary>
        public decimal? Factor { get; set; }

        /// <summary>
        /// Factor con el formato correspondiente a la Unidad de Negocio
        /// </summary>
        public string FactorString { get; set; }

        /// <summary>
        /// Tipo de Factor
        /// </summary>
        public string FactorType { get; set; }

        /// <summary>
        /// Orden
        /// </summary>
        public byte? Order { get; set; }
    }
}
