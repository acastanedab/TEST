using System;
using System.Configuration;

namespace Yanbal.SFT.Presentation.Web.Source.Common
{
	/// <summary>
	/// Clase Common
	/// </summary>
	public class SystemConfiguration
	{
		/// <summary>
		/// Constructor por Defecto de implementación de la clase
		/// </summary>
		protected SystemConfiguration()
		{
		}

		/// <summary>
		/// Codigo Identificación del Sistema
		/// </summary>
		public static readonly string SystemIdentificationCode = ConfigurationManager.AppSettings["SystemIdentificationCode"];
		/// <summary>
		/// Pyf Session
		/// </summary>
		public static readonly string PyfSession = "YanbalSession";
		/// <summary>
		/// Security Session
		/// </summary>
		public static readonly string SecuritySession = "SecuritySession";
		/// <summary>
		/// BusinessUnity
		/// </summary>
		public static readonly string BusinessUnity = ConfigurationManager.AppSettings["BusinessUnity"];
		/// <summary>
		/// BusinessUnity
		/// </summary>
		public static readonly int NodoCluster = Convert.ToInt32(ConfigurationManager.AppSettings["NodoCluster"]);
	}
}
