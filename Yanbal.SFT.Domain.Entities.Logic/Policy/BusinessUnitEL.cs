using System;
using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    
    /// <summary>
    /// Entidad de Lógica que representa la Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class BusinessUnitEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BusinessUnitEL()
        {
        }

        /// <summary>
        /// Nombre de Unidad de Negocio
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Código de País
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Nombre de País
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Nombre de País
        /// </summary>
        public string CountryZoneCode { get; set; }        
        
        /// <summary>
        /// Razón Social de Compañía
        /// </summary>
        public string BusinessName { get; set; }

        /// <summary>
        /// Dirección de Compañía
        /// </summary>
        public string BusinessAddress { get; set; }

        /// <summary>
        /// Documento de Compañía
        /// </summary>
        public string BusinessPaper { get; set; }

        /// <summary>
        /// Configuración de Unidad de Negocio
        /// </summary>
        public BusinessUnitConfigurationEL BusinessUnitConfiguration { get; set; }
    }
}
