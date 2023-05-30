using System.Collections.Generic;

namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Clase que representa la respuesta a la solicitud de busqueda de usuario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140920 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class SearchUserServiceSecurityResponse
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public SearchUserServiceSecurityResponse()
        {
        }

        /// <summary>
        /// Lista de Usuarios encontrados
        /// </summary>
        public List<UserServiceJ6> MySearchUserServiceJ6 { get; set; }
        /// <summary>
        /// Error Manager Type
        /// </summary>
        public ErrorManagerType errorManagerType { get; set; }
    }
}
