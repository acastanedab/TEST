using Yanbal.SFT.Proxies.Application.Security;
namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Interface de ISecurityProxy
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140920 <br />
    /// Modificacion: 
    /// </remarks>
    public interface ISecurityProxy
    {
        /// <summary>
        /// LoginAdministrator
        /// </summary>
        LoginAccesResponse LoginAdministrator(LoginAccesRequest loginAccesRequest, string IdTransaccionLog);
        /// <summary>
        /// Login
        /// </summary>
        LoginAccesResponse Login(LoginAccesRequest loginAccesRequest, string IdTransaccionLog);
        /// <summary>
        /// PermissionAccess
        /// </summary>
        PermissionAccesResponse PermissionAccess(PermissionAccessRequest permissionAccessRequest, string IdTransaccionLog);
        /// <summary>
        /// SearchCountryUser
        /// </summary>
        SearchCountryUserResponse SearchCountryUser(SearchCountryUserRequest searchCountryUserRequest, string IdTransaccionLog);
    }
}
