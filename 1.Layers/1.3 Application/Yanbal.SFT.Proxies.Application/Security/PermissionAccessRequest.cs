
namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Request que representa Permiso de Acceo
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140715 <br />
    /// Modificacion: 
    /// </remarks>
    public class PermissionAccessRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public PermissionAccessRequest()
        {
        }

        /// <summary>
        /// Usuario
        /// </summary>
        public string User;

        /// <summary>
        /// Código de Identificación del Sistema
        /// </summary>
        public string codigoIdentificacionSistema;
    }
}
