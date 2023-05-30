using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using Yanbal.SFT.Proxies.Application.SRAService;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;

namespace Yanbal.SFT.Proxies.Application.Security
{
	/// <summary>
	/// Controller SecurityProxy Definition
	/// </summary>
	public class SecurityProxy : ISecurityProxy
	{
		private readonly string serviceName;
		private readonly string serviceUrl;

		/// <summary>
		/// Constructor por Defecto de implementación de la clase
		/// </summary>
		public SecurityProxy(EndPointSetting endPoint)
		{
			serviceName = endPoint.Name;
			serviceUrl = endPoint.Url;
		}

        /// <summary>
        /// Permite Loguearse al sistema mediante el sistema
        /// </summary>
        /// <param name="loginAccesRequest">Requisito de Acceso para Iniciar Sesión</param>
        /// <param name="IdTransaccionLog"></param>
        /// <returns>Respuesta de Acceso</returns>
        public LoginAccesResponse LoginAdministrator(LoginAccesRequest loginAccesRequest, string IdTransaccionLog)
		{
			LoginAccesResponse loginAccesResponse = new LoginAccesResponse();
			ILogging ilog4Net = new Logging();
			StackTrace tracenom = new StackTrace();
			Traza traceOrder = TraceFactory.Create(IdTransaccionLog, string.Empty, string.Empty, tracenom.GetFrame(0).GetMethod().Name, typeof(SecurityProxy).FullName);

			try
			{
				using (var service = new SRAServiceClient(serviceName, serviceUrl))
				{
					string CodigoIdentificacionSistema = ConfigurationManager.AppSettings["SystemIdentificationCode"];

					var request = new LoginRequestType();
					request.LoginRequest = new LoginTypeRequest();
					request.LoginRequest.user = loginAccesRequest.userName;
					request.LoginRequest.password = loginAccesRequest.password;
					request.LoginRequest.languageCode = loginAccesRequest.codigo_idioma;
					request.LoginRequest.systemCode = CodigoIdentificacionSistema;

					System.Net.Security.RemoteCertificateValidationCallback callBack = (sender, certificate, chain, sslPolicyErrors) => true;
					ServicePointManager.ServerCertificateValidationCallback += callBack;
					Yanbal.SFT.Proxies.Application.SRAService.LoginResponseType response = service.loginAdministrator(request);
					ServicePointManager.ServerCertificateValidationCallback -= callBack;

					if (response != null)
					{
						loginAccesResponse.ErrorManagerType = new ErrorManagerType();
						loginAccesResponse.ErrorManagerType.ErrorNumber = response.Error.errorCode;
						loginAccesResponse.ErrorManagerType.Description = response.Error.errorDescription;
						loginAccesResponse.ErrorManagerType.Severity = response.Error.severity;
						loginAccesResponse.UserName = response.LoginResponse.userName;
					}
				}
			}
			catch (Exception ex)
			{
				var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
				ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());

				loginAccesResponse.ErrorManagerType = new ErrorManagerType();
				loginAccesResponse.ErrorManagerType.ErrorNumber = "-1";
				loginAccesResponse.ErrorManagerType.Description = ex.Message;
				loginAccesResponse.ErrorManagerType.Severity = 0;
			}

			return loginAccesResponse;
		}

