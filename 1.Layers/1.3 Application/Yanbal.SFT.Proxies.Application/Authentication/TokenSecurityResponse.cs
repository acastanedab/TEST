
namespace Yanbal.SFT.Proxies.Application.Authentication
{
    /// <summary>
    /// Clase que contiene la información de la respuesta de proxy al servicio de token de seguridad
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140920 <br />
    /// Modificación:   <br />
    /// </remarks>
    public class TokenSecurityResponse
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public TokenSecurityResponse()
        {
        }

        /// <summary>
        /// Token Security Generated Request Type Proxy
        /// </summary>
        public TokenSecurityGeneratedRequestTypeProxy tokenSecurity { get; set; }
        /// <summary>
        /// Administrador de errores
        /// </summary>
        public ErrorManagerType errorManager { get; set; }
    }
}
