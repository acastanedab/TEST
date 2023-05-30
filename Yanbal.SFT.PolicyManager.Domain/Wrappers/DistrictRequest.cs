using System;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Distrito
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140827 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class DistrictRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public DistrictRequest()
        {
        }

        /// <summary>
        /// Código de Ciudad
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// Código de Distrito
        /// </summary>
        public string DistrictCode { get; set; }
    }
}
