using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Yanbal.SFT.Domain.Entities.Base;
using Yanbal.SFT.FreightManagement.Common.Paging;

namespace Yanbal.SFT.Domain.Entities.Policy.ParameterValue
{
	/// <summary>
	/// Entidad de Negocio que representa Parámetro Valor
	/// </summary>
	public class ParameterValueEN : PagingBase, IParameterValue
	{
		private readonly IRepositoryStoredProcedure<ParameterValueEN> repositoryProcedure;

		#region Constructor
		/// <summary>
		/// Constructor por Defecto de implementación de la clase
		/// </summary>
		public ParameterValueEN()
		{
		}

		/// <summary>
		/// Constructor que permite inicializar la clase repositorio basado en store procedure
		/// </summary>
		/// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
		public ParameterValueEN(IRepositoryStoredProcedure<ParameterValueEN> repositoryProcedure)
		{
			this.repositoryProcedure = repositoryProcedure;
		}
		#endregion


		#region Properties

		/// <summary>
		/// Código de Unidad de Negocio
		/// </summary>
		public int CodigoUnidadNegocio { get; set; }

		/// <summary>
		/// Código de Parámetro
		/// </summary>
		public int CodigoParametro { get; set; }

		/// <summary>
		/// Código de Parámetro Manual
		/// </summary>
		public string Codigo { get; set; }

		/// <summary>
		/// Código de Sección
		/// </summary>
		public int CodigoSeccion { get; set; }

		/// <summary>
		/// Código de Valor
		/// </summary>
		public int CodigoValor { get; set; }

		/// <summary>
		/// Nombre de Sección
		/// </summary>
		public string NombreSeccion { get; set; }

		/// <summary>
		/// Tipo de Sección
		/// </summary>
		public string TipoSeccion { get; set; }

		/// <summary>
		/// Tipo de Parámetro
		/// </summary>
		public string TipoParametro { get; set; }

		/// <summary>
		/// Descripción del Tipo de Parámetro
		/// </summary>
		public string DescripcionTipoParametro { get; set; }

		/// <summary>
		/// Valor
		/// </summary>
		public string Valor { get; set; }

		/// <summary>
		/// Estado de Registro
		/// </summary>
		public string EstadoRegistro { get; set; }

		/// <summary>
		/// Descripción de Estado de Registro
		/// </summary>
		public string DescripcionEstadoRegistro { get; set; }

		/// <summary>
		/// Motivo de Observación
		/// </summary>
		public string Observacion { get; set; }

		/// <summary>
		/// Usuario de Creación
		/// </summary>
		public string UsuarioCreacion { get; set; }

		/// <summary>
		/// Fecha de Creación
		/// </summary>
		public DateTime? FechaCreacion { get; set; }

		/// <summary>
		/// Terminal de Creación
		/// </summary>
		public string TerminalCreacion { get; set; }

		/// <summary>
		/// Usuario de Modificación
		/// </summary>
		public string UsuarioModificacion { get; set; }

		/// <summary>
		/// Fecha de Modificación
		/// </summary>
		public DateTime? FechaModificacion { get; set; }

		/// <summary>
		/// Terminal de Modificación
		/// </summary>
		public string TerminalModificacion { get; set; }

		/// <summary>
		/// Correlativo
		/// </summary>
		public int Correlativo { get; set; }
		/// <summary>
		/// Nombre Parámetro
		/// </summary>
		public string NombreParametro { get; set; }

		/// <summary>
		/// Nombre Parámetro
		/// </summary>
		public string NombreParametroSeccion { get; set; }
		/// <summary>
		/// Descripción Código Sección
		/// </summary>
		public string sCodigoSeccion { get; set; }

		/// <summary>
		/// Descripción Código Valor
		/// </summary>
		public string sCodigoValor { get; set; }

		#endregion


