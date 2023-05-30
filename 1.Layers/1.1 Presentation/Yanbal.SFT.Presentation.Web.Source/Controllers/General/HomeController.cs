using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.Presentation.Web.Source.Authentication;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Filters;
using Yanbal.SFT.Presentation.Web.Source.Models.Security;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.Presentation.Web.Source.Util;
using Yanbal.SFT.Proxies.Application.Security;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.General
{
	/// <summary>
	/// Controladora de la opción Home
	/// </summary>
	[SystemAuthentication]
	public class HomeController : BaseController
	{
		#region Constructor
		/// <summary>
		/// Constructor por Defecto de implementación de la clase
		/// </summary>
		public HomeController()
		{
		}
		#endregion

		#region ActionResult
		/// <summary>
		/// Muestra la vista principal de la opción Home
		/// </summary>
		/// <param name="lang">Código de País</param>
		/// <returns>Vista Principal de la opción Home</returns>
		[CustomHandleError()]
		public ActionResult Index(string lang)
		{
			ViewBag.Message = Yanbal.SFT.Presentation.Web.Source.Resources.Shared.GeneralResource.LabelTitle;
			YanbalSession yanbalSession = SessionContext.GetYanbalSession();
			//Se ejecuta cuando se realiza el cambio de Unidad de Negocio
			if (!string.IsNullOrEmpty(lang) && yanbalSession.User.CorporateIndicator && yanbalSession.ListCountry.Any(item => item.CountryCode == lang))
			{
				BaseContext.UpdateBusinessUnitSession(yanbalSession, lang);
				return Redirect(Request.UrlReferrer.ToString());
			}
			if (KeysGooglePolicy.VersionCaptchaEsActivo(Enumerated.PropiedadesCaptcha.TerceraVersion))
			{
				if (!yanbalSession.IsValidCaptcha)
				{
					yanbalSession.ControllerName = Enumerated.ControllerClassName.HomeController;
					yanbalSession.VersionCaptcha = Enumerated.PropiedadesCaptcha.TerceraVersion;
					return RedirectToAction("Index", "Recaptcha");
				}
			}

			return View();
		}
		/// <summary>
		/// Muestra la vista principal de logout
		/// </summary>
		/// <returns>Vista principal de logout</returns>
		public ActionResult LogOut()
		{
			string CodigoTokenSeguridad = string.Empty;
			var endpointSrvMSFTokenSecurity = new EndPointSetting();
			string cookieSessionJ6 = "";
			var yanbalSession = SessionContext.GetYanbalSession();
			if (yanbalSession != null)
			{
				cookieSessionJ6 = yanbalSession.CookieNameJ6;
				endpointSrvMSFTokenSecurity = new EndPointSetting()
				{
					Name = yanbalSession.endpointSrvMSFTokenSecurityName,
					Url = yanbalSession.endpointSrvMSFTokenSecurityUrl
				};
			}

			HttpCookie CookieNameJ6 = Request.Cookies[cookieSessionJ6];
			string IdTransaccionLog = Guid.NewGuid().ToString();
			if (CookieNameJ6 != null)
			{
				UserInformation userInformation = JsonConvert.DeserializeObject<UserInformation>(CookieNameJ6.Value);
				CookieNameJ6.Expires = DateTime.Now;
				HttpContext.Response.Cookies.Add(CookieNameJ6);
				CodigoTokenSeguridad = userInformation.tokenSecurityId;
			}
			else
			{
				YanbalSession yanbalSessionCookieget = SessionContext.GetYanbalSession();
				if (yanbalSessionCookieget != null)
				{
					IdTransaccionLog = yanbalSessionCookieget.IdTransaccionLog;
					CodigoTokenSeguridad = yanbalSessionCookieget.SecuritySession.tokenSecurityResponse.tokenSecurity.tokenSecurityID;
				}
			}

			if (!string.IsNullOrWhiteSpace(CodigoTokenSeguridad))
			{
				SystemAuthentication authentication = new SystemAuthentication();
				authentication.setExpirateTokenFromRepository(CodigoTokenSeguridad, IdTransaccionLog, endpointSrvMSFTokenSecurity);
				authentication.Dispose();
			}

			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetNoStore();
			HttpContext.Session.Abandon();

			return RedirectToAction("Index", "Account");
		}

		#endregion
	}

}
