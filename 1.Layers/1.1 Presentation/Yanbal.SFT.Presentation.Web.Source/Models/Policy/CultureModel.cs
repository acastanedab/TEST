using System.Collections.Generic;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    /// <summary>
    /// Modelo que representa la Cultura
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140922 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class CultureModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CultureModel()
        {
        }

        /// <summary>
        /// Código de Cultura
        /// </summary>
        public string CultureCode { get; set; }
        
        /// <summary>
        /// Código de Idioma
        /// </summary>
        public string LanguageCode { get; set; }
        
        /// <summary>
        /// Código de País
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Código de Formato de Fecha Corta
        /// </summary>
        public int CodeShortDateFormat { get; set; }

        /// <summary>
        /// Código de Formato de Fecha Larga
        /// </summary>
        public int CodeLongDateFormat { get; set; }

        /// <summary>
        /// Código de Formato de Hora Corta
        /// </summary>
        public int CodeShortTimeFormat { get; set; }

        /// <summary>
        /// Código de Formato de Hora Larga
        /// </summary>
        public int CodeLongTimeFormat { get; set; }

        /// <summary>
        /// Código de Formato de Números Enteros
        /// </summary>
        public int CodeFormatIntegerNumber{ get; set; }

        /// <summary>
        /// Código de Formato de Números Decimales
        /// </summary>
        public int CodeFormatDecimalNumber { get; set; }
        
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Límite Superior de Año
        /// </summary>
        public short? UpperLimitYear { get; set; }

        /// <summary>
        /// Límite Inferior de Año
        /// </summary>
        public short? LowerLimitYear { get; set; }

        /// <summary>
        /// Límite de Rango de Años Concatenado
        /// </summary>
        public string RangeLimitConcatenatedYear { get; set; }

        /// <summary>
        /// Lista de Idiomas
        /// </summary>
        public List<SelectType> ListLanguage { get; set; }

        /// <summary>
        /// Lista de Países
        /// </summary>
        public List<SelectType> ListCountry { get; set; }

        /// <summary>
        /// Lista de Formatos de Fecha Corta
        /// </summary>
        public List<SelectType> ListShortDateFormat { get; set; }

        /// <summary>
        /// Lista de Formatos de Fecha Larga
        /// </summary>
        public List<SelectType> ListLongDateFormat { get; set; }

        /// <summary>
        /// Lista de Formatos de Hora Corta
        /// </summary>
        public List<SelectType> ListShortTimeFormat { get; set; }

        /// <summary>
        /// Lista de Formatos de Hora Larga
        /// </summary>
        public List<SelectType> ListLongTimeFormat { get; set; }

        /// <summary>
        /// Lista de Formatos de Números Enteros
        /// </summary>
        public List<SelectType> ListFormatIntegerNumber { get; set; }

        /// <summary>
        /// Lista de Formatos de Números Decimales
        /// </summary>
        public List<SelectType> ListFormatDecimalNumber { get; set; }

        /// <summary>
        /// Botón Buscar
        /// </summary>
        public ButtonControl Search { get; set; }

        /// <summary>
        /// Botón Crear
        /// </summary>
        public ButtonControl Create { get; set; }

        /// <summary>
        /// Botón Guardar
        /// </summary>
        public ButtonControl Save { get; set; }

        /// <summary>
        /// Botón Cancelar
        /// </summary>
        public ButtonControl Cancel { get; set; }

        /// <summary>
        /// Botón Editar
        /// </summary>
        public ImageControl Edit { get; set; }
    }
}