		#region Operation
		/// <summary>
		/// Permite realizar la búsqueda de los Valores de los Parametros
		/// </summary>
		/// <param name="businessUnitCode">Código de Unidad de Negocio</param>
		/// <param name="parameterCode">Código de Parámetro</param>
		/// <param name="code">Código de Parámetro Manual</param>
		/// <param name="sectionCode">Código de Sección</param>
		/// <param name="valueCode">Código de Valor</param>
		/// <param name="value">Valor</param>
		/// <param name="status">Estado de Registro</param>
		/// <returns>Lista de Valores de Parametros</returns>
		public List<ParameterValueEN> ParameterValueSearch(int businessUnitCode, int? parameterCode, string code, int? sectionCode, int? valueCode, string value, string status)
		{
			List<ParameterValueEN> returnList = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_PARAMETRO_VALOR_SEL",
															new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = businessUnitCode },
															new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = (object)parameterCode ?? DBNull.Value },
															new SqlParameter("CODIGO", SqlDbType.Char) { Value = (object)code ?? DBNull.Value },
															new SqlParameter("CODIGO_SECCION", SqlDbType.Int) { Value = (object)sectionCode ?? DBNull.Value },
															new SqlParameter("CODIGO_VALOR", SqlDbType.Int) { Value = (object)valueCode ?? DBNull.Value },
															new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = (object)value ?? DBNull.Value },
															new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)status ?? DBNull.Value }
															).ToList();
			return returnList;
		}

		/// <summary>
		/// Permite registrar los Valores de los Parametros
		/// </summary>
		/// <param name="register">Valor de Parámetro a registrar</param>
		/// <returns>Cantidad de registro afectados</returns>
		public int ParameterValueRegister(ParameterValueEN register)
		{
			return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_PARAMETRO_VALOR_INS",
														new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = register.CodigoUnidadNegocio },
														new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = register.CodigoParametro },
														new SqlParameter("CODIGO_SECCION", SqlDbType.Int) { Value = register.CodigoSeccion },
														new SqlParameter("CODIGO_VALOR", SqlDbType.Int) { Value = register.CodigoValor },
														new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = (object)register.Valor ?? DBNull.Value },
														new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = register.EstadoRegistro },
														new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = register.UsuarioCreacion },
														new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = register.TerminalCreacion }
													   );
		}

		/// <summary>
		/// Permite actualizar los Valores de los Parametros
		/// </summary>
		/// <param name="register">Valor de Parámetro a actualizar</param>
		/// <returns>Cantidad de registro afectados</returns>
		public int ParameterValueUpdate(ParameterValueEN register)
		{
			return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_PARAMETRO_VALOR_UDP",
														new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = register.CodigoParametro },
														new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = register.CodigoUnidadNegocio },
														new SqlParameter("CODIGO_SECCION", SqlDbType.Int) { Value = register.CodigoSeccion },
														new SqlParameter("CODIGO_VALOR", SqlDbType.Int) { Value = register.CodigoValor },
														new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = (object)register.Valor ?? DBNull.Value },
														new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = register.EstadoRegistro },
														new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = register.Observacion },
														new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = register.UsuarioModificacion },
														new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = register.TerminalModificacion }
													   );
		}

		/// <summary>
		/// Destruye y libera el objeto.
		/// </summary>
		public void Dispose()
		{
		}

		/// <summary>
		/// Permite obtener una lista de Valores de Parámetro por la unidad de negocio, codigo del parametro y codigo del valor.
		/// </summary>
		/// <param name="CodigoUnidadNegocio"></param>
		/// <param name="CodigoPais"></param>
		/// <param name="Codigo"></param>
		/// <param name="CodigoValor"></param>
		/// <returns></returns>
		public List<ParameterValueEN> ListarParametroValorLog4Net(int? CodigoUnidadNegocio, string CodigoPais, string Codigo, int CodigoValor)
		{
			List<ParameterValueEN> resultParametrosValor = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_GET_PARAMETROS_VALOR_POR_CODIGOVALOR_SEL",
				new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.BigInt) { Value = (object)CodigoUnidadNegocio ?? DBNull.Value },
				new SqlParameter("CODIGO_PAIS", SqlDbType.VarChar) { Value = (object)CodigoPais ?? DBNull.Value },
				new SqlParameter("CODIGO", SqlDbType.VarChar) { Value = Codigo },
				new SqlParameter("CODIGO_VALOR", SqlDbType.Int) { Value = CodigoValor }).ToList();
			return resultParametrosValor;
		}

		/// <summary>
		/// Obtener Configuración de Key - EndPoint
		/// </summary>
		/// <param name="businessUnitCode"></param>
		/// <param name="code"></param>
		/// <param name="componentName"></param>
		/// <returns></returns>
		public List<ParameterValueEN> ParameterValueSearchKeyEndpoint(int businessUnitCode, string code, string componentName)
		{
			List<ParameterValueEN> returnList = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_CONFIGURACION_KEY_ENDPOINT_SEL",
				new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = businessUnitCode },
				new SqlParameter("CODIGO", SqlDbType.Char) { Value = (object)code ?? DBNull.Value },
				new SqlParameter("NOMBRE_COMPONENTE", SqlDbType.VarChar) { Value = (object)componentName ?? DBNull.Value }
				).ToList();
			return returnList;
		}

		#endregion

	}
}
