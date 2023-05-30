using System;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using Yanbal.SFT.Proxies.Application.Security;
using Yanbal.SFT.Proxies.Application.TokenSecurityService;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;

namespace Yanbal.SFT.Proxies.Application.Authentication
{
	/// <summary>
	/// Clase que maneja las operaciones del servicio del token de seguridad
	/// </summary>
	public class TokenSecurityProxy : ITokenSecurityProxy
	{
		private readonly string serviceName;
		private readonly string serviceUrl;
		/// <summary>
		/// Constructor
		/// </summary>
		public TokenSecurityProxy(EndPointSetting endPoint)
		{
			serviceName = endPoint.Name;
			serviceUrl = endPoint.Url;
		}

        /// <summary>
        /// Permite agregar el token de seguridad
        /// </summary>
        /// <param name="request">Objeto que contiene la solicitud para agregar la token</param>
        /// <param name="IdTransaccionLog"></param>
        /// <returns>Objeto que contiene la respuesta de la generacion de un nuevo token de seguridad</returns>
        public TokenSecurityGeneratedResponseTypeProxy generateTokenSecurity(TokenSecurityGeneratedRequestTypeProxy request, string IdTransaccionLog)
		{
			TokenSecurityGeneratedResponseTypeProxy response = new TokenSecurityGeneratedResponseTypeProxy();
			ILogging ilog4Net = new Logging();
			StackTrace tracenom = new StackTrace();
			Traza traceOrder = TraceFactory.Create(IdTransaccionLog, string.Empty, string.Empty, tracenom.GetFrame(0).GetMethod().Name, typeof(TokenSecurityProxy).FullName);

			try
			{
				using (var service = new TokenSecurityServiceClient(serviceName, serviceUrl))
				{
					var requestService = new TokenSecurityGeneratedRequestType();
					requestService.TokenSecurityGeneratedRequest = new TokenSecurityGeneratedType();
					requestService.TokenSecurityGeneratedRequest.userName = request.userName;
					requestService.TokenSecurityGeneratedRequest.userFirstName = request.userFirstName;
					requestService.TokenSecurityGeneratedRequest.roleCode = request.roleCode;
					requestService.TokenSecurityGeneratedRequest.languageCode = request.Language;
					requestService.TokenSecurityGeneratedRequest.businessUnitCode = request.BusinessUnity;
					requestService.TokenSecurityGeneratedRequest.systemCode = request.systemCode;
					requestService.TokenSecurityGeneratedRequest.roleName = request.roleName;
					requestService.TokenSecurityGeneratedRequest.cultureCode = request.cultureCode;
					requestService.TokenSecurityGeneratedRequest.currentConsultantCode = request.currentConsultantCode;

					RemoteCertificateValidationCallback callBack = (sender, certificate, chain, sslPolicyErrors) => true;
					ServicePointManager.ServerCertificateValidationCallback += callBack;
					TokenSecurityGeneratedResponseType responseService = service.generateTokenSecurity(requestService);
					ServicePointManager.ServerCertificateValidationCallback -= callBack;

					if (responseService != null)
					{
						response.tokenSecurity = new TokenSecurityTypeProxy();

						response.tokenSecurity.tokenSecurityID = responseService.TokenSecurityGeneratedResponse.tokenSecurityId;
						response.tokenSecurity.expirationTime = responseService.TokenSecurityGeneratedResponse.expirationTime;
						response.tokenSecurity.userName = responseService.TokenSecurityGeneratedResponse.userName;
						response.tokenSecurity.userFirstName = responseService.TokenSecurityGeneratedResponse.userFirstName;
						response.tokenSecurity.roleCode = responseService.TokenSecurityGeneratedResponse.roleCode;
						response.tokenSecurity.Language = responseService.TokenSecurityGeneratedResponse.languageCode;
						response.tokenSecurity.BusinessUnity = responseService.TokenSecurityGeneratedResponse.businessUnitCode;
						response.tokenSecurity.systemCode = responseService.TokenSecurityGeneratedResponse.systemCode;
						response.tokenSecurity.roleName = responseService.TokenSecurityGeneratedResponse.roleName;
						response.tokenSecurity.cultureCode = responseService.TokenSecurityGeneratedResponse.cultureCode;
						response.tokenSecurity.currentConsultantCode = responseService.TokenSecurityGeneratedResponse.currentConsultantCode;

						response.errorManager = new ErrorManagerType();
						response.errorManager.ErrorNumber = responseService.Error.errorCode;
						response.errorManager.Description = responseService.Error.errorDescription;
						response.errorManager.Severity = responseService.Error.severity;
					}
				}
			}
			catch (Exception ex)
			{
				var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
				ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());

				response.errorManager = new ErrorManagerType();
				response.errorManager.ErrorNumber = "-1";
				response.errorManager.Description = ex.Message;
				response.errorManager.Severity = 0;
			}

