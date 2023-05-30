using System;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa la Cultura
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140910 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class CultureRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CultureRequest()
        {
        }

        /// <summary>
        /// Código de Unidad de Negocio de la Sesión
        /// </summary>
        public int? BusinessUnitCodeContext { get; set; }

        /// <summary>
        /// Código de Cultura
        /// </summary>
        public string CultureCode { get; set; }

        /// <summary>
        /// Código de Idioma
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Descripción de Idioma
        /// </summary>
        public string LanguageDescription { get; set; }

        /// <summary>
        /// Codigo de Pais
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Nombre de Pais
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Código de Formato de Fecha Corta
        /// </summary>
        public int? CodeShortDateFormat { get; set; }

        /// <summary>
        /// Código de Formato de Fecha Larga
        /// </summary>
        public int? CodeLongDateFormat { get; set; }

        /// <summary>
        /// Código de Formato de Hora Corta
        /// </summary>
        public int? CodeShortTimeFormat { get; set; }

        /// <summary>
        /// Código de Formato de Hora Larga
        /// </summary>
        public int? CodeLongTimeFormat { get; set; }

        /// <summary>
        /// Código de Formato de Números Enteros
        /// </summary>
        public int? CodeFormatIntegerNumber { get; set; }

        /// <summary>
        /// Código de Formato de Números Decimales
        /// </summary>
        public int? CodeFormatDecimalNumber { get; set; }

        /// <summary>
        /// Límite Superior de Año
        /// </summary>
        public short? UpperLimitYear { get; set; }
    }
}
