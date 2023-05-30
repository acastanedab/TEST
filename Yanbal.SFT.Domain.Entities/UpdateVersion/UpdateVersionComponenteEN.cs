using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Yanbal.SFT.Domain.Entities.Base;
using Yanbal.SFT.FreightManagement.Common.Paging;

namespace Yanbal.SFT.Domain.Entities.UpdateVersion
{
	/// <summary>
	/// UpdateVersion Componente
	/// </summary>
	public class UpdateVersionComponenteEN : PagingBase, IUpdateVersionComponente
	{
		private readonly IRepositoryStoredProcedure<UpdateVersionComponenteEN> updateVersionRepository;

		#region Constructor
		public UpdateVersionComponenteEN()
		{

		}

		/// <summary>
		/// Constructor que permite inicializar la clase repositorio basado en store procedure
		/// </summary>
		/// <param name="culturaRepositoryStoreProcedure">Repositorio basado en store procedure.</param>
		public UpdateVersionComponenteEN(IRepositoryStoredProcedure<UpdateVersionComponenteEN> culturaRepositoryStoreProcedure)
		{
			this.updateVersionRepository = culturaRepositoryStoreProcedure;
		}

		#endregion

		#region Properties
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

		#endregion

		#region Operations
		/// <summary>
		/// Obtener la Versión del Componente
		/// </summary>
		/// <param name="NombreSistema"></param>
		/// <param name="NombreComponente"></param>
		/// <returns></returns>
		public List<UpdateVersionComponenteEN> ObtenerVersionComponente(string NombreSistema, string NombreComponente)
		{
			List<UpdateVersionComponenteEN> listaCulturaEN;
			listaCulturaEN = updateVersionRepository.ExecWithStoreProcedure("CONF.USP_UPDATEVERSION_COMPONENTE_SEL",

				new SqlParameter("NOMBRE_SISTEMA", SqlDbType.VarChar) { Value = (object)NombreSistema ?? DBNull.Value },
				new SqlParameter("NOMBRE_COMPONENTE", SqlDbType.VarChar) { Value = (object)NombreComponente ?? DBNull.Value }
				).ToList();
			return listaCulturaEN;
		}

		/// <summary>
		/// Destruye y libera el objeto.
		/// </summary>
		public void Dispose()
		{
			if (updateVersionRepository != null)
			{
				updateVersionRepository.Dispose();
			}
		}
		#endregion
	}
}
