using Yanbal.SFT.Proxies.Application.SRAService;

namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Clase que representa los usuarios en J6
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140310 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class UserServiceJ6
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public UserServiceJ6()
        {
        }

        /// <summary>
        /// Code
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// Account
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// Culture
        /// </summary>
        public string culture { get; set; }
        /// <summary>
        /// active
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// password
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// hint
        /// </summary>
        public string hint { get; set; }
        /// <summary>
        /// mustChangePassword
        /// </summary>
        public bool mustChangePassword { get; set; }
        /// <summary>
        /// expiredPassword
        /// </summary>
        public bool expiredPassword { get; set; }
        /// <summary>
        /// faildePasswordLoked
        /// </summary>
        public bool failedPasswordLocked { get; set; }
        /// <summary>
        /// authType
        /// </summary>
        public string authType;
        /// <summary>
        /// country
        /// </summary>
        public string country { get; set; }
    }
}
