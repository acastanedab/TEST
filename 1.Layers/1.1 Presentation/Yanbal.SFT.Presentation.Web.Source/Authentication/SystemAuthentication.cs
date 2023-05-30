using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Security;
using Yanbal.SFT.Presentation.Web.Source.Models.ViewModels;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.Proxies.Application.Authentication;
using Yanbal.SFT.Proxies.Application.Security;

namespace Yanbal.SFT.Presentation.Web.Source.Authentication
{
	/// <summary>
	/// Clase que representa el filter de autenticacion
	/// </summary>
	public class SystemAuthentication : AuthorizeAttribute
	{
		#region Constructor
		/// <summary>
		/// Constructor por Defecto de implementación de la clase
		/// </summary>
		public SystemAuthentication()
		{
		}        // destructor de clase

		/// <summary>
		/// SystemAuthentication
		/// </summary>
		~SystemAuthentication()

		{

			Dispose(true);

		}
		private IntPtr handle;

		// Variable que indica si el metodo Dispose ha sido llamado.

		private bool disposed = false;
		/// <summary>
		/// Dispose
		/// </summary>
		public void Dispose()

		{

			Dispose(true);

			GC.SuppressFinalize(this);

		}
		/// <summary>
		/// Dispose
		/// </summary>
		protected virtual void Dispose(bool disposing)

		{

			if (!this.disposed)

			{

				// Libera los recursos no administrados

				// solo si este codigo es ejecutado.

				CloseHandle(handle);

				handle = IntPtr.Zero;

			}

			disposed = true;

		}
		[System.Runtime.InteropServices.DllImport("Kernel32")]
		private extern static Boolean CloseHandle(IntPtr handle);
		#endregion

		#region Members

		/// <summary>
		/// Tiempo de expiracion del token
		/// </summary>
		private DateTime tokenExpirationTime { get; set; }

		/// <summary>
		/// Estado de redireccion a pagina
		/// </summary>
		public bool redirectToLoginPage { get; set; }

		#endregion

		#region Operations

		/// <summary>
		/// Permite autorizar el acceso 
		/// </summary>
		/// <param name="httpContext">Contexto</param>
		/// <returns>estado de acceso</returns>
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			bool isAuthorized = false;
			redirectToLoginPage = false;
			if (!IsAuthenticated(httpContext))
			{
				redirectToLoginPage = true;
			}
			else
			{
				isAuthorized = true;
			}
			return (isAuthorized);
		}

		/// <summary>
		/// Permite verificar si se tuvo acceso a la ruta solicitada
		/// </summary>
		/// <param name="filterContext">filtro del contexto</param>
		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
			if (redirectToLoginPage)
			{
				filterContext.Result = new RedirectResult(urlHelper.Action("Index", "Account", new { Area = "" }));
			}
			else
			{
				filterContext.Result = new RedirectResult(urlHelper.Action("Index", "Error", new { Area = "" }));
			}
		}

		/// <summary>
		/// Permite verificar si se está autenticado
		/// </summary>
		/// <param name="httpContext">contexto</param>
		/// <returns>estado de autenticacion</returns>
		private bool IsAuthenticated(HttpContextBase httpContext)
		{
			bool result = false;
			string IdTransaccionLog = Guid.NewGuid().ToString();
			UserInformation userInformation = null;

			var endpointSrvMSFTokenSecurity = new EndPointSetting();
			var endpointSrvMSFSecurity = new EndPointSetting();
			var resultKey = new ConfiguracionKeyResponse();
			var resultEndpoint = new ConfiguracionEndPointResponse();
			string cookieSessionJ6 = string.Empty;
			string IdiomaInicial;
			string CulturaInicio;
			YanbalSession yanbalSession = SessionContext.GetYanbalSession();
			if (yanbalSession != null)
			{
				IdTransaccionLog = yanbalSession.IdTransaccionLog;
				cookieSessionJ6 = yanbalSession.CookieNameJ6;
				endpointSrvMSFTokenSecurity.Name = yanbalSession.endpointSrvMSFTokenSecurityName;
				endpointSrvMSFTokenSecurity.Url = yanbalSession.endpointSrvMSFTokenSecurityUrl;
				endpointSrvMSFSecurity.Name = yanbalSession.endpointSrvMSFSecurityName;
				endpointSrvMSFSecurity.Url = yanbalSession.endpointSrvMSFSecurityUrl;
				IdiomaInicial = yanbalSession.IdiomaInicial;
				CulturaInicio = yanbalSession.CulturaInicio;
			}
			else
			{
				IPolicyDomain policyDomain = new PolicyDomain();
				var unidadNegocio = GetUnidadNegocio();
				resultKey = policyDomain.ListParameterValueSearchGeneralConfiguracion(new ParameterValueRequest()
				{
					BusinessUnitCode = unidadNegocio.BusinessUnitCode,
					Code = Enumerated.CodeParameter.appSettingsParameters,
					ComponentName = Enumerated.NombreComponente
				});

				resultEndpoint = policyDomain.ListParameterValueSearchGeneralEndPoint(new ParameterValueRequest()
				{
					BusinessUnitCode = unidadNegocio.BusinessUnitCode,
					Code = Enumerated.CodeParameter.endPointParameters,
					ComponentName = Enumerated.NombreComponente
				});
				cookieSessionJ6 = resultKey.CookieNameJ6;
				endpointSrvMSFTokenSecurity.Name = resultEndpoint.endpointSrvMSFTokenSecurity.Name;
				endpointSrvMSFTokenSecurity.Url = resultEndpoint.endpointSrvMSFTokenSecurity.Url;
				endpointSrvMSFSecurity.Name = resultEndpoint.endpointSrvMSFSecurity.Name;
				endpointSrvMSFSecurity.Url = resultEndpoint.endpointSrvMSFSecurity.Url;
				IdiomaInicial = unidadNegocio.BusinessUnitConfiguration.Culture.LanguageCode;
				CulturaInicio = unidadNegocio.BusinessUnitConfiguration.Culture.CultureCode;
			}

			#region PorCookie
			var userInformationCookie = httpContext.Request.Cookies[cookieSessionJ6];
			if (userInformationCookie != null)
			{
				userInformation = JsonConvert.DeserializeObject<UserInformation>(userInformationCookie.Value);
			}
			#endregion

			string strTokenSecurityId = string.Empty;

			if (yanbalSession == null && !string.IsNullOrEmpty(httpContext.Request.QueryString.Get("token")))
			{
				strTokenSecurityId = httpContext.Request.QueryString.Get("token");
			}
			else if (yanbalSession != null && !string.IsNullOrEmpty(yanbalSession.token))
			{
				strTokenSecurityId = yanbalSession.token;
			}
			else if (userInformationCookie != null)
			{
				strTokenSecurityId = userInformation.tokenSecurityId;
			}

			TokenSecurityInformationResponseTypeProxy tokenInformationResponse = new TokenSecurityInformationResponseTypeProxy();

			if (strTokenSecurityId != string.Empty)
			{
				tokenInformationResponse = GetTokenInformationFromRepository(strTokenSecurityId, IdTransaccionLog, endpointSrvMSFTokenSecurity);
			}

			if (tokenInformationResponse != null)
			{
				SecuritySession securitySession = new SecuritySession();
				securitySession.tokenSecurityResponse = tokenInformationResponse;

				if (yanbalSession != null)
				{
					yanbalSession.SecuritySession = securitySession;
					yanbalSession.token = tokenInformationResponse.tokenSecurity.tokenSecurityID;
					yanbalSession.IdTransaccionLog = IdTransaccionLog;
					SessionContext.SetYanbalSession(yanbalSession);
				}
				else
				{
					yanbalSession = new YanbalSession();
					yanbalSession.SecuritySession = new SecuritySession();
					yanbalSession.SecuritySession = securitySession;
					yanbalSession.token = tokenInformationResponse.tokenSecurity.tokenSecurityID;
					yanbalSession.IdTransaccionLog = IdTransaccionLog;

					yanbalSession.IdiomaInicial = IdiomaInicial;
					yanbalSession.CulturaInicio = CulturaInicio;
					yanbalSession.CookieNameJ6 = resultKey.CookieNameJ6;
					yanbalSession.ReportingUrl = resultKey.SrvReportingUrl;
					yanbalSession.ReportingUser = resultKey.SrvReportingUser;
					yanbalSession.ReportingPassword = resultKey.SrvReportingPassword;
					yanbalSession.ReportingDomain = resultKey.SrvReportingDomain;
					yanbalSession.ReportingWorkspacePathPolicy = string.Concat(resultKey.SrvReportingWorkspace, resultKey.SrvReportingPathPolicy);
					yanbalSession.endpointSrvMSFSecurityName = resultEndpoint.endpointSrvMSFSecurity.Name;
					yanbalSession.endpointSrvMSFSecurityUrl = resultEndpoint.endpointSrvMSFSecurity.Url;
					yanbalSession.endpointSrvMSFTokenSecurityName = resultEndpoint.endpointSrvMSFTokenSecurity.Name;
					yanbalSession.endpointSrvMSFTokenSecurityUrl = resultEndpoint.endpointSrvMSFTokenSecurity.Url;

					SessionContext.SetYanbalSession(yanbalSession);
				}

				if (!IsExpirationTimeValid(tokenInformationResponse))
				{
					IPolicyDomain policyDomain = new PolicyDomain();
					BusinessUnitEL unidadNegocioEncontrada = policyDomain.BusinessUnitSearch(new BusinessUnitRequest()
					{
						CountryCode = tokenInformationResponse.tokenSecurity.BusinessUnity,
						RegistrationStatus = Enumerated.RegistrationStatus.Active,
						GetBusinessUnitConfigurationIndicator = true
					}).Result.FirstOrDefault();

					if (tokenInformationResponse.tokenSecurity.userName != null &&
								tokenInformationResponse.tokenSecurity.BusinessUnity != null)
					{
						result = ValidateLogin(IdTransaccionLog, tokenInformationResponse.tokenSecurity.userName, unidadNegocioEncontrada, endpointSrvMSFSecurity);
					}
				}
				else
				{
					SessionContext.Remove(SystemConfiguration.PyfSession);
				}
			}

			return result;
		}

		/// <summary>
		/// Obtiene la unidad de negocio
		/// </summary>
		/// <returns></returns>
		private BusinessUnitEL GetUnidadNegocio()
		{
			IPolicyDomain policyDomain = new PolicyDomain();
			var unidadNegocio = policyDomain.BusinessUnitSearch(new BusinessUnitRequest()
			{
				CountryCode = Enumerated.UnidadNegocio.NombreUnidadNegocio,
				RegistrationStatus = Enumerated.RegistrationStatus.Active,
				GetBusinessUnitConfigurationIndicator = true
			}).Result.FirstOrDefault();
			return unidadNegocio;
		}

		/// <summary>
		/// Permite verificar la expiracion del tiempo valida
		/// </summary>
		/// <param name="response">datos de busqueda del token de seguridad</param>
		/// <returns>estado del tiempo de expiracion</returns>
		private bool IsExpirationTimeValid(TokenSecurityInformationResponseTypeProxy response)
		{
			bool isExpired = true;

			if (response != null && response.errorManager.ErrorNumber == "0" && response.tokenSecurity != null)
			{
				tokenExpirationTime = response.tokenSecurity.expirationTime;
				if (response.tokenSecurity.expirationTime >= DateTime.Now)
				{
					isExpired = false;
				}
			}

			return isExpired;
		}

		/// <summary>
		/// Permite obtener la informacion segun el token de seguridad
		/// </summary>
		/// <param name="strTokenScurityId">id de token de seguridad</param>
		/// <param name="IdTransaccionLog"></param>
		/// <param name="endpointSrvMSFTokenSecurity"></param>
		/// <returns>Informacion del token de seguridad</returns>
		private TokenSecurityInformationResponseTypeProxy GetTokenInformationFromRepository(string strTokenScurityId, string IdTransaccionLog, EndPointSetting endpointSrvMSFTokenSecurity)
		{
			ITokenSecurityProxy tokenSecurityProxy = new TokenSecurityProxy(endpointSrvMSFTokenSecurity);

			TokenSecurityInformationResponseTypeProxy response = null;


			if (!String.IsNullOrEmpty(strTokenScurityId))
			{
				YanbalSession yanbalSession = SessionContext.GetYanbalSession();

				if (yanbalSession != null && yanbalSession.SecuritySession != null)
				{
					response = yanbalSession.SecuritySession.tokenSecurityResponse;

					if (strTokenScurityId != response.tokenSecurity.tokenSecurityID)
					{
						TokenSecurityInformationRequestTypeProxy request = new TokenSecurityInformationRequestTypeProxy();
						request.tokenSecurityID = strTokenScurityId;

						response = tokenSecurityProxy.getTokenSecurity(request, IdTransaccionLog);

						if (response != null && response.errorManager.ErrorNumber != "0")
						{
							response = null;
						}
					}
				}
				else
				{
					TokenSecurityInformationRequestTypeProxy request = new TokenSecurityInformationRequestTypeProxy();
					request.tokenSecurityID = strTokenScurityId;

					response = tokenSecurityProxy.getTokenSecurity(request, IdTransaccionLog);

					if (response != null && response.errorManager.ErrorNumber != "0")
					{
						response = null;
					}
				}
			}

			return response;
		}

		/// <summary>
		/// Permite obtener la informacion segun el token de seguridad
		/// </summary>
		/// <param name="strTokenScurityId">id de token de seguridad</param>
		/// <param name="IdTransaccionLog"></param>
		/// <param name="endpointSrvMSFTokenSecurity"></param>
		/// <returns>Informacion del token de seguridad</returns>
		public TokenSecurityInformationResponseTypeProxy setExpirateTokenFromRepository(string strTokenScurityId, string IdTransaccionLog, EndPointSetting endpointSrvMSFTokenSecurity)
		{
			ITokenSecurityProxy tokenSecurityProxy = new TokenSecurityProxy(endpointSrvMSFTokenSecurity);

			TokenSecurityInformationResponseTypeProxy response = null;


			if (!String.IsNullOrEmpty(strTokenScurityId))
			{
				YanbalSession yanbalSession = SessionContext.GetYanbalSession();

				if (yanbalSession != null && yanbalSession.SecuritySession != null)
				{
					response = yanbalSession.SecuritySession.tokenSecurityResponse;


					TokenSecurityInformationRequestTypeProxy request = new TokenSecurityInformationRequestTypeProxy();
					request.tokenSecurityID = strTokenScurityId;

					response = tokenSecurityProxy.setExpireTokenSecurity(request, IdTransaccionLog);

					if (response != null && response.errorManager.ErrorNumber != "0")
					{
						response = null;
					}

				}

			}

			return response;
		}

		/// <summary>
		/// Permite llenar las sesiones
		/// </summary>
		/// <param name="IdTransaccionLog"></param>
		/// <param name="loginName">login name</param>
		/// <param name="businessUnitEL">businessUnitEL</param>
		/// <param name="endpointSrvMSFSecurity"></param>
		/// <returns>estado de registro</returns>
		private bool ValidateLogin(string IdTransaccionLog, string loginName, BusinessUnitEL businessUnitEL, EndPointSetting endpointSrvMSFSecurity)
		{
			bool respond = true;

			ISecurityProxy securityProxy = new SecurityProxy(endpointSrvMSFSecurity);
			IPolicyDomain policyDomain = new PolicyDomain();
			YanbalSession yanbalSession = SessionContext.GetYanbalSession();
			if (yanbalSession == null)
			{
				respond = IsPermissionValid(IdTransaccionLog, loginName, businessUnitEL, securityProxy, policyDomain);
			}
			else
			{
				if (yanbalSession.User == null)
				{
					respond = IsPermissionValid(IdTransaccionLog, loginName, businessUnitEL, securityProxy, policyDomain);
				}
				else
				{
					if (yanbalSession.User.Login == null)
					{
						respond = IsPermissionValid(IdTransaccionLog, loginName, businessUnitEL, securityProxy, policyDomain);
					}
					else if (yanbalSession.User.Login != loginName)
					{
						respond = IsPermissionValid(IdTransaccionLog, yanbalSession.User.Login, businessUnitEL, securityProxy, policyDomain);
					}
				}
			}

			return respond;
		}

		/// <summary>
		/// Permite verificar si el permiso es valido
		/// </summary>
		/// <param name="IdTransaccionLog"></param>
		/// <param name="loginName">login namre</param>
		/// <param name="businessUnitEL">unidad de negocio</param>
		/// <param name="securityProxy">interfaz de seguridad</param>
		/// <param name="policyDomain">dominio</param>
		/// <returns>estado de permiso</returns>
		private bool IsPermissionValid(string IdTransaccionLog, string loginName, BusinessUnitEL businessUnitEL, ISecurityProxy securityProxy, IPolicyDomain policyDomain)
		{
			bool respond = false;

			try
			{
				string systemIdentificationCode = SystemConfiguration.SystemIdentificationCode;
				string initialLanguage = businessUnitEL.BusinessUnitConfiguration.Culture.LanguageCode;

				LoginAccesResponse responseAccess = securityProxy.Login(new LoginAccesRequest
				{
					userName = loginName,
					password = default(string),
					codigo_idioma = initialLanguage,
					codigo_sistema = systemIdentificationCode
				}, IdTransaccionLog);

				if (responseAccess != null)
				{
					if (responseAccess.ErrorManagerType.ErrorNumber != "1")
						return false;
				}
				else
				{
					return false;
				}

				YanbalSession pyfSessionTemp = new YanbalSession();
				pyfSessionTemp = SessionContext.GetYanbalSession();

				YanbalSession pyfSession = pyfSessionTemp != null ? pyfSessionTemp : new YanbalSession();

				SearchCountryUserResponse searchCountryUserResponses = securityProxy.SearchCountryUser(new SearchCountryUserRequest() { codesystem = systemIdentificationCode, user = loginName }, IdTransaccionLog);
				BusinessUnitEL businessUnit = new BusinessUnitEL();
				List<CountryEL> listCountry = new List<CountryEL>();
				if (searchCountryUserResponses.IndicatorCorporate)
				{
					foreach (var item in searchCountryUserResponses.MySearchCountryUserType)
					{
						if (item.CountryCode == businessUnitEL.CountryCode)
						{
							businessUnit = policyDomain.BusinessUnitSearch(new BusinessUnitRequest() { CountryCode = businessUnitEL.CountryCode, GetBusinessUnitConfigurationIndicator = true, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();
						}
						var bussinessUnitResult = policyDomain.BusinessUnitSearch(new BusinessUnitRequest { CountryCode = item.CountryCode, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;
						if (bussinessUnitResult.Count > 0 && !listCountry.Any(itemAny => itemAny.CountryCode == bussinessUnitResult.FirstOrDefault().CountryCode))
						{
							listCountry.Add(new CountryEL() { CountryCode = bussinessUnitResult.FirstOrDefault().CountryCode });

						}
					}
				}
				else
				{
					businessUnit = policyDomain.BusinessUnitSearch(new BusinessUnitRequest() { CountryCode = businessUnitEL.CountryCode, GetBusinessUnitConfigurationIndicator = true, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();
				}
				PermissionAccesResponse permissionAccessResponse = securityProxy.PermissionAccess(new PermissionAccessRequest
				{
					User = loginName,
					codigoIdentificacionSistema = systemIdentificationCode
				}, IdTransaccionLog);

				var ObtenerVersion = policyDomain.ObtenerVersionComponente(Enumerated.CodigoIdentificacionSistema, Enumerated.NombreComponente).updateVersionComponente.FirstOrDefault();
				var versionComponente = string.Concat(ObtenerVersion.NombreVersion, " (", ObtenerVersion.NombreTags, ")");
				ViewModelDatosUsuario.SetValueLogin(versionComponente);

				if (permissionAccessResponse == null || permissionAccessResponse.MyPermissionType == null || permissionAccessResponse.MyPermissionType.Count == 0)
				{
					return false;
				}
				else
				{
					pyfSession.BusinessUnit = new BusinessUnitEL();
					pyfSession.BusinessUnit = businessUnit;
					pyfSession.IdTransaccionLog = IdTransaccionLog;
					pyfSession.User = new User();
					pyfSession.User.Login = loginName;
					pyfSession.User.Ip = ClientManagement.GetIpNumber();
					pyfSession.User.CorporateIndicator = searchCountryUserResponses.IndicatorCorporate;
					pyfSession.ListCountry = (searchCountryUserResponses.IndicatorCorporate) ? listCountry : null;
					pyfSession.ListRegistrationStatus = BaseContext.GetListRegistrationStatus(pyfSession);

					PermissionAccesResponse response = securityProxy.PermissionAccess(new PermissionAccessRequest { User = loginName, codigoIdentificacionSistema = SystemConfiguration.SystemIdentificationCode }, IdTransaccionLog);

					if (response.MyPermissionType != null)
					{
						if (response.MyPermissionType.Count > 0)
						{
							pyfSession.IdTransaccionLog = IdTransaccionLog;
							pyfSession.LoginName = loginName;
							pyfSession.Menu = LoadMenu(response);
							pyfSession.Permissions = LoadPermission(response);
							SessionContext.SetYanbalSession(pyfSession);
							respond = true;
						}
						else
						{
							return false;
						}
					}
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
			return respond;
		}
		#endregion
		/// <summary>
		/// Permite llenar el menu
		/// </summary>
		/// <param name="response">Respuesta de permisos de acceso</param>
		/// <returns>Retorna menu</returns>
		private MenuRequest LoadMenu(PermissionAccesResponse response)
		{
			MenuRequest menu = new MenuRequest();
			menu.MyMenu = new List<MenuResult>();
			var modulos = response.MyPermissionType.Select(m => m.CodigoModulo).Distinct();

			foreach (var item in modulos)
			{
				var menus = response.MyPermissionType.Where(m => m.CodigoModulo == item && m.STipoResult == "M");

				if (menus != null && menus.ToList().Count > 0)
				{
					var myMenu = AdapterMenu(menus.FirstOrDefault());
					if (myMenu != null)
					{
						menu.MyMenu.Add(myMenu);
					}
				}
			}
			return menu;
		}
		/// <summary>
		/// Permite llenar permisos
		/// </summary>
		/// <param name="response">Respuesta de permisos de acceso</param>
		/// <returns>Menu segun permisos</returns>
		private MenuRequest LoadPermission(PermissionAccesResponse response)
		{
			MenuRequest menu = new MenuRequest();
			menu.MyMenu = new List<MenuResult>();

			foreach (var item in response.MyPermissionType)
			{
				var myMenu = AdapterMenu(item);
				menu.MyMenu.Add(myMenu);
			}

			return menu;
		}
		/// <summary>
		/// Permite adaptar menu
		/// </summary>
		/// <param name="item">Item de acceso de permiso</param>
		/// <returns>Tipo de permiso</returns>
		private MenuResult AdapterMenu(PermissionAcces item)
		{
			MenuResult permissionType = new MenuResult();
			permissionType.IdentificationSystemCode = item.CodigoIdentificacionSistema;
			permissionType.SystemName = item.NombreSistema;
			permissionType.SystemDescription = item.DescripcionSistema;
			permissionType.SystemPath = item.RutaSistema;
			permissionType.ModuleCode = item.CodigoModulo;
			permissionType.IdentificationModuleCode = item.CodigoIdentificacionModulo;
			permissionType.ModuleName = item.NombreModulo;
			permissionType.ModuleDescription = item.DescripcionModulo;
			permissionType.ModuleNameIcoClass = item.NombreClaseIconoModulo;
			permissionType.IndicatorUrlExternal = item.IndicadorUrlExterno;
			permissionType.ModuleUrlAddress = item.DireccionUrlModulo;
			permissionType.OptionCode = item.CodigoOpcion;
			permissionType.IdentificationOptionCode = item.CodigoIdentificacionOpcion;
			permissionType.OptionName = item.NombreOpcion;
			permissionType.OptionDescription = item.DescripcionOpcion;
			permissionType.OptionUrlDescription = item.DireccionUrlOpcion;
			permissionType.ActionCode = item.CodigoAccion;
			permissionType.IdentificationActionCode = item.CodigoIdentificacionAccion;
			permissionType.ActionName = item.NombreAccion;
			permissionType.ActionDescription = item.DescripcionAccion;
			permissionType.RegistrationStatus = item.EstadoRegistro;
			permissionType.ParentResultId = item.SIdParentResult;
			permissionType.ResulType = item.STipoResult;
			permissionType.ResultReferenceId = item.NIdReferenceResult;
			permissionType.ResultId = item.SIdResult;

			return permissionType;
		}
	}
}
