using System;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class BusinessUnitRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BusinessUnitRequest()
        {
        }

        /// <summary>
        /// Código de Unidad de Negocio 
        /// </summary>
        public int? BusinessUnitCodeContext { get; set; }

        /// <summary>
        /// Nombre de Unidad de Negocio
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Código de País
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Razón Social de Unidad de Negocio
        /// </summary>
        public string BusinessUnitName { get; set; }

        /// <summary>
        /// Dirección de Unidad de Negocio
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Indicador que determina si se obtendra la Configuración de Unidad de Negocio
        /// </summary>
        public bool GetBusinessUnitConfigurationIndicator { get; set; }
    }
}
