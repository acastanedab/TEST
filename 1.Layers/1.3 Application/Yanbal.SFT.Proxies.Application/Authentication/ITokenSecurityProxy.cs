using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Proxies.Application.Authentication
{
    /// <summary>
    /// Interface que maneja el servicio de token de seguridad
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140920 <br />
    /// Modificación:  <br />
    /// </remarks>
    public interface ITokenSecurityProxy
    {
        /// <summary>
        /// generateTokenSecurity
        /// </summary>
        TokenSecurityGeneratedResponseTypeProxy generateTokenSecurity(TokenSecurityGeneratedRequestTypeProxy request, string IdTransaccionLog);
        /// <summary>
        /// getTokenSecurity
        /// </summary>
        TokenSecurityInformationResponseTypeProxy getTokenSecurity(TokenSecurityInformationRequestTypeProxy request, string IdTransaccionLog);
        /// <summary>
        /// setExpireTokenSecurity
        /// </summary>
        TokenSecurityInformationResponseTypeProxy setExpireTokenSecurity(TokenSecurityInformationRequestTypeProxy request, string IdTransaccionLog);
    }
}
