
namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Clase que representa la respuesta a la solicitud de busqueda de usuario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140920 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class SearchUserServiceSecurityRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public SearchUserServiceSecurityRequest()
        {
        }

        /// <summary>
        /// Criterio de busqueda
        /// </summary>
        public string criteria { get; set; }
        /// <summary>
        /// Cantidad de registros a buscar
        /// </summary>
        public int count { get; set; }
    }
}
