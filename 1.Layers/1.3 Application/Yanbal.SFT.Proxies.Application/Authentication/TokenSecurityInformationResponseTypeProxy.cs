using System;

namespace Yanbal.SFT.Proxies.Application.Authentication
{
    /// <summary>
    /// Clase que contiene la información de la respuesta de proxyal servicio de token de seguridad
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140920 <br />
    /// Modificación:   <br />
    /// </remarks>
    [Serializable]
    public class TokenSecurityInformationResponseTypeProxy
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public TokenSecurityInformationResponseTypeProxy()
        {
        }

        /// <summary>
        /// Token Security Type Proxy
        /// </summary>
        public TokenSecurityTypeProxy tokenSecurity;
        /// <summary>
        /// Administrador errores
        /// </summary>
        public ErrorManagerType errorManager;
    }
}
