using System;
using System.Collections.Generic;

namespace Yanbal.SFT.Domain.Entities.UpdateVersion
{
	/// <summary>
	/// Interfaz que Define la Entidad UpdateVersion
	/// </summary>
	public interface IUpdateVersionComponente : IDisposable
	{
		/// <summary>
		/// Obtener Versión del Componente
		/// </summary>
		/// <param name="NombreSistema"></param>
		/// <param name="NombreComponente"></param>
		/// <returns></returns>
		List<UpdateVersionComponenteEN> ObtenerVersionComponente(string NombreSistema, string NombreComponente);
	}
}