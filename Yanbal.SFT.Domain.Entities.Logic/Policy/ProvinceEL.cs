using System;
using System.Collections.Generic;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Clase entidad lógica de Ubigeo 
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140824 <br />
    /// Modificación: 
    /// </remarks>
    [Serializable]
    public class ProvinceEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ProvinceEL()
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

        /// <summary>
        /// Descripción de Provincia
        /// </summary>
        public string ProvinceName { get; set; }

    }
}
