namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Request que representa Acceso al Iniciar Sesión
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140715 <br />
    /// Modificacion: 
    /// </remarks>
    public class LoginAccesRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public LoginAccesRequest()
        {
        }

        /// <summary>
        /// Nombre de Usuario
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// Contraseña
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Código de Idioma
        /// </summary>
        public string codigo_idioma { get; set; }

        /// <summary>
        /// Código del Sistema
        /// </summary>
        public string codigo_sistema { get; set; }
    }
}
