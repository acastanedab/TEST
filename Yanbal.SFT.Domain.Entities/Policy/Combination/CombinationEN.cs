using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.Combination
{
    /// <summary>
    /// Entidad de Negocio que representa Combinación
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class CombinationEN : PagingBase, ICombination
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<CombinationEN> repositoryProcedure;
        //Fin Sonar
        #region Constructors

        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CombinationEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public CombinationEN(IRepositoryStoredProcedure<CombinationEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Código de Combinación
        /// </summary>
        public int CodigoCombinacion { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int CodigoUnidadNegocio { get; set; }

        /// <summary>
        /// Importe de Flete
        /// </summary>
        public decimal ImporteFlete { get; set; }

        /// <summary>
        /// Combinación
        /// </summary>
        public string Combinacion { get; set; }
 
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Descripcion Estado 
        /// </summary>
        public string DescripcionEstadoRegistro { get; set; }

        /// <summary>
        /// Motivo de Observación
        /// </summary>
        public string Observacion { get; set; }


        /// <summary>
        /// Motivo de Observación
        /// </summary>
        public string TipoEnvio { get; set; }

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
        /// Permite realizar la búsqueda de Combinaciones
        /// </summary>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <param name="combinationCode">Código de Combinación</param>
        /// <param name="amountFreight">Monto de Flete</param>
        /// <param name="parameterCode">Código de Parámetro</param>
        /// <param name="value">Valor del Parámetro</param>
        /// <param name="status">Estado de Registro</param>
        /// <param name="pageNo">Número de Páginas</param>
        /// <param name="pageSize">Tamaño de Páginas</param>
        /// <returns>Lista de parametros</returns>
        public List<CombinationEN> CombinationSearch(
            int? businessUnitCode,
            int? combinationCode,
            decimal? amountFreight,
            int? parameterCode,
            string value, 
            string status, 
            int? pageNo, 
            int? pageSize)
        {
            List<CombinationEN> listaRetorno = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_COMBINACION_SEL",
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_COMBINACION", SqlDbType.Int) { Value = (object)combinationCode ?? DBNull.Value },
                                                            new SqlParameter("IMPORTE_FLETE", SqlDbType.Decimal) { Value = (object)amountFreight ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = (object)parameterCode ?? DBNull.Value },
                                                            new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = (object)value ?? DBNull.Value },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)status ?? DBNull.Value },
                                                            new SqlParameter("PageNo", SqlDbType.Int) { Value = pageNo },
                                                            new SqlParameter("PageSize", SqlDbType.Int) { Value = pageSize }
                                                            ).ToList();
            return listaRetorno;
        } 

        /// <summary>
        /// Permite registrar la Combinación
        /// </summary>
        /// <param name="combination">Combinación a registrar</param>
        /// <returns>Cantidad de registro afectados</returns>   
        public int CombinationRegister(CombinationEN combination)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_COMBINACION_INS",
                                                    new SqlParameter("CODIGO_COMBINACION", SqlDbType.Int) { Value = combination.CodigoCombinacion },
                                                    new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = combination.CodigoUnidadNegocio },
                                                    new SqlParameter("IMPORTE_FLETE", SqlDbType.NVarChar) { Value = combination.ImporteFlete },
                                                    new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = combination.EstadoRegistro },
                                                    new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = combination.UsuarioCreacion },
                                                    new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = combination.TerminalCreacion }
                                                    );
        }
        
        /// <summary>
        /// Permite actualizar la Combinación
        /// </summary>
        /// <param name="combination">Combinación a actualizar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int CombinationUpdate(CombinationEN combination)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_COMBINACION_UPD",
                                                    new SqlParameter("CODIGO_COMBINACION", SqlDbType.Int) { Value = combination.CodigoCombinacion },
                                                    new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = combination.CodigoUnidadNegocio },
                                                    new SqlParameter("IMPORTE_FLETE", SqlDbType.NVarChar) { Value = combination.ImporteFlete },
                                                    new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = combination.EstadoRegistro },
                                                    new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = combination.Observacion },
                                                    new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = combination.UsuarioModificacion},
                                                    new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = combination.TerminalModificacion }
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
