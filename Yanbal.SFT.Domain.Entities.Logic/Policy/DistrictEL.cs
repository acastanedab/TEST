using System;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Clase entidad lógica de Ciudad 
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140824 <br />
    /// Modificación: 
    /// </remarks>
    [Serializable]
    public class DistrictEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public DistrictEL()
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

        /// <summary>
        /// Nombre de Distrito
        /// </summary>
        public string DistrictName { get; set; }
    }
}
