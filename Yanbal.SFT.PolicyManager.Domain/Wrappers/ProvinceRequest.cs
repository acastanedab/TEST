using System;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Provincia
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140827 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class ProvinceRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ProvinceRequest()
        {
        }

        /// <summary>
        /// Código de País
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Código de Provincia
        /// </summary>
        public string ProvinceCode { get; set; }
    }
}
