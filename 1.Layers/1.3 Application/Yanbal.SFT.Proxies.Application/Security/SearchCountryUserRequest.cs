
namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Request que representa la Busqueda de los Paices por Usuario
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140722 <br />
    /// Modificacion: 
    /// </remarks>
    public class SearchCountryUserRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public SearchCountryUserRequest()
        {
        }

        /// <summary>
        /// Código de Sistema
        /// </summary>
        public string codesystem { get; set; }

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string user { get; set; }
    }
}
