using System;
using System.Globalization;
using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad Lógica que representa la Cultura
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140731 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class CultureEL : BaseEL
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public CultureEL()
        {
            this.CultureCode = "";
            this.LanguageCode = "";
            this.SelectedLanguageCode = "";
            this.LanguageName = "";
            this.CountryCode = "";
            this.CountryName = "";
            this.DescriptionShortDateFormat = "";
            this.DescriptionLongDateFormat = "";
            this.DescriptionShortTimeFormat = "";
            this.DescriptionLongTimeFormat = "";
            this.DescriptionFormatIntegerNumber = "";
            this.DescriptionFormatDecimalNumber = "";
            this.RangeLimitConcatenatedYear = "";
            this.IntegerThousandsSeparator = "";
            this.DecimalThousandsSeparator = "";
            this.DecimalSeparator = "";
        }

        /// <summary>
        /// Codigo de Cultura
        /// </summary>
        public string CultureCode { get; set; }

        /// <summary>
        /// Codigo de Idioma
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Codigo de Idioma Seleccionado
        /// </summary>
        public string SelectedLanguageCode { get; set; }

        /// <summary>
        /// Nombre de Idioma
        /// </summary>
        public string LanguageName { get; set; }

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
        public int CodeShortDateFormat { get; set; }

        /// <summary>
        /// Descripción de Formato de Fecha Corta
        /// </summary>
        public string DescriptionShortDateFormat { get; set; }

        /// <summary>
        /// Código de Formato de Fecha Larga
        /// </summary>
        public int CodeLongDateFormat { get; set; }

        /// <summary>
        /// Descripción de Formato de Fecha Larga
        /// </summary>
        public string DescriptionLongDateFormat { get; set; }

        /// <summary>
        /// Código de Formato de Hora Corta
        /// </summary>
        public int CodeShortTimeFormat { get; set; }

        /// <summary>
        /// Descripción de Formato de Hora Corta
        /// </summary>
        public string DescriptionShortTimeFormat { get; set; }

        /// <summary>
        /// Código de Formato de Hora Larga
        /// </summary>
        public int CodeLongTimeFormat { get; set; }

        /// <summary>
        /// Descripción de Formato de Hora Larga
        /// </summary>
        public string DescriptionLongTimeFormat { get; set; }

        /// <summary>
        /// Informacion de Cultura del sistema
        /// </summary>
        public CultureInfo CultureInfoSystem { get; set; }

        /// <summary>
        /// Codigo de Formato de Número Entero
        /// </summary>
        public int CodeFormatIntegerNumber { get; set; }

        /// <summary>
        /// Descripción de Formato de Número Entero
        /// </summary>
        public string DescriptionFormatIntegerNumber { get; set; }

        /// <summary>
        /// Codigo de Formato de Número Decimal
        /// </summary>
        public int CodeFormatDecimalNumber { get; set; }

        /// <summary>
        /// Descripción de Formato de Número Decimal
        /// </summary>
        public string DescriptionFormatDecimalNumber { get; set; }

        /// <summary>
        /// Límite Superior de Año
        /// </summary>
        public short? UpperLimitYear { get; set; }

        /// <summary>
        /// Límite Inferiror de Año
        /// </summary>
        public short? LowerLimitYear { get; set; }

        /// <summary>
        /// Símbolo Negativo
        /// </summary>
        public string RangeLimitConcatenatedYear { get; set; }

        /// <summary>
        /// Separador de Enteros de Miles
        /// </summary>
        public string IntegerThousandsSeparator { get; set; }

        /// <summary>
        /// Separador de Miles
        /// </summary>
        public string DecimalThousandsSeparator { get; set; }

        /// <summary>
        /// Separador de Decimales
        /// </summary>
        public string DecimalSeparator { get; set; }
    }
}
