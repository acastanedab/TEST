using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.Presentation.Web.Source.Util;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Security
{
    public class RecaptchaController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public RecaptchaController()
        {

        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            YanbalSession pyfSession = SessionContext.GetYanbalSession();
            Captcha captcha = new Captcha
            {
                version = pyfSession.VersionCaptcha,
                controllerName = pyfSession.ControllerName,
                clavePublica = KeysGooglePolicy.ObtenerClavePublica(pyfSession.VersionCaptcha, pyfSession.BusinessUnit.BusinessUnitCode)
            };

            return View(captcha);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public ActionResult ValidarRecaptchav3(string token, string controllerName)
        {
            YanbalSession yanbalSession = SessionContext.GetYanbalSession();

            string version = Enumerated.PropiedadesCaptcha.TerceraVersion;
            string actionRedirect = "Index";

            var captcha = CaptchaResponse.GetCaptcha(token, version, yanbalSession.BusinessUnit.BusinessUnitCode);
            if (captcha.score < Enumerated.PropiedadesCaptcha.Score || captcha.success == false || captcha.action != Enumerated.ActionReCaptcha.Home)
            {
                yanbalSession.ControllerName = controllerName;
                yanbalSession.VersionCaptcha = Enumerated.PropiedadesCaptcha.SegundaVersion;
                yanbalSession.IsValidCaptcha = false;
                controllerName = "Recaptcha";

                return RedirectToAction(actionRedirect, controllerName);
            }

            yanbalSession.ControllerName = string.Empty;
            yanbalSession.VersionCaptcha = string.Empty;
            yanbalSession.IsValidCaptcha = true;

            return RedirectToAction(actionRedirect, controllerName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public ActionResult ValidarRecaptchav2(string token, string controllerName)
        {
            YanbalSession yanbalSession = SessionContext.GetYanbalSession();
            string version = Enumerated.PropiedadesCaptcha.SegundaVersion;
            string actionRedirect = "Index";

            var captcha = CaptchaResponse.GetCaptcha(token, version, yanbalSession.BusinessUnit.BusinessUnitCode);

            if (captcha.success == false)
            {
                yanbalSession.ControllerName = controllerName;
                yanbalSession.VersionCaptcha = version;
                yanbalSession.IsValidCaptcha = false;
                controllerName = "Recaptcha";

                return RedirectToAction(actionRedirect, controllerName);
            }

            yanbalSession.ControllerName = string.Empty;
            yanbalSession.VersionCaptcha = string.Empty;
            yanbalSession.IsValidCaptcha = true;

            return RedirectToAction(actionRedirect, controllerName);
        }
    }
}
