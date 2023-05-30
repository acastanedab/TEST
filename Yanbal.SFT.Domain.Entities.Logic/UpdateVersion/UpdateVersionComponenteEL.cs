using System;
using Yanbal.SFT.FreightManagement.Common.Paging;

namespace Yanbal.SFT.Domain.Entities.Logic.UpdateVersion
{/// <summary>
 /// Entidad Update Version
 /// </summary>
	[Serializable]
	public class UpdateVersionComponenteEL : PagingBase
	{
		/// <summary>
		/// Línea de Negocio
		/// </summary>
		public string LineaNegocio { get; set; }
		/// <summary>
		/// Nombre del Sistema
		/// </summary>
		/// 
		public string NombreSistema { get; set; }
		/// <summary>
		/// Nombre de la Versión
		/// </summary>
		/// 
		public string NombreVersion { get; set; }
		/// <summary>
		/// Código del Componente
		/// </summary>
		/// 
		public long CodigoComponente { get; set; }
		/// <summary>
		/// Nombre del Componente
		/// </summary>
		/// 
		public string NombreComponente { get; set; }
		/// <summary>
		/// Nombre Tags
		/// </summary>
		/// 
		public string NombreTags { get; set; }

	}
}
