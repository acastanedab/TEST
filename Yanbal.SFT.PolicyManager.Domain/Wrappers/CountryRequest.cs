using System;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa el País
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class CountryRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CountryRequest()
        {
        }

        /// <summary>
        /// Código de País
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Código de Zona del País
        /// </summary>
        public string CountryZoneCode { get; set; }
    }
}
