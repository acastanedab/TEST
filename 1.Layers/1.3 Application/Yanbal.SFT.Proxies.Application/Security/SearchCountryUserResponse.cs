using System.Collections.Generic;

namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Request que representa la respuesta de la Búsqueda de Paices por Usuario
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140722 <br />
    /// Modificacion: 
    /// </remarks>
    public class SearchCountryUserResponse
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public SearchCountryUserResponse()
        {
        }

        /// <summary>
        /// Indicador Corporativo
        /// </summary>
        public bool IndicatorCorporate { get; set; }
        /// <summary>
        /// Listado de Paises por Usuario y Sistema
        /// </summary>
        public List<SearchCountryUserType> MySearchCountryUserType { get; set; }

        /// <summary>
        /// Administrador de Errores
        /// </summary>
        public ErrorManagerType ErrorManagerType { get; set; }
    }
}
