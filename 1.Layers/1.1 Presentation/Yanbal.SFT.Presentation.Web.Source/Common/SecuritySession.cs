using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Proxies.Application.Authentication;

namespace Yanbal.SFT.Presentation.Web.Source.Common
{
    /// <summary>
    /// Clase que representa la seguridad de la sesion
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20141005 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class SecuritySession
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public SecuritySession()
        {

        }
        /// <summary>
        /// tokenSecurityResponse
        /// </summary>
        public TokenSecurityInformationResponseTypeProxy tokenSecurityResponse { get; set; }
    }
}
