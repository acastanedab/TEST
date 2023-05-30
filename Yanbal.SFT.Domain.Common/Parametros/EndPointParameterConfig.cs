using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.FreightManagement.Common.Parametros
{
	/// <summary>
	/// Clase EndpointConfig
	/// </summary>
	public class EndPointParameterConfig
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public EndPointParameterConfig()
		{
			RutasUrlService = new List<UrlServiceNodo>();
		}
		/// <summary>
		/// Codigo
		/// </summary>
		public string Codigo { get; set; }
		/// <summary>
		/// Componentes
		/// </summary>
		public string Componentes { get; set; }
		/// <summary>
		/// Descripcion
		/// </summary>
		public string Descripcion { get; set; }
		/// <summary>
		/// Codigo Valor
		/// </summary>
		public int CodigoValor { get; set; }
		/// <summary>
		/// Listado RUTAS por NODO
		/// </summary>
		public List<UrlServiceNodo> RutasUrlService { get; set; }
	}

	/// <summary>
	/// Url Service Nodo
	/// </summary>
	public class UrlServiceNodo
	{
		/// <summary>
		/// ID NODO del Componente
		/// </summary>
		public int IdNodo { get; set; }
		/// <summary>
		/// Url Service
		/// </summary>
		public string UrlService { get; set; }
	}
}
