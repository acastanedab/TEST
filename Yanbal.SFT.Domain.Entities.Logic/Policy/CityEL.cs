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
    public class CityEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CityEL()
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
                
        /// <summary>
        /// Nombre de Ciudad
        /// </summary>
        public string CityName { get; set; }
    }
}
