using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;
using Yanbal.SFT.Domain.Entities.Policy.Combination;

namespace Yanbal.SFT.Domain.Entities.Policy.ParameterCombination
{
    /// <summary>
    /// Entidad de Negocio que representa Combinación Parámetro
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140904 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ParameterCombinationEN : PagingBase, IParameterCombination
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<ParameterCombinationEN> repositoryProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterCombinationEN()
        {

        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public ParameterCombinationEN(IRepositoryStoredProcedure<ParameterCombinationEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de Combinación de Parámetro
        /// </summary>
        public int? CodigoCombinacionParametro { get; set; }

        /// <summary>
        /// Código de Combinación
        /// </summary>
        public int CodigoCombinacion { get; set; }

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
        /// Nombre del Parámetro
        /// </summary>
        public string NombreParametro { get; set; }

        /// <summary>
        /// Tipo de Parámetro
        /// </summary>
        public string TipoParametro { get; set; }

        /// <summary>
        /// Orden de Combinación
        /// </summary>
        public byte OrdenCombinacion { get; set; }

        /// <summary>
        /// Importe del Flete
        /// </summary>
        public decimal ImporteFlete { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// Descripción del Valor
        /// </summary>
        public string DescripcionValor { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Descripcion de Estado de Registro
        /// </summary>
        public string DescripcionEstadoRegistro { get; set; }

        /// <summary>
        /// Motivo de Modificación
        /// </summary>
        public string Observacion { get; set; }

        /// <summary>
        /// Usuario de Creación
        /// </summary>
        public string UsuarioCreacion { get; set; }

        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }

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
        #endregion

        #region Operations

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeParameterCombination"></param>
        /// <param name="codeCombinationList"></param>
        /// <param name="businessUnitCode"></param>
        /// <param name="codeParameter"></param>
        /// <param name="combinationOrder"></param>
        /// <param name="value"></param>
        /// <param name="registrationStatus"></param>
        /// <param name="registrationStatusCombination"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<ParameterCombinationEN> ParameterCombinationSearch(int? codeParameterCombination, List<CombinationTableEN> codeCombinationList, int? businessUnitCode, int? codeParameter, int? combinationOrder, string value, string registrationStatus, string registrationStatusCombination, int? pageNo, int? pageSize)
        {
            List<ParameterCombinationEN> listParameterCombination = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_COMBINACION_PARAMETRO_SEL",
                                                               new SqlParameter("CODIGO_COMBINACION_LIST", SqlDbType.Structured) { Value = (object)codeCombinationList.ToDataTable() ?? DBNull.Value, TypeName = "[dbo].[LISTA_PARAMETRO_VALOR_TYPE]" },
                                                               new SqlParameter("CODIGO_COMBINACION_PARAMETRO", SqlDbType.Int) { Value = (object)codeParameterCombination ?? DBNull.Value },
                                                               new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                               new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = (object)codeParameter ?? DBNull.Value },
                                                               new SqlParameter("ORDEN_COMBINACION", SqlDbType.TinyInt) { Value = (object)combinationOrder ?? DBNull.Value },
                                                               new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = (object)value ?? DBNull.Value },
                                                               new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)registrationStatus ?? DBNull.Value },
                                                               new SqlParameter("ESTADO_REGISTRO_COMBINACION", SqlDbType.Char) { Value = (object)registrationStatusCombination ?? DBNull.Value },
                                                               new SqlParameter("PageNo", SqlDbType.Int) { Value = pageNo },
                                                               new SqlParameter("PageSize", SqlDbType.Int) { Value = pageSize }).ToList();
            return listParameterCombination;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeParameterCombination"></param>
        /// <param name="codeCombinationList"></param>
        /// <param name="businessUnitCode"></param>
        /// <param name="codeParameter"></param>
        /// <param name="combinationOrder"></param>
        /// <param name="value"></param>
        /// <param name="registrationStatus"></param>
        /// <param name="registrationStatusCombination"></param>
        /// <returns></returns>
        public List<ParameterCombinationEN> ParameterCombinationSearchService(int? codeParameterCombination, List<CombinationTableEN> codeCombinationList, int? businessUnitCode, int? codeParameter, int? combinationOrder, string value, string registrationStatus, string registrationStatusCombination)
        {
            List<ParameterCombinationEN> listParameterCombination = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_COMBINACION_PARAMETRO_SEARCH_SEL",
                                                                       new SqlParameter("CODIGO_COMBINACION_LIST", SqlDbType.Structured) { Value = (object)codeCombinationList.ToDataTable() ?? DBNull.Value, TypeName = "[dbo].[LISTA_PARAMETRO_VALOR_TYPE]" },
                                                                       new SqlParameter("CODIGO_COMBINACION_PARAMETRO", SqlDbType.Int) { Value = (object)codeParameterCombination ?? DBNull.Value },
                                                                       new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                                       new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = (object)codeParameter ?? DBNull.Value },
                                                                       new SqlParameter("ORDEN_COMBINACION", SqlDbType.TinyInt) { Value = (object)combinationOrder ?? DBNull.Value },
                                                                       new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = (object)value ?? DBNull.Value },
                                                                       new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)registrationStatus ?? DBNull.Value },
                                                                       new SqlParameter("ESTADO_REGISTRO_COMBINACION", SqlDbType.Char) { Value = (object)registrationStatusCombination ?? DBNull.Value }).ToList();
            return listParameterCombination;
        }

        /// <summary>
        /// Permite registrar la Combinación Parámetro
        /// </summary>
        /// <param name="register">Combinación Parámetro a registrar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int ParameterCombinationRegister(ParameterCombinationEN register)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_COMBINACION_PARAMETRO_INS",
                                                                               new SqlParameter("CODIGO_COMBINACION_PARAMETRO", SqlDbType.Int) { Value = register.CodigoCombinacionParametro },
                                                                               new SqlParameter("CODIGO_COMBINACION", SqlDbType.Int) { Value = register.CodigoCombinacion },
                                                                               new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = register.CodigoParametro },
                                                                               new SqlParameter("ORDEN_COMBINACION", SqlDbType.TinyInt) { Value = register.OrdenCombinacion },
                                                                               new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = register.Valor },
                                                                               new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = register.EstadoRegistro },
                                                                               new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = register.UsuarioCreacion },
                                                                               new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = register.TerminalCreacion },
                                                                               new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = register.CodigoUnidadNegocio }
                                                                               );
        }

        /// <summary>
        /// Permite actualizar la Combinación Parámetro
        /// </summary>
        /// <param name="register">Combinación Parámetro a actualizar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int ParameterCombinationUpdate(ParameterCombinationEN register)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_COMBINACION_PARAMETRO_UPD",
                                                                               new SqlParameter("CODIGO_COMBINACION_PARAMETRO", SqlDbType.Int) { Value = (object)register.CodigoCombinacionParametro ?? DBNull.Value },
                                                                               new SqlParameter("CODIGO_COMBINACION", SqlDbType.Int) { Value = register.CodigoCombinacion },
                                                                               new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = register.CodigoParametro },
                                                                               new SqlParameter("ORDEN_COMBINACION", SqlDbType.TinyInt) { Value = (object)register.OrdenCombinacion ?? DBNull.Value },
                                                                               new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = (object)register.Valor ?? DBNull.Value },
                                                                               new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = register.EstadoRegistro },
                                                                               new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = register.Observacion },
                                                                               new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = register.UsuarioModificacion },
                                                                               new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = register.TerminalModificacion },
                                                                               new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = register.CodigoUnidadNegocio }
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

