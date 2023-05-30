
namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Request que representa los tipos de la Búsqueda de Paices por Usuario
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140722 <br />
    /// Modificacion: 
    /// </remarks>
    public class SearchCountryUserType
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public SearchCountryUserType()
        {
        }

        /// <summary>
        /// Código de pais
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// Nombre de pais
        /// </summary>
        public string CountryName { get; set; }
    }
}
