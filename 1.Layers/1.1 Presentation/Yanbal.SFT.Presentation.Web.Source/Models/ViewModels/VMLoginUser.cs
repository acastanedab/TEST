using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Yanbal.SFT.FreightManagement.Common;

namespace Yanbal.SFT.Presentation.Web.Source.Models.ViewModels
{
	public static class ViewModelDatosUsuario
	{
		public static void SetValueLogin(string versionComponente)
		{
			HttpContext.Current.Session.Add(Enumerated.SessionKey.VersionComponente, versionComponente);
		}


		/// <summary>
		/// Obtener Version Componente
		/// </summary>
		/// <returns></returns>
		public static string GetVersionComponente()
		{
			if (HttpContext.Current.Session[Enumerated.SessionKey.VersionComponente] != null)
				return HttpContext.Current.Session[Enumerated.SessionKey.VersionComponente].ToString();
			else
				return null;
		}
	}
}
