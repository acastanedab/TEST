using System.Collections.Generic;
using Yanbal.SFT.Domain.Entities.Logic.UpdateVersion;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
	/// <summary>
	/// Obtener Version Componente
	/// </summary>
	public class UpdateVersionComponenteResponse
	{
		/// <summary>
		/// Lista Configuraciones Componente
		/// </summary>
		public List<UpdateVersionComponenteEL> updateVersionComponente { get; set; }
	}
}
