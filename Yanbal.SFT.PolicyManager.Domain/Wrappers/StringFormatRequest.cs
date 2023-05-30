using System;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa el Formato Cadena
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class StringFormatRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public StringFormatRequest()
        {
        }

        /// <summary>
        /// Código de Formato Cadena
        /// </summary>
        public int? StringFormatCode { get; set; }

        /// <summary>
        /// Formato
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Tipo de Formato
        /// </summary>
        public string FormatType { get; set; }

        /// <summary>
        /// Formato Largo
        /// </summary>
        public bool? LongFormat { get; set; }
    }
}