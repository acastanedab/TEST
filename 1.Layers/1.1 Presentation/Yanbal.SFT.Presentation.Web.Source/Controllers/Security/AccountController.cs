using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManagement.Common.Common;
using Yanbal.SFT.FreightManagement.Common.Parametros;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Security;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Account;
using Yanbal.SFT.Presentation.Web.Source.Models.ViewModels;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.Presentation.Web.Source.Util;
using Yanbal.SFT.Proxies.Application.Authentication;
using Yanbal.SFT.Proxies.Application.Security;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Security
{
	/// <summary>
	/// Controladora de la opción Account
	/// </summary>    
	[HandleError]
	public class AccountController : Controller
	{
		#region Constructor
		/// <summary>
		/// Constructor por Defecto de implementación de la clase
		/// </summary>
		public AccountController()
		{
		}
		#endregion

		#region ActionResult
		/// <summary>
		/// Muestra la vista principal de la opción Account
		/// </summary>
		/// <returns>Vista Principal de la opción Account</returns>
		[CustomHandleError()]
		public ActionResult Index()
		{
			IPolicyDomain policyDomain = new PolicyDomain();
			BusinessUnitEL unidadNegocio = policyDomain.BusinessUnitSearch(new BusinessUnitRequest()
			{
				CountryCode = SystemConfiguration.BusinessUnity,
				RegistrationStatus = Enumerated.RegistrationStatus.Active,
				GetBusinessUnitConfigurationIndicator = true
			}).Result.FirstOrDefault();
			var versionCaptcha = Enumerated.PropiedadesCaptcha.SegundaVersion;
			if (KeysGooglePolicy.VersionCaptchaEsActivo(versionCaptcha))
			{
				ViewData["clavePublica"] = KeysGooglePolicy.ObtenerClavePublica(versionCaptcha, unidadNegocio.BusinessUnitCode);
			}

			return View();
		}
		#endregion

		#region JsonResult
		/// <summary>
		/// Permite realizar la validación de Usuario
		/// </summary>
		/// <param name="dataUser">Usuario de Logeo</param>
		/// <returns>Json con el indicador de conformidad</returns>
		[HttpPost]
		[CustomHandleError]
		public JsonResult LogOn(LogOnModel dataUser)
		{
			LoginAccesResponseAplication result = null;
			Session.Clear();
			string IdTransaccionLog = Guid.NewGuid().ToString();
			try
			{
				IPolicyDomain policyDomain = new PolicyDomain();
				BusinessUnitEL unidadNegocio = policyDomain.BusinessUnitSearch(new BusinessUnitRequest()
				{
					CountryCode = SystemConfiguration.BusinessUnity,
					RegistrationStatus = Enumerated.RegistrationStatus.Active,
					GetBusinessUnitConfigurationIndicator = true
				}).Result.FirstOrDefault();

				var ObtenerVersion = policyDomain.ObtenerVersionComponente(Enumerated.CodigoIdentificacionSistema, Enumerated.NombreComponente).updateVersionComponente.FirstOrDefault();
				var versionComponente = string.Concat(ObtenerVersion.NombreVersion, " (", ObtenerVersion.NombreTags, ")");
				ViewModelDatosUsuario.SetValueLogin(versionComponente);

				string systemIdentificationCode = SystemConfiguration.SystemIdentificationCode;
				string initialLanguage = unidadNegocio.BusinessUnitConfiguration.Culture.LanguageCode;
				var accountContext = new AccountContext();
				bool captchaEstaActivo = KeysGooglePolicy.VersionCaptchaEsActivo(Enumerated.PropiedadesCaptcha.SegundaVersion, unidadNegocio.BusinessUnitCode);
				bool captchaValido = true;
				if (captchaEstaActivo)
				{
					captchaValido = accountContext.ValidarCaptchaAccess(dataUser.token, unidadNegocio.BusinessUnitCode);
				}
				if (captchaValido)
				{
					var resultEndpoint = policyDomain.ListParameterValueSearchGeneralEndPoint(new ParameterValueRequest()
					{
						BusinessUnitCode = unidadNegocio.BusinessUnitCode,
						Code = Enumerated.CodeParameter.endPointParameters,
						ComponentName = Enumerated.NombreComponente
					});

					dataUser.IdiomaInicial = unidadNegocio.BusinessUnitConfiguration.Culture.LanguageCode;
					result = accountContext.ValidateUser(dataUser, systemIdentificationCode,
						new EndPointSetting()
						{
							Name = resultEndpoint.endpointSrvMSFSecurity.Name,
							Url = resultEndpoint.endpointSrvMSFSecurity.Url,
						}, IdTransaccionLog);

					if (result.CodeError == "1")
					{
						var credential = new CredentialSetting()
						{
							UserName = dataUser.User,
							InitialLanguage = initialLanguage,
							SystemIdentificationCode = systemIdentificationCode,
							IdTransaccionLog = IdTransaccionLog
						};
						TokenSecurityGeneratedResponseTypeProxy tokenSecurity = SendCredentialsExternal(credential,
							new EndPointSetting()
							{
								Name = resultEndpoint.endpointSrvMSFTokenSecurity.Name,
								Url = resultEndpoint.endpointSrvMSFTokenSecurity.Url,
							});

						if (!string.IsNullOrEmpty(tokenSecurity.tokenSecurity.tokenSecurityID))
						{
							ISecurityProxy securityProxy = new Proxies.Application.Security.SecurityProxy(
								new EndPointSetting()
								{
									Name = resultEndpoint.endpointSrvMSFSecurity.Name,
									Url = resultEndpoint.endpointSrvMSFSecurity.Url,
								});

							SearchCountryUserResponse searchCountryUserResponse = securityProxy.SearchCountryUser(new SearchCountryUserRequest() { codesystem = systemIdentificationCode, user = dataUser.User }, IdTransaccionLog);
							BusinessUnitEL businessUnit = new BusinessUnitEL();
							List<CountryEL> listCountry = new List<CountryEL>();


							if (searchCountryUserResponse.IndicatorCorporate)
							{
								foreach (var item in searchCountryUserResponse.MySearchCountryUserType)
								{
									if (item.CountryCode == tokenSecurity.tokenSecurity.BusinessUnity)
									{
										businessUnit = policyDomain.BusinessUnitSearch(new BusinessUnitRequest() { CountryCode = tokenSecurity.tokenSecurity.BusinessUnity, GetBusinessUnitConfigurationIndicator = true, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();
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
								businessUnit = policyDomain.BusinessUnitSearch(new BusinessUnitRequest() { CountryCode = tokenSecurity.tokenSecurity.BusinessUnity, GetBusinessUnitConfigurationIndicator = true, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();
							}

							PermissionAccesResponse permissionAccessResponse = securityProxy.PermissionAccess(new PermissionAccessRequest
							{
								User = dataUser.User,
								codigoIdentificacionSistema = systemIdentificationCode
							}, IdTransaccionLog);
							if (permissionAccessResponse == null || permissionAccessResponse.MyPermissionType == null || permissionAccessResponse.MyPermissionType.Count == 0)
							{
								result.CodeError = "-1";
							}
							else
							{
								var resultKey = policyDomain.ListParameterValueSearchGeneralConfiguracion(new ParameterValueRequest()
								{
									BusinessUnitCode = unidadNegocio.BusinessUnitCode,
									Code = Enumerated.CodeParameter.appSettingsParameters,
									ComponentName = Enumerated.NombreComponente
								});

								var sessionData = new YanbalSession
								{
									CodigoUnidadNegocio = unidadNegocio.BusinessUnitCode,
									IdiomaInicial = unidadNegocio.BusinessUnitConfiguration.Culture.LanguageCode,
									CulturaInicio = unidadNegocio.BusinessUnitConfiguration.Culture.CultureCode,

									CookieNameJ6 = resultKey.CookieNameJ6,
									ReportingUrl = resultKey.SrvReportingUrl,
									ReportingUser = resultKey.SrvReportingUser,
									ReportingPassword = resultKey.SrvReportingPassword,
									ReportingDomain = resultKey.SrvReportingDomain,
									ReportingWorkspacePathPolicy = string.Concat(resultKey.SrvReportingWorkspace, resultKey.SrvReportingPathPolicy),
									endpointSrvMSFSecurityName = resultEndpoint.endpointSrvMSFSecurity.Name,
									endpointSrvMSFSecurityUrl = resultEndpoint.endpointSrvMSFSecurity.Url,
									endpointSrvMSFTokenSecurityName = resultEndpoint.endpointSrvMSFTokenSecurity.Name,
									endpointSrvMSFTokenSecurityUrl = resultEndpoint.endpointSrvMSFTokenSecurity.Url
								};
								new AccountContext().PopulatePyfSession(IdTransaccionLog, businessUnit, listCountry, dataUser, permissionAccessResponse, searchCountryUserResponse, sessionData);
							}

							YanbalSession yanbalSession = SessionContext.GetYanbalSession();
							yanbalSession.token = tokenSecurity.tokenSecurity.tokenSecurityID;
							yanbalSession.IdTransaccionLog = IdTransaccionLog;
						}
					}
				}
			}
			catch (Exception ex)
			{
				result = null;
				Session.Clear();
				ILogging ilog4Net = new Logging();
				StackTrace tracenom = new StackTrace();
				Traza traceOrder = TraceFactory.Create(IdTransaccionLog, string.Empty, string.Empty, tracenom.GetFrame(0).GetMethod().Name, typeof(AccountController).FullName);

				var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
				ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
			}
			return Json(result);
		}

		/// <summary>
		/// Permite obtener los credenciales de logueo
		/// </summary>
		/// <param name="credential"></param>
		/// <param name="endpointSrvMSFTokenSecurity"></param>
		/// <returns>Variable con el token de seguridad</returns>
		private TokenSecurityGeneratedResponseTypeProxy SendCredentialsExternal(CredentialSetting credential, EndPointSetting endpointSrvMSFTokenSecurity)
		{
			string tokenSecurity = string.Empty;
			ITokenSecurityProxy tokenSecurityProxy = new TokenSecurityProxy(endpointSrvMSFTokenSecurity);

			TokenSecurityGeneratedResponseTypeProxy tokenGeneratedResponse = tokenSecurityProxy.generateTokenSecurity(new TokenSecurityGeneratedRequestTypeProxy
			{
				userName = credential.UserName,
				Language = credential.InitialLanguage,
				roleCode = string.Empty,
				BusinessUnity = SystemConfiguration.BusinessUnity,
				systemCode = SystemConfiguration.SystemIdentificationCode,
				cultureCode = string.Empty,
				currentConsultantCode = string.Empty,
				roleName = string.Empty,
				userFirstName = string.Empty
			}, credential.IdTransaccionLog);

			return tokenGeneratedResponse;
		}
		#endregion
	}
}
