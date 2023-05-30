using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Account;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.Presentation.Web.Source.Util;
using Yanbal.SFT.Proxies.Application.Security;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Security
{
	/// <summary>
	/// Contexto de la vista de Account
	/// </summary>
	public class AccountContext
	{
		#region Propiedades
		//Inicio Sonar 15/08/2016
		readonly YanbalSession yanbalSession;
		readonly IPolicyDomain policyDomain;
		//Fin Sonar
		#endregion

		#region Proceso
		/// <summary>
		/// Permite encriptar un texto
		/// </summary>
		/// <param name="_cadenaAencriptar">Texto a encriptar</param>
		/// <returns>Texto encriptado</returns>
		public static string Encriptar(string _cadenaAencriptar)
		{
			byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
			string result = Convert.ToBase64String(encryted);
			return result;
		}

		/// <summary>
		/// Permite desencriptar un texto
		/// </summary>
		/// <param name="_cadenaAdesencriptar">Texto a desencriptar</param>
		/// <returns>Texto desencriptado</returns>
		public static string DesEncriptar(string _cadenaAdesencriptar)
		{
			byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
			string result = System.Text.Encoding.Unicode.GetString(decryted);
			return result;
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor de implementación de la clase
		/// </summary>
		public AccountContext()
		{
			yanbalSession = new YanbalSession();
			policyDomain = new PolicyDomain();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Permite generar el Modelo de la ventana Account
		/// </summary>
		/// <returns>Modelo a aplicar en la vista</returns>
		public LogOnModel Index()
		{
			LogOnModel model = new LogOnModel();
			return model;
		}

		/// <summary>
		/// Permite realizar la validación de Usuario
		/// </summary>
		/// <param name="dataUser">Datos del Usuario</param>
		/// <param name="systemIdentificationCode">Código de Indetificación del Sistema</param>
		/// <param name="endpointSrvMSFSecurity"></param>
		/// <param name="IdTransaccionLog"></param>
		/// <returns>Indicadores de acceso</returns>
		public LoginAccesResponseAplication ValidateUser(LogOnModel dataUser, string systemIdentificationCode, EndPointSetting endpointSrvMSFSecurity, string IdTransaccionLog)
		{
			LoginAccesResponseAplication loginAccesResponseAplication = new LoginAccesResponseAplication();

			ISecurityProxy securityProxy = new SecurityProxy(endpointSrvMSFSecurity);

			LoginAccesResponse responseAccess = securityProxy.LoginAdministrator(new LoginAccesRequest
			{
				userName = dataUser.User,
				password = dataUser.Password,
				codigo_idioma = dataUser.IdiomaInicial,
				codigo_sistema = systemIdentificationCode
			}, IdTransaccionLog);

			if (responseAccess != null)
			{

				loginAccesResponseAplication.CodeError = responseAccess.ErrorManagerType.ErrorNumber;
				loginAccesResponseAplication.DescriptionError = responseAccess.ErrorManagerType.Description;
				loginAccesResponseAplication.UserName = responseAccess.UserName;
			}
			return loginAccesResponseAplication;
		}

        /// <summary>
        /// Permite guardar los datos en sesion
        /// </summary>
        /// <param name="IdTransaccionLog"></param>
        /// <param name="businessUnit">Unidad de Negocio</param>
        /// <param name="listCountry">Lista de País</param>
        /// <param name="dataUser">Usurio Data</param>
        /// <param name="permissionAccessResponse">Permiso de respuesta de acceso</param>
        /// <param name="searchCountryUserResponse">Buscar País Respuesta del Usuario</param>
        /// <param name="dataSession"></param>
        public void PopulatePyfSession(string IdTransaccionLog, BusinessUnitEL businessUnit, List<CountryEL> listCountry, LogOnModel dataUser, PermissionAccesResponse permissionAccessResponse, SearchCountryUserResponse searchCountryUserResponse, YanbalSession dataSession)
		{
			yanbalSession.BusinessUnit = (businessUnit != null) ? businessUnit : new BusinessUnitEL();
			if (businessUnit.BusinessUnitConfiguration == null)
			{
				yanbalSession.BusinessUnit.BusinessUnitConfiguration = new BusinessUnitConfigurationEL();
				yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture = new CultureEL();
			}
			yanbalSession.IdTransaccionLog = IdTransaccionLog;
			yanbalSession.User = new User();
			yanbalSession.User.Login = dataUser.User;
			yanbalSession.User.Ip = ClientManagement.GetIpNumber();
			yanbalSession.User.CorporateIndicator = searchCountryUserResponse.IndicatorCorporate;
			yanbalSession.ListCountry = (searchCountryUserResponse.IndicatorCorporate) ? listCountry : null;
			yanbalSession.ListRegistrationStatus = BaseContext.GetListRegistrationStatus(yanbalSession);
			if (permissionAccessResponse.MyPermissionType != null && permissionAccessResponse.MyPermissionType.Count > 0)
			{
				yanbalSession.Menu = LoadMenu(permissionAccessResponse);
				yanbalSession.Permissions = LoadPermission(permissionAccessResponse);

			}

			yanbalSession.CodigoUnidadNegocio = dataSession.CodigoUnidadNegocio;
			yanbalSession.IdiomaInicial = dataSession.IdiomaInicial;
			yanbalSession.CulturaInicio = dataSession.CulturaInicio;
			yanbalSession.CookieNameJ6 = dataSession.CookieNameJ6;
			yanbalSession.ReportingUrl = dataSession.ReportingUrl;
			yanbalSession.ReportingUser = dataSession.ReportingUser;
			yanbalSession.ReportingPassword = dataSession.ReportingPassword;
			yanbalSession.ReportingDomain = dataSession.ReportingDomain;
			yanbalSession.ReportingWorkspacePathPolicy = dataSession.ReportingWorkspacePathPolicy;
			yanbalSession.endpointSrvMSFSecurityName = dataSession.endpointSrvMSFSecurityName;
			yanbalSession.endpointSrvMSFSecurityUrl = dataSession.endpointSrvMSFSecurityUrl;
			yanbalSession.endpointSrvMSFTokenSecurityName = dataSession.endpointSrvMSFTokenSecurityName;
			yanbalSession.endpointSrvMSFTokenSecurityUrl = dataSession.endpointSrvMSFTokenSecurityUrl;

			SessionContext.SetYanbalSession(yanbalSession);
		}


		/// <summary>
		/// Permite llenar el menu
		/// </summary>
		/// <param name="response">Respuesta de permisos de acceso</param>
		/// <returns>Retorna menu</returns>
		public MenuRequest LoadMenu(PermissionAccesResponse response)
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
		public MenuRequest LoadPermission(PermissionAccesResponse response)
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

		/// <summary>
		/// Permite validar el token de reCaptcha de google.
		/// </summary>
		/// <param name="token">Token enviado desde FrontEnd</param>
		/// <param name="codigoUnidadNegocio"></param>
		/// <returns>Devuelve un bool con valor true si es valido.</returns>
		public bool ValidarCaptchaAccess(string token, int codigoUnidadNegocio)
		{

			string version = Enumerated.PropiedadesCaptcha.SegundaVersion;
			Captcha captcha = null;
			bool success = false;
			try
			{
				captcha = CaptchaResponse.GetCaptcha(token, version, codigoUnidadNegocio);
				success = captcha == null ? false : captcha.success;
			}
			catch (Exception ex)
			{
				Logging logging = new Logging();
				logging.Add(ex.Message, TraceEventType.Error, typeof(AccountContext).FullName);

				ILogging ilog4Net = new Logging();
				StackTrace tracenom = new StackTrace();
				string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
				string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
				Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(AccountContext).FullName);

				var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
				ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
			}

			return success;
		}
		#endregion
	}
}