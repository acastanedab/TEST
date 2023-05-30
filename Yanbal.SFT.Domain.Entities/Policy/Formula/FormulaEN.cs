using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.Formula
{
    /// <summary>
    /// Entidad de Negocio que representa Fórmula
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140910 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class FormulaEN : PagingBase, IFormula
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<FormulaEN> formularepositoryProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public FormulaEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="formularepositoryProcedure">Repositorio basado en store procedure</param>
        public FormulaEN(IRepositoryStoredProcedure<FormulaEN> formularepositoryProcedure)
        {
            this.formularepositoryProcedure = formularepositoryProcedure;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de Formula
        /// </summary>
        public int CodigoFormula { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int CodigoUnidadNegocio { get; set; }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int? CodigoParametro { get; set; }

        /// <summary>
        /// Código de Parámetro Manual
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Descripción del Parámetro
        /// </summary>
        public string DescripcionParametro { get; set; }

        /// <summary>
        /// Valor de Parámetro
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// Descripción del Valor del Parámetro
        /// </summary>
        public string DescripcionValor { get; set; }

        /// <summary>
        /// Operación
        /// </summary>
        public string Operacion { get; set; }

        /// <summary>
        /// Factor
        /// </summary>
        public decimal? Factor { get; set; }

        /// <summary>
        /// Tipo de Factor
        /// </summary>
        public string TipoFactor { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public byte? Orden { get; set; }

        /// <summary>
        /// Motivo de Modificación
        /// </summary>
        public string Observacion { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Descripcion de Estado de Registro
        /// </summary>
        public string DescripcionEstadoRegistro { get; set; }

        /// <summary>
        /// Valor tipo de envio
        /// </summary>
        public string ValorTipoEnvio { get; set; }

        /// <summary>
        /// Descripción tipo de envio
        /// </summary>
        public string DescripcionTipoEnvio { get; set; }

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
        /// Permite realizar la búsqueda de Fórmulas
        /// </summary>
        /// <param name="formulaCode">Código de Fórmula</param>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <param name="parameterCode">Código de Parámetro</param>
        /// <param name="value">Valor</param>
        /// <param name="operation">Operación</param>
        /// <param name="factor">Factor</param>
        /// <param name="factorType">Tipo de Factor</param>
        /// <param name="registrationStatus">Estado de Registro</param>
        /// <returns>Lista de fórmulas</returns>
        public List<FormulaEN> FormulaSearch(int? formulaCode, int? businessUnitCode, int? parameterCode, string value, string operation,
                                             decimal? factor, string factorType, string registrationStatus)
        {
            return FormulaSearch(formulaCode, businessUnitCode, parameterCode, value, operation, factor, factorType, registrationStatus, 1, -1);
        }

        /// <summary>
        /// Permite realizar la búsqueda de Fórmulas
        /// </summary>
        /// <param name="formulaCode">Código de Fórmula</param>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <param name="parameterCode">Código de Parámetro</param>
        /// <param name="value">Valor</param>
        /// <param name="operation">Operación</param>
        /// <param name="factor">Factor</param>
        /// <param name="factorType">Tipo de Factor</param>
        /// <param name="registrationStatus">Estado de Registro</param>
        /// <param name="pageNo">Número de Páginas</param>
        /// <param name="pageSize">Tamaño de Páginas</param>
        /// <returns>Lista de fórmulas</returns>
        public List<FormulaEN> FormulaSearch(int? formulaCode, int? businessUnitCode, int? parameterCode, string value, string operation, 
                                             decimal? factor, string factorType, string registrationStatus, int? pageNo , int? pageSize )
        {
            List<FormulaEN> listFormula = formularepositoryProcedure.ExecWithStoreProcedure("MNT.USP_FORMULA_SEL",
                                                            new SqlParameter("CODIGO_FORMULA", SqlDbType.Int) { Value = (object)formulaCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = (object)parameterCode ?? DBNull.Value },
                                                            new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = (object)value ?? DBNull.Value },
                                                            new SqlParameter("OPERACION", SqlDbType.Char) { Value = (object)operation ?? DBNull.Value },
                                                            new SqlParameter("FACTOR", SqlDbType.Decimal) { Value = (object)factor ?? DBNull.Value },
                                                            new SqlParameter("TIPO_FACTOR", SqlDbType.NChar) { Value = (object)factorType ?? DBNull.Value },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)registrationStatus ?? DBNull.Value },
                                                            new SqlParameter("PageNo", SqlDbType.Int) { Value = pageNo },
                                                            new SqlParameter("PageSize", SqlDbType.Int) { Value = pageSize }
                                                            ).ToList();
            return listFormula;
        }

        /// <summary>
        /// Permite registrar una Fórmula
        /// </summary>
        /// <param name="formula">Fórmula a registrar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int FormulaRegister(FormulaEN formula)
        {
            return formularepositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_FORMULA_INS",
                                                    new SqlParameter("CODIGO_FORMULA", SqlDbType.Int) { Value = formula.CodigoFormula },
                                                    new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = formula.CodigoUnidadNegocio },
                                                    new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = formula.CodigoParametro },
                                                    new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = formula.Valor },
                                                    new SqlParameter("OPERACION", SqlDbType.Char) { Value = formula.Operacion },
                                                    new SqlParameter("FACTOR", SqlDbType.Decimal) { Value = formula.Factor },
                                                    new SqlParameter("TIPO_FACTOR", SqlDbType.NChar) { Value = formula.TipoFactor },
                                                    new SqlParameter("VALOR_TIPO_ENVIO", SqlDbType.NVarChar) { Value = (object)formula.ValorTipoEnvio ?? DBNull.Value },
                                                    new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = formula.EstadoRegistro },
                                                    new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = formula.UsuarioCreacion },
                                                    new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = formula.TerminalCreacion }
                                                    );
        }

        /// <summary>
        /// Permite modificar una Fórmula
        /// </summary>
        /// <param name="formula">Fórmula a modificar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int FormulaUpdate(FormulaEN formula)
        {
            return formularepositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_FORMULA_UPD",
                                                    new SqlParameter("CODIGO_FORMULA", SqlDbType.Int) { Value = formula.CodigoFormula },
                                                    new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = formula.CodigoUnidadNegocio },
                                                    new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = (object)formula.CodigoParametro ?? DBNull.Value },
                                                    new SqlParameter("VALOR", SqlDbType.NVarChar) { Value = (object)formula.Valor ?? DBNull.Value },
                                                    new SqlParameter("OPERACION", SqlDbType.Char) { Value = (object)formula.Operacion ?? DBNull.Value },
                                                    new SqlParameter("FACTOR", SqlDbType.Decimal) { Value = (object)formula.Factor ?? DBNull.Value },
                                                    new SqlParameter("TIPO_FACTOR", SqlDbType.NChar) { Value = (object)formula.TipoFactor ?? DBNull.Value },
                                                    new SqlParameter("ORDEN", SqlDbType.TinyInt) { Value = (object)formula.Orden ?? DBNull.Value },
                                                    new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = formula.Observacion },
                                                    new SqlParameter("VALOR_TIPO_ENVIO", SqlDbType.NVarChar) { Value = (object)formula.ValorTipoEnvio ?? DBNull.Value },
                                                    new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = formula.EstadoRegistro },
                                                    new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = formula.UsuarioModificacion },
                                                    new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = formula.TerminalModificacion }
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
