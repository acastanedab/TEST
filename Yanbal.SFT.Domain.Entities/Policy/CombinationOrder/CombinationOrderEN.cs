using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.CombinationOrder
{
    /// <summary>
    /// Entidad de Negocio que representa Orden de Combinación
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class CombinationOrderEN : PagingBase, ICombinationOrder
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<CombinationOrderEN> repositoryProcedure;
        //Fin Sonar
        #region Constructors
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CombinationOrderEN()
        {
        }
        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public CombinationOrderEN(IRepositoryStoredProcedure<CombinationOrderEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Código de Orden de Combinación
        /// </summary>
        public int CodigoOrdenCombinacion { get; set; }

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
        /// Nombre de Parámetro
        /// </summary>
        public string NombreParametro { get; set; }        

        /// <summary>
        /// Orden del Párametro en la Combinación
        /// </summary>
        public byte Orden { get; set; }
        
        /// <summary>
        /// Motivo de Observación
        /// </summary>
        public string Observacion { get; set; }

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
        #endregion

        #region Operations

         /// <summary>
        /// Permite realizar la búsqueda de Orden de Combinación
        /// </summary>
        /// <param name="orderCodeCombination">Código de Orden de Combinación</param>
        /// <param name="businessUnitCode">Código de la Unidad del Negocio</param>
        /// <param name="parameterCode">Código del Parámetro</param>
        /// <param name="code">Código del Parámetro Manual</param>
        /// <param name="order">Número de Orden</param>
        /// <param name="status">Estado de Registro</param>
        /// <returns>Lista de Orden de Combinación</returns>
        public List<CombinationOrderEN> CombinationOrderSearch(
            int? orderCodeCombination,
            int? businessUnitCode,
            int? parameterCode,
            string code,
            byte? order,
            string status)
        {
            return CombinationOrderSearch(orderCodeCombination, businessUnitCode, parameterCode, code, order, status, 1, -1);
        }

        /// <summary>
        /// Permite realizar la búsqueda de Orden de Combinación
        /// </summary>
        /// <param name="orderCodeCombination">Código de Orden de Combinación</param>
        /// <param name="businessUnitCode">Código de la Unidad del Negocio</param>
        /// <param name="parameterCode">Código del Parámetro</param>
        /// <param name="code">Código del Parámetro Manual</param>
        /// <param name="order">Número de Orden</param>
        /// <param name="status">Estado de Registro</param>
        /// <param name="pageNo">Número de Página</param>
        /// <param name="pageSize">Tamaño de Página</param>
        /// <returns>Lista de Orden de Combinación</returns>
        public List<CombinationOrderEN> CombinationOrderSearch(
            int? orderCodeCombination,
            int? businessUnitCode,
            int? parameterCode, 
            string code,
            byte? order,
            string status, 
            int? pageNo, 
            int? pageSize)
        {
            return repositoryProcedure.ExecWithStoreProcedure("MNT.USP_ORDEN_COMBINACION_SEL",
                                                            new SqlParameter("CODIGO_ORDEN_COMBINACION", SqlDbType.Int) { Value = (object)orderCodeCombination ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = (object)parameterCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO", SqlDbType.Char) { Value = (object)code ?? DBNull.Value },
                                                            new SqlParameter("ORDEN", SqlDbType.TinyInt) { Value = (object)order ?? DBNull.Value },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)status ?? DBNull.Value },
                                                            new SqlParameter("PageNo", SqlDbType.Int) { Value = (object)pageNo ?? DBNull.Value },
                                                            new SqlParameter("PageSize", SqlDbType.Int) { Value = (object)pageSize ?? DBNull.Value }
                                                            ).ToList();
        }

        /// <summary>
        /// Permite registrar el Orden de Combinación
        /// </summary>
        /// <param name="combinationOrder">Orden de Combinación</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int CombinationOrderRegister(CombinationOrderEN combinationOrder)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_ORDEN_COMBINACION_INS",
                                                            new SqlParameter("CODIGO_ORDEN_COMBINACION", SqlDbType.Int) { Value = combinationOrder.CodigoOrdenCombinacion },
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = combinationOrder.CodigoUnidadNegocio },
                                                            new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = combinationOrder.CodigoParametro },
                                                            new SqlParameter("ORDEN", SqlDbType.TinyInt) { Value = combinationOrder.Orden },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = combinationOrder.EstadoRegistro },
                                                            new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = combinationOrder.UsuarioCreacion },
                                                            new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = combinationOrder.TerminalCreacion}
                                                            );
        }

        /// <summary>
        /// Permite actualizar el Orden de Combinación
        /// </summary>
        /// <param name="combinationOrder">Orden de Combinación</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int CombinationOrderUpdate(CombinationOrderEN combinationOrder)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_ORDEN_COMBINACION_UPD",
                                                            new SqlParameter("CODIGO_ORDEN_COMBINACION", SqlDbType.Int) { Value = combinationOrder.CodigoOrdenCombinacion },
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = combinationOrder.CodigoUnidadNegocio },
                                                            new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = combinationOrder.Observacion },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = combinationOrder.EstadoRegistro },
                                                            new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = combinationOrder.UsuarioModificacion },
                                                            new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = combinationOrder.TerminalModificacion }
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