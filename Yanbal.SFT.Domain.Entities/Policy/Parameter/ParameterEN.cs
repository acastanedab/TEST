using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.Parameter
{
    /// <summary>
    /// Entidad de Negocio que representa Parámetro
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ParameterEN : PagingBase, IParameter
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<ParameterEN> repositoryProcedure;
        //Fin Sonar
        #region Constructors
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterEN()
        {
        }
        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public ParameterEN(IRepositoryStoredProcedure<ParameterEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Código de Parametro 
        /// </summary>
        public int CodigoParametro { get; set; }

        /// <summary>
        /// Código de Parametro Manual 
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int CodigoUnidadNegocio { get; set; }

        /// <summary>
        /// Tipo de Parametro
        /// </summary>
        public string TipoParametro { get; set; }
 
        /// <summary>
        /// Descripción de Tipo de Parametro
        /// </summary>
        public string DescripcionTipoParametro { get; set; }

        /// <summary>
        /// Nombre del Parámetro
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción del Parámetro
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Indicador que Permite Saber si el Parámetro es de Sistema o de Negocio
        /// </summary>
        public bool IndicadorParametroSistema { get; set; }

        /// <summary>
        /// Indicador que Permite Agregar Valor
        /// </summary>
        public bool IndicadorPermiteAgregarValor { get; set; }

        /// <summary>
        /// Indicador que Permite Modificar Valor 
        /// </summary>
        public bool IndicadorPermiteModificarValor { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Descripcion Estado  de Registro
        /// </summary>
        public string DescripcionEstadoRegistro { get; set; }
                
        /// <summary>
        /// Usuario Creación
        /// </summary>
        public string UsuarioCreacion { get; set; }

        /// <summary>
        /// Fecha Creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Terminal Creación
        /// </summary>
        public string TerminalCreacion { get; set; }

        /// <summary>
        /// Usuario Modificación
        /// </summary>
        public string UsuarioModificacion { get; set; }

        /// <summary>
        /// Fecha Modificación
        /// </summary>
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// Terminal Modificación
        /// </summary>
        public string TerminalModificacion { get; set; }

        /// <summary>
        /// Motivo de Observación
        /// </summary>
        public string Observacion { get; set; }
 
        #endregion

        #region Operations

        /// <summary>
        /// Permite realizar la búsqueda de los Parametros
        /// </summary>
        /// <param name="businessUnitCode">Código de la Unidad del Negocio</param>
        /// <param name="parameterCode">Código del Parámetro</param>
        /// <param name="code">Código</param>
        /// <param name="codeApproximate">Código Aproximado</param>
        /// <param name="name">Nombre</param>
        /// <param name="description">Descripción</param>
        /// <param name="typeParameter">Tipo Entrega</param>
        /// <param name="systemParameterIndicator">Indicador de parámetro de Sistema</param>
        /// <param name="allowAddValueIndicator">Indicador que permite agregar valor</param>
        /// <param name="allowModifyValueIndicator">Indicador que permite modificar valor</param>
        /// <param name="status">Estado de Registro</param>
        /// <returns>Lista de Parametros</returns>
        public List<ParameterEN> ParameterSearch(
            int? businessUnitCode,
            int? parameterCode,
            string code,
            string codeApproximate,
            string name,
            string description,
            string typeParameter,
            bool? systemParameterIndicator,
            bool? allowAddValueIndicator,
            bool? allowModifyValueIndicator,
            string status)
        {
            return ParameterSearch( businessUnitCode, parameterCode,code,codeApproximate,name,description, 
                typeParameter,systemParameterIndicator,allowAddValueIndicator,allowModifyValueIndicator,status, 1, -1);
        }

        /// <summary>
        /// Permite realizar la búsqueda de los Parametros
        /// </summary>
        /// <param name="businessUnitCode">Código de la Unidad del Negocio</param>
        /// <param name="parameterCode">Código del Parámetro</param>
        /// <param name="code">Código</param>
        /// <param name="codeApproximate">Código Aproximado</param>
        /// <param name="name">Nombre</param>
        /// <param name="description">Descripción</param>
        /// <param name="typeParameter">Tipo Entrega</param>
        /// <param name="systemParameterIndicator">Indicador de parámetro de Sistema</param>
        /// <param name="allowAddValueIndicator">Indicador que permite agregar valor</param>
        /// <param name="allowModifyValueIndicator">Indicador que permite modificar valor</param>
        /// <param name="status">Estado de Registro</param>
        /// <param name="pageNo">Número de Página</param>
        /// <param name="pageSize">Tamaño de Página</param>
        /// <returns>Lista de Parametros</returns>
        public List<ParameterEN> ParameterSearch(
            int? businessUnitCode,
            int? parameterCode, 
            string code,
            string codeApproximate,
            string name, 
            string description, 
            string typeParameter,
            bool? systemParameterIndicator,
            bool? allowAddValueIndicator,
            bool? allowModifyValueIndicator,
            string status, 
            int? pageNo, 
            int? pageSize)
        {
            return repositoryProcedure.ExecWithStoreProcedure("MNT.USP_PARAMETRO_SEL",
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = (object)parameterCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO", SqlDbType.Char) { Value = (object)code ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_APROXIMADO", SqlDbType.NVarChar) { Value = (object)codeApproximate ?? DBNull.Value },
                                                            new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = (object)name ?? DBNull.Value },
                                                            new SqlParameter("DESCRIPCION", SqlDbType.NVarChar) { Value = (object)description ?? DBNull.Value },
                                                            new SqlParameter("TIPO_PARAMETRO", SqlDbType.Char) { Value = (object)typeParameter ?? DBNull.Value },
                                                            new SqlParameter("INDICADOR_PARAMETRO_SISTEMA", SqlDbType.Bit) { Value = (object)systemParameterIndicator ?? DBNull.Value },
                                                            new SqlParameter("INDICADOR_PERMITE_AGREGAR_VALOR", SqlDbType.Bit) { Value = (object)allowAddValueIndicator ?? DBNull.Value },
                                                            new SqlParameter("INDICADOR_PERMITE_MODIFICAR_VALOR", SqlDbType.Bit) { Value = (object)allowModifyValueIndicator ?? DBNull.Value },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)status ?? DBNull.Value },
                                                            new SqlParameter("PageNo", SqlDbType.Int) { Value = (object)pageNo ?? DBNull.Value },
                                                            new SqlParameter("PageSize", SqlDbType.Int) { Value = (object)pageSize ?? DBNull.Value }
                                                            ).ToList();
        } 

        /// <summary>
        /// Permite registrar los Parametros
        /// </summary>
        /// <param name="parameter">Parámetro a registrar</param>
        /// <returns>Cantidad de registro afectados</returns>   
        public int ParameterRegister(ParameterEN parameter)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_PARAMETRO_INS",
                                                    new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = parameter.CodigoUnidadNegocio },
                                                    new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = parameter.CodigoParametro },
                                                    new SqlParameter("CODIGO", SqlDbType.Char) { Value = parameter.Codigo },
                                                    new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = parameter.Nombre },
                                                    new SqlParameter("DESCRIPCION", SqlDbType.NVarChar) { Value = parameter.Descripcion },
                                                    new SqlParameter("TIPO_PARAMETRO", SqlDbType.NVarChar) { Value = parameter.TipoParametro },
                                                    new SqlParameter("INDICADOR_PERMITE_AGREGAR_VALOR", SqlDbType.Bit) { Value = parameter.IndicadorPermiteAgregarValor },
                                                    new SqlParameter("INDICADOR_PERMITE_MODIFICAR_VALOR", SqlDbType.Bit) { Value = parameter.IndicadorPermiteModificarValor },
                                                    new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = parameter.EstadoRegistro },
                                                    new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = parameter.UsuarioCreacion },
                                                    new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = parameter.TerminalCreacion }
                                                    );
        }
        
        /// <summary>
        /// Permite actualizar los Parametros
        /// </summary>
        /// <param name="parameter">Parámetro a actualizar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int ParameterUpdate(ParameterEN parameter)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_PARAMETRO_UPD",
                                                    new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = parameter.CodigoUnidadNegocio },
                                                    new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = parameter.CodigoParametro },
                                                    new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = parameter.Nombre },
                                                    new SqlParameter("DESCRIPCION", SqlDbType.NVarChar) { Value = parameter.Descripcion },
                                                    new SqlParameter("INDICADOR_PERMITE_AGREGAR_VALOR", SqlDbType.Bit) { Value = parameter.IndicadorPermiteAgregarValor },
                                                    new SqlParameter("INDICADOR_PERMITE_MODIFICAR_VALOR", SqlDbType.Bit) { Value = parameter.IndicadorPermiteModificarValor },
                                                    new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = parameter.EstadoRegistro },
                                                    new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = parameter.Observacion },
                                                    new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = parameter.UsuarioModificacion },
                                                    new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = parameter.TerminalModificacion }
                                                    );
        }

        /// <summary>
        /// Destruye y libera el objeto.
        /// </summary>
        public void Dispose()
        {
        }
        #endregion
    }
}
