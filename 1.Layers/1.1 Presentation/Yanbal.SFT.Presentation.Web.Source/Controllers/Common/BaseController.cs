using System.Globalization;
using System.Web.Mvc;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Common
{
	/// <summary>
	/// Controladora de la opción Base
	/// </summary>
	public class BaseController : Controller
	{
		#region Constructor
		/// <summary>
		/// Constructor de implementación de la clase
		/// </summary>
		public BaseController()
		{

		}
		#endregion

		/// <summary>
		/// Pre execute Action Request
		/// </summary>
		/// <param name="filterContext">current context action</param>
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var yanbalSess = SessionContext.GetYanbalSession();
			if (yanbalSess == null)
			{
				filterContext.Result = this.Redirect("~/");
				return;
			}
			else if (!string.IsNullOrEmpty(yanbalSess.CulturaInicio))
			{
				CultureInfo cultureInfo = new CultureInfo(yanbalSess.CulturaInicio);
				System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
				System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
			}
			base.OnActionExecuting(filterContext);
		}
	}
}