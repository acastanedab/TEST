using System;
using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad Lógica que representa al Pais
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140731 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class CountryEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CountryEL()
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

        /// <summary>
        /// Nombre del País
        /// </summary>
        public string CountryName { get; set; }
    }
}
