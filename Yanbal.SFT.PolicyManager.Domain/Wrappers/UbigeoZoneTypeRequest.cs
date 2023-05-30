using System;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Tipo de Zona de Ubigeo
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140827 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class UbigeoZoneTypeRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public UbigeoZoneTypeRequest()
        {
        }

        /// <summary>
        /// Código de Tipo de Zona de Ubigeo
        /// </summary>
        public int? CodeTypeZoneUbigeo { get; set; }

        /// <summary>
        /// Código de Zona
        /// </summary>
        public string CodeZone { get; set; }

        /// <summary>
        /// Código de País
        /// </summary>
        public string CodeCountry { get; set; }

        /// <summary>
        /// Código de Nivel 1
        /// </summary>
        public string CodeLevel1 { get; set; }

        /// <summary>
        /// Descripción de Nivel 1
        /// </summary>
        public string Level1 { get; set; }

        /// <summary>
        /// Código de Nivel 2
        /// </summary>
        public string CodeLevel2 { get; set; }

        /// <summary>
        /// Descripción de Nivel 2
        /// </summary>
        public string Level2 { get; set; }

        /// <summary>
        /// Código de Nivel 3
        /// </summary>
        public string CodeLevel3 { get; set; }

        /// <summary>
        /// Descripción de Nivel 3
        /// </summary>
        public string Level3 { get; set; }

        /// <summary>
        /// Código de Tipo de Zona
        /// </summary>
        public string CodeTypeZone { get; set; }

        /// <summary>
        /// Descripción Estado Registro
        /// </summary>
        public string DescriptionRegistrationStatus { get; set; }

        /// <summary>
        /// Descripcion Tipo Zona
        /// </summary>
        public string TypeZoneDescription { get; set; }
    }
}
