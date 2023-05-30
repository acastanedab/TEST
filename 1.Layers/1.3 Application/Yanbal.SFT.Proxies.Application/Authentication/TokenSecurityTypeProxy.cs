using System;

namespace Yanbal.SFT.Proxies.Application.Authentication
{
    /// <summary>
    /// Clase que contiene la información del proxy al servicio de token de seguridad
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140920 <br />
    /// Modificación:   <br />
    /// </remarks>
    [Serializable]
    public class TokenSecurityTypeProxy
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public TokenSecurityTypeProxy()
        {
        }

        /// <summary>
        /// token Security ID
        /// </summary>
        public string tokenSecurityID;
        /// <summary>
        /// Tiempo expiración
        /// </summary>
        public DateTime expirationTime;
        /// <summary>
        /// Nombre usuario
        /// </summary>
        public string userName;
        /// <summary>
        /// Primer nombre usuario
        /// </summary>
        public string userFirstName;
        /// <summary>
        /// Código rol
        /// </summary>
        public string roleCode;
        /// <summary>
        /// Código lenguaje
        /// </summary>
        public string Language;
        /// <summary>
        /// Unidad negocio
        /// </summary>
        public string BusinessUnity;
        /// <summary>
        /// Código sistema
        /// </summary>
        public string systemCode;
        /// <summary>
        /// nombre rol
        /// </summary>
        public string roleName;
        /// <summary>
        /// Codigo rol
        /// </summary>
        public string cultureCode;
        /// <summary>
        /// Código actual consultora
        /// </summary>
        public string currentConsultantCode;
    }
}
