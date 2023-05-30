using System.Collections.Generic;
using System.Linq;
using Yanbal.SFT.FreightManagement.Common.Parametros;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
	/// <summary>
	/// Obtener Configuracion EndPoint Response
	/// </summary>
	public class ConfiguracionEndPointResponse
	{
		public ConfiguracionEndPointResponse()
		{
			endpointSrvMSFSecurity = new EndPointService();
			endpointSrvMSFTokenSecurity = new EndPointService();
		}
		public EndPointService endpointSrvMSFSecurity { get; set; }
		public EndPointService endpointSrvMSFTokenSecurity { get; set; }
	}
	public class EndPointService
	{
		/// <summary>
		/// Nombre
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Url
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Generar EndPoint pot nODO
		/// </summary>
		/// <param name="endPoint"></param>
		/// <param name="endPointType"></param>
		/// <param name="nodoCluster"></param>
		/// <returns></returns>
		public static EndPointService GenerarParametrosConfig(List<EndPointParameterConfig> endPoint, string endPointType, int nodoCluster)
		{
			var endPointSetting = new EndPointService();
			var endPointParameter = endPoint.FirstOrDefault(x => x.Codigo == endPointType);
			if (endPointParameter != null)
			{
				foreach (var item in endPointParameter.RutasUrlService)
				{
					if (item.IdNodo == nodoCluster)
					{
						endPointSetting = new EndPointService { Name = endPointParameter.Codigo, Url = item.UrlService };
						break;
					}
				}
			}
			return endPointSetting;
		}
	}
}
