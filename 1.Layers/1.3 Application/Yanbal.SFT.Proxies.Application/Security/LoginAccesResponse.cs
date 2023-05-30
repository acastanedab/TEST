
namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Response que representa el Permiso de Acceo de Acceso al Sistema
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140715 <br />
    /// Modificacion: 
    /// </remarks>
    public class LoginAccesResponse
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public LoginAccesResponse()
        {
        }
        /// <summary>
        /// Nombre de Usuario
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Manejador de Tipo de Error
        /// </summary>
        public ErrorManagerType ErrorManagerType { get; set; }
    }
}