        /// <summary>
        /// Permite Loguearse al sistema mediante el sistema
        /// </summary>
        /// <param name="permissionAccessRequest">Acceso de Permiso</param>
        /// <param name="IdTransaccionLog"></param>
        /// <returns>Respuesta de Acceso de Permiso</returns>
        public PermissionAccesResponse PermissionAccess(PermissionAccessRequest permissionAccessRequest, string IdTransaccionLog)
		{
			PermissionAccesResponse permissionAccesResponse = new PermissionAccesResponse();
			ILogging ilog4Net = new Logging();
			StackTrace tracenom = new StackTrace();
			Traza traceOrder = TraceFactory.Create(IdTransaccionLog, string.Empty, string.Empty, tracenom.GetFrame(0).GetMethod().Name, typeof(SecurityProxy).FullName);

			try
			{
				using (var service = new SRAServiceClient(serviceName, serviceUrl))
				{
					var request = new PermissionAccessRequestType();
					request.PermissionAccessRequest = new PermissionRequest();
					request.PermissionAccessRequest.user = permissionAccessRequest.User;
					request.PermissionAccessRequest.systemIdentificationCode = permissionAccessRequest.codigoIdentificacionSistema;

					System.Net.Security.RemoteCertificateValidationCallback callBack = (sender, certificate, chain, sslPolicyErrors) => true;
					ServicePointManager.ServerCertificateValidationCallback += callBack;
					PermissionAccessResponseType response = service.permissionAccess(request);
					ServicePointManager.ServerCertificateValidationCallback -= callBack;

					permissionAccesResponse.MyPermissionType = new List<PermissionAcces>();

					var listOfPermissionTypeSFT = response.PermissionAccessResponse.listPermission;

					foreach (var item in listOfPermissionTypeSFT)
					{
						var permissionType = AdapterPermissionType(item);
						permissionAccesResponse.MyPermissionType.Add(permissionType);
					}

					permissionAccesResponse.ErrorManagerType = new ErrorManagerType();
					permissionAccesResponse.ErrorManagerType.ErrorNumber = response.Error.errorCode;
					permissionAccesResponse.ErrorManagerType.Description = response.Error.errorDescription;
					permissionAccesResponse.ErrorManagerType.Severity = response.Error.severity;
					permissionAccesResponse.IndicadorCultura = response.PermissionAccessResponse.cultureFlag;
				}
			}
			catch (Exception ex)
			{
				var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
				ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());

				permissionAccesResponse.ErrorManagerType = new ErrorManagerType();
				permissionAccesResponse.ErrorManagerType.ErrorNumber = "-1";
				permissionAccesResponse.ErrorManagerType.Description = ex.Message;
				permissionAccesResponse.ErrorManagerType.Severity = 0;
			}
			return permissionAccesResponse;
		}

        /// <summary>
        /// Permite Loguearse al sistema mediante el sistema
        /// </summary>
        /// <param name="searchCountryUserRequest">Request de Búsqueda de País por Usuario</param>
        /// <param name="IdTransaccionLog"></param>
        /// <returns>Respuesta de Acceso de Permiso</returns>
        public SearchCountryUserResponse SearchCountryUser(SearchCountryUserRequest searchCountryUserRequest, string IdTransaccionLog)
		{
			SearchCountryUserResponse searchCountryUserResponse = new SearchCountryUserResponse();
			ILogging ilog4Net = new Logging();
			StackTrace tracenom = new StackTrace();
			Traza traceOrder = TraceFactory.Create(IdTransaccionLog, string.Empty, string.Empty, tracenom.GetFrame(0).GetMethod().Name, typeof(SecurityProxy).FullName);

			try
			{
				using (var service = new SRAServiceClient(serviceName, serviceUrl))
				{
					var request = new SearchCountryUserRequestType();
					request.SearchCountryUserRequest = new CountryUserRequest();
					request.SearchCountryUserRequest.user = searchCountryUserRequest.user;
					request.SearchCountryUserRequest.codeSystem = searchCountryUserRequest.codesystem;

					System.Net.Security.RemoteCertificateValidationCallback callBack = (sender, certificate, chain, sslPolicyErrors) => true;
					ServicePointManager.ServerCertificateValidationCallback += callBack;
					var response = service.searchCountryUser(request);
					ServicePointManager.ServerCertificateValidationCallback -= callBack;

					searchCountryUserResponse.MySearchCountryUserType = new List<SearchCountryUserType>();

					var listOfSearchCountryUserTypeSFT = response.SearchCountryUserResponse.listCountry;

					foreach (var item in listOfSearchCountryUserTypeSFT)
					{
						var searchCountryUserType = AdapterSearchCountryUserType(item);
						searchCountryUserResponse.MySearchCountryUserType.Add(searchCountryUserType);
					}
					searchCountryUserResponse.IndicatorCorporate = response.SearchCountryUserResponse.indicatorCorporate;
					searchCountryUserResponse.ErrorManagerType = new ErrorManagerType();
					searchCountryUserResponse.ErrorManagerType.ErrorNumber = response.Error.errorCode;
					searchCountryUserResponse.ErrorManagerType.Description = response.Error.errorDescription;
					searchCountryUserResponse.ErrorManagerType.Severity = response.Error.severity;
				}
			}
			catch (Exception ex)
			{
				var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
				ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());

				searchCountryUserResponse.ErrorManagerType = new ErrorManagerType();
				searchCountryUserResponse.ErrorManagerType.ErrorNumber = "-1";
				searchCountryUserResponse.ErrorManagerType.Description = ex.Message;
				searchCountryUserResponse.ErrorManagerType.Severity = 0;
			}
			return searchCountryUserResponse;
		}

        /// <summary>
        /// Permite Loguearse al sistema mediante el sistema de seguridad autenticando con J6
        /// </summary>
        /// <param name="loginAccesRequest">Request para loguearse al sistema mediante el sistema de seguridad</param>
        /// <param name="IdTransaccionLog"></param>
        /// <returns>Response para loguearse al sistema mediante el sistema de seguridad</returns>
        public LoginAccesResponse Login(LoginAccesRequest loginAccesRequest, string IdTransaccionLog)
		{
			LoginAccesResponse loginAccesResponse = new LoginAccesResponse();
			ILogging ilog4Net = new Logging();
			StackTrace tracenom = new StackTrace();
			Traza traceOrder = TraceFactory.Create(IdTransaccionLog, string.Empty, string.Empty, tracenom.GetFrame(0).GetMethod().Name, typeof(SecurityProxy).FullName);

			try
			{
				using (var service = new SRAServiceClient(serviceName, serviceUrl))
				{
					var request = new LoginRequestType();
					request.LoginRequest = new LoginTypeRequest();
					request.LoginRequest.user = loginAccesRequest.userName;
					request.LoginRequest.password = loginAccesRequest.password;
					request.LoginRequest.languageCode = loginAccesRequest.codigo_idioma;
					request.LoginRequest.systemCode = loginAccesRequest.codigo_sistema;

					System.Net.Security.RemoteCertificateValidationCallback callBack = (sender, certificate, chain, sslPolicyErrors) => true;
					ServicePointManager.ServerCertificateValidationCallback += callBack;
					LoginResponseType response = service.login(request);
					ServicePointManager.ServerCertificateValidationCallback -= callBack;

					if (response != null)
					{
						loginAccesResponse.ErrorManagerType = new ErrorManagerType();
						loginAccesResponse.ErrorManagerType.ErrorNumber = response.Error.errorCode;
						loginAccesResponse.ErrorManagerType.Description = response.Error.errorDescription;
						loginAccesResponse.ErrorManagerType.Severity = response.Error.severity;
						loginAccesResponse.UserName = response.LoginResponse.userName;
					}
				}
			}
			catch (Exception ex)
			{
				var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
				ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());

				loginAccesResponse.ErrorManagerType = new ErrorManagerType();
				loginAccesResponse.ErrorManagerType.ErrorNumber = "-1";
				loginAccesResponse.ErrorManagerType.Description = ex.Message;
				loginAccesResponse.ErrorManagerType.Severity = 0;
			}

			return loginAccesResponse;
		}
		/// <summary>
		/// Método de Acceso de Permiso
		/// </summary>
		/// <param name="item">Item</param>
		/// <returns>Tipo de Permiso</returns>
		private PermissionAcces AdapterPermissionType(Permission item)
		{
			PermissionAcces permissionType = new PermissionAcces();

			permissionType.CodigoIdentificacionSistema = item.systemIdentificationCode;
			permissionType.NombreSistema = item.systemName;
			permissionType.DescripcionSistema = item.systemDescription;
			permissionType.RutaSistema = item.systemPath;
			permissionType.CodigoModulo = item.moduleCode;
			permissionType.CodigoIdentificacionModulo = item.moduleIdentificationCode;
			permissionType.NombreModulo = item.moduleName;
			permissionType.DescripcionModulo = item.moduleDescription;
			permissionType.NombreClaseIconoModulo = item.moduleIconClassName;
			permissionType.IndicadorUrlExterno = item.externalURLFlag;
			permissionType.DireccionUrlModulo = item.moduleURL;
			permissionType.CodigoOpcion = item.optionCode;
			permissionType.CodigoIdentificacionOpcion = item.optionIdentificationCode;
			permissionType.NombreOpcion = item.optionName;
			permissionType.DescripcionOpcion = item.optionDescription;
			permissionType.DireccionUrlOpcion = item.optionURL;
			permissionType.CodigoAccion = item.actionCode;
			permissionType.CodigoIdentificacionAccion = item.actionIdentificationCode;
			permissionType.NombreAccion = item.actionName;
			permissionType.DescripcionAccion = item.actionDescription;
			permissionType.EstadoRegistro = item.status;
			permissionType.SIdParentResult = item.parentResultId;
			permissionType.STipoResult = item.resultType;
			permissionType.NIdReferenceResult = item.referenceResultId;
			permissionType.SIdResult = item.resultId;

			return permissionType;
		}

		/// <summary>
		/// Método de Acceso de País por Usuario
		/// </summary>
		/// <param name="item">Item</param>
		/// <returns>Resultado de País por Usuario</returns>
		private SearchCountryUserType AdapterSearchCountryUserType(Country item)
		{
			SearchCountryUserType searchCountryUserType = new SearchCountryUserType();
			searchCountryUserType.CountryCode = item.countryCode;
			searchCountryUserType.CountryName = item.countryName;
			return searchCountryUserType;
		}
	}
}
