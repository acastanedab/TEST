using System;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Ciudad
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140827 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class CityRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CityRequest()
        {
        }

        /// <summary>
        /// Código de Provincia
        /// </summary>
        public string ProvinceCode { get; set; }

        /// <summary>
        /// Código de Ciudad
        /// </summary>
        public string CityCode { get; set; }        
    }
}
