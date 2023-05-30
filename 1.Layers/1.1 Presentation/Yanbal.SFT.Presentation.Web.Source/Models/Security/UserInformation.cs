using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Security
{
    /// <summary>
    /// Clase que representa la informacion del usuario a autenticar
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140920 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class UserInformation
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public UserInformation()
        {
        }

        /// <summary>
        /// token de seguridad
        /// </summary>
        public string tokenSecurityId;
        /// <summary>
        /// tiempo de expiracion del token
        /// </summary>
        public DateTime tokenExpirationTime;
        /// <summary>
        /// user name
        /// </summary>
        public string userName;
        /// <summary>
        /// user First Name
        /// </summary>
        public string userFirstName;
        /// <summary>
        /// codigo de rol
        /// </summary>
        public string roleCode;
        /// <summary>
        /// lenguaje
        /// </summary>
        public string Language;
        /// <summary>
        /// entidad de negocio
        /// </summary>
        public string businessUnitCode;
        /// <summary>
        /// codigo de sistema
        /// </summary>
        public string systemCode;
        /// <summary>
        /// nombre de rol
        /// </summary>
        public string roleName;
        /// <summary>
        /// codigo de cultura
        /// </summary>
        public string cultureCode;
        /// <summary>
        /// codigo de consultora
        /// </summary>
        public string currentConsultantCode;
    }
}
