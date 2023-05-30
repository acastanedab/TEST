using System;
using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad Lógica que representa el Formato Cadena
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140731 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class StringFormatEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public StringFormatEL()
        {
        }

        /// <summary>
        /// Código de Formato Cadena
        /// </summary>
        public int StringFormatCode { get; set; }

        /// <summary>
        /// Formato
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Tipo de Formato
        /// </summary>
        public string FormatType { get; set; }

        /// <summary>
        /// Indicador de Formato Largo
        /// </summary>
        public bool LongFormat { get; set; }
    }
}