			return response;
		}
        /// <summary>
        /// Permite obtener un token de seguridad mediante filtros
        /// </summary>
        /// <param name="request">Objeto que contiene los filtros de busqueda</param>
        /// <param name="IdTransaccionLog"></param>
        /// <returns>Objeto que contiene la respuesta de la busqueda de un token de seguridad</returns>
        public TokenSecurityInformationResponseTypeProxy getTokenSecurity(TokenSecurityInformationRequestTypeProxy request, string IdTransaccionLog)
		{
			TokenSecurityInformationResponseTypeProxy response = new TokenSecurityInformationResponseTypeProxy();
			ILogging ilog4Net = new Logging();
			StackTrace tracenom = new StackTrace();
			Traza traceOrder = TraceFactory.Create(IdTransaccionLog, string.Empty, string.Empty, tracenom.GetFrame(0).GetMethod().Name, typeof(TokenSecurityProxy).FullName);

			try
			{
				using (var service = new TokenSecurityServiceClient(serviceName, serviceUrl))
				{
					var requestService = new TokenSecurityInformationRequestType();
					requestService.TokenSecurityInformationRequest = new TokenSecurityInformationType();
					requestService.TokenSecurityInformationRequest.tokenSecurityId = request.tokenSecurityID;

					RemoteCertificateValidationCallback callBack = (sender, certificate, chain, sslPolicyErrors) => true;
					ServicePointManager.ServerCertificateValidationCallback += callBack;
					TokenSecurityInformationResponseType responseService = service.getTokenSecurityByTokenId(requestService);
					ServicePointManager.ServerCertificateValidationCallback -= callBack;

					if (responseService != null)
					{
						response.tokenSecurity = new TokenSecurityTypeProxy();

						response.tokenSecurity.tokenSecurityID = responseService.TokenSecurityInformationResponse.tokenSecurityId;
						response.tokenSecurity.expirationTime = responseService.TokenSecurityInformationResponse.expirationTime;
						response.tokenSecurity.userName = responseService.TokenSecurityInformationResponse.userName;
						response.tokenSecurity.userFirstName = responseService.TokenSecurityInformationResponse.userFirstName;
						response.tokenSecurity.roleCode = responseService.TokenSecurityInformationResponse.roleCode;
						response.tokenSecurity.Language = responseService.TokenSecurityInformationResponse.languageCode;
						response.tokenSecurity.BusinessUnity = responseService.TokenSecurityInformationResponse.businessUnitCode;
						response.tokenSecurity.systemCode = responseService.TokenSecurityInformationResponse.systemCode;
						response.tokenSecurity.roleName = responseService.TokenSecurityInformationResponse.roleName;
						response.tokenSecurity.cultureCode = responseService.TokenSecurityInformationResponse.cultureCode;
						response.tokenSecurity.currentConsultantCode = responseService.TokenSecurityInformationResponse.currentConsultantCode;

						response.errorManager = new ErrorManagerType();
						response.errorManager.ErrorNumber = responseService.Error.errorCode;
						response.errorManager.Description = responseService.Error.errorDescription;
						response.errorManager.Severity = responseService.Error.severity;
					}
				}
			}
			catch (Exception ex)
			{
				var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
				ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());

				response.errorManager = new ErrorManagerType();
				response.errorManager.ErrorNumber = "-1";
				response.errorManager.Description = ex.Message;
				response.errorManager.Severity = 0;
			}
			return response;
		}

        /// <summary>
        /// Permite obtener un token de seguridad mediante filtros
        /// </summary>
        /// <param name="request">Objeto que contiene los filtros de busqueda</param>
        /// <param name="IdTransaccionLog"></param>
        /// <returns>Objeto que contiene la respuesta de la busqueda de un token de seguridad</returns>
        public TokenSecurityInformationResponseTypeProxy setExpireTokenSecurity(TokenSecurityInformationRequestTypeProxy request, string IdTransaccionLog)
		{
			TokenSecurityInformationResponseTypeProxy response = new TokenSecurityInformationResponseTypeProxy();
			ILogging ilog4Net = new Logging();
			StackTrace tracenom = new StackTrace();
			Traza traceOrder = TraceFactory.Create(IdTransaccionLog, string.Empty, string.Empty, tracenom.GetFrame(0).GetMethod().Name, typeof(TokenSecurityProxy).FullName);

			try
			{
				using (var service = new TokenSecurityServiceClient(serviceName, serviceUrl))
				{
					var requestService = new TokenSecurityInformationRequestType();
					requestService.TokenSecurityInformationRequest = new TokenSecurityInformationType();
					requestService.TokenSecurityInformationRequest.tokenSecurityId = request.tokenSecurityID;

					RemoteCertificateValidationCallback callBack = (sender, certificate, chain, sslPolicyErrors) => true;
					ServicePointManager.ServerCertificateValidationCallback += callBack;
					TokenSecurityInformationResponseType responseService = service.setExpireTokenSecurityById(requestService);
					ServicePointManager.ServerCertificateValidationCallback -= callBack;

					if (responseService != null)
					{
						response.tokenSecurity = new TokenSecurityTypeProxy();

						response.tokenSecurity.tokenSecurityID = responseService.TokenSecurityInformationResponse.tokenSecurityId;
						response.tokenSecurity.expirationTime = responseService.TokenSecurityInformationResponse.expirationTime;
						response.tokenSecurity.userName = responseService.TokenSecurityInformationResponse.userName;
						response.tokenSecurity.userFirstName = responseService.TokenSecurityInformationResponse.userFirstName;
						response.tokenSecurity.roleCode = responseService.TokenSecurityInformationResponse.roleCode;
						response.tokenSecurity.Language = responseService.TokenSecurityInformationResponse.languageCode;
						response.tokenSecurity.BusinessUnity = responseService.TokenSecurityInformationResponse.businessUnitCode;
						response.tokenSecurity.systemCode = responseService.TokenSecurityInformationResponse.systemCode;
						response.tokenSecurity.roleName = responseService.TokenSecurityInformationResponse.roleName;
						response.tokenSecurity.cultureCode = responseService.TokenSecurityInformationResponse.cultureCode;
						response.tokenSecurity.currentConsultantCode = responseService.TokenSecurityInformationResponse.currentConsultantCode;

						response.errorManager = new ErrorManagerType();
						response.errorManager.ErrorNumber = responseService.Error.errorCode;
						response.errorManager.Description = responseService.Error.errorDescription;
						response.errorManager.Severity = responseService.Error.severity;
					}
				}
			}
			catch (Exception ex)
			{
				var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
				ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());

				response.errorManager = new ErrorManagerType();
				response.errorManager.ErrorNumber = "-1";
				response.errorManager.Description = ex.Message;
				response.errorManager.Severity = 0;
			}
			return response;
		}
	}
}
