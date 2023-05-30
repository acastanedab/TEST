using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.Culture
{
    /// <summary>
    /// Entidad de Negocio que representa la Cultura
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class CultureEN : PagingBase, ICulture
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<CultureEN> repositoryProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CultureEN()
        {
        }
        
        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public CultureEN(IRepositoryStoredProcedure<CultureEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de Cultura
        /// </summary>
        public string CodigoCultura { get; set; }

        /// <summary>
        /// Código de Idioma
        /// </summary>
        public string CodigoIdioma { get; set; }

        /// <summary>
        /// Nombre de Idioma
        /// </summary>
        public string NombreIdioma { get; set; }

        /// <summary>
        /// Código de País
        /// </summary>
        public string CodigoPais { get; set; }

        /// <summary>
        /// Nombre de País
        /// </summary>
        public string NombrePais { get; set; }

        /// <summary>
        /// Código de Formato de Fecha Corta
        /// </summary>
        public int CodigoFormatoFechaCorta { get; set; }

        /// <summary>
        /// Descripión de Formato de Fecha Corta
        /// </summary>
        public string DescripcionFormatoFechaCorta { get; set; }

        /// <summary>
        /// Código de Formato de Fecha Larga
        /// </summary>
        public int CodigoFormatoFechaLarga { get; set; }

        /// <summary>
        /// Descripión de Formato de Fecha Larga
        /// </summary>
        public string DescripcionFormatoFechaLarga { get; set; }

        /// <summary>
        /// Código de Formato de Hora Corta
        /// </summary>
        public int CodigoFormatoHoraCorta { get; set; }

        /// <summary>
        /// Descripión de Formato de Hora Corta
        /// </summary>
        public string DescripcionFormatoHoraCorta { get; set; }

        /// <summary>
        /// Código de Formato de Hora Larga
        /// </summary>
        public int CodigoFormatoHoraLarga { get; set; }

        /// <summary>
        /// Descripión de Formato de Hora Larga
        /// </summary>
        public string DescripcionFormatoHoraLarga { get; set; }
                
        /// <summary>
        /// Código de Formato de Número Entero
        /// </summary>
        public int CodigoFormatoNumeroEntero { get; set; }

        /// <summary>
        /// Descripción de Formato de Número Entero
        /// </summary>
        public string DescripcionFormatoNumeroEntero { get; set; }

        /// <summary>
        /// Código de Formato de Número Decimal
        /// </summary>
        public int CodigoFormatoNumeroDecimal { get; set; }

        /// <summary>
        /// Descripción de Formato de Número Decimal
        /// </summary>
        public string DescripcionFormatoNumeroDecimal { get; set; }

        /// <summary>
        /// Límite Superior de Año
        /// </summary>
        public short? LimiteSuperiorAnio { get; set; }

        /// <summary>
        /// Observación
        /// </summary>
        public string Observacion { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Descripción de Estado de Registro
        /// </summary>
        public string DescripcionEstadoRegistro { get; set; }
        
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

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int CodigoUnidadNegocio { get; set; }
        #endregion

        #region Operations
        /// <summary>
        /// Permite realizar la búsqueda de Cultura
        /// </summary>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <param name="culturaCode">Código de Cultura</param>
        /// <param name="languageCode">Código de Idioma</param>
        /// <param name="countryCode">Código de Pais</param>
        /// <param name="codeShortDateFormat">Código Formato Fecha Corta</param>
        /// <param name="codeLongDateFormat">Código Formato Fecha Long</param>
        /// <param name="codeShortTimeFormat">Código Formato Hora Corta</param>
        /// <param name="codeLongTimeFormat">Código Formato Hora Long</param>
        /// <param name="codeFormatIntegerNumber">Código Formato Número Entero</param>
        /// <param name="codeFormatDecimalNumber">Código Formato Número Decimal</param>
        /// <param name="upperLimitYear">Límite superior Año</param>
        /// <param name="registrationStatus">Estado de Registro</param>
        /// <param name="pageNo">Número de Pagina</param>
        /// <param name="pageSize">Tamaño de Pagina</param>
        /// <returns>Lista de Cultura</returns>
        public List<CultureEN> CultureSearch(int? businessUnitCode,
                                                string culturaCode,
                                                string languageCode,
                                                string countryCode,
                                                int? codeShortDateFormat,
                                                int? codeLongDateFormat,
                                                int? codeShortTimeFormat,
                                                int? codeLongTimeFormat,
                                                int? codeFormatIntegerNumber,
                                                int? codeFormatDecimalNumber,
                                                short? upperLimitYear,
                                                string registrationStatus, 
                                                int? pageNo, 
                                                int? pageSize)
        {
            return repositoryProcedure.ExecWithStoreProcedure("MNT.USP_CULTURA_SEL",
                                                             new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                             new SqlParameter("CODIGO_CULTURA", SqlDbType.Char) { Value = (object)culturaCode ?? DBNull.Value },
                                                             new SqlParameter("CODIGO_IDIOMA", SqlDbType.Char) { Value = (object)languageCode ?? DBNull.Value },
                                                             new SqlParameter("CODIGO_PAIS", SqlDbType.Char) { Value = (object)countryCode ?? DBNull.Value },
                                                             new SqlParameter("CODIGO_FORMATO_FECHA_CORTA", SqlDbType.Int) { Value = (object)codeShortDateFormat ?? DBNull.Value },
                                                             new SqlParameter("CODIGO_FORMATO_FECHA_LARGA", SqlDbType.Int) { Value = (object)codeLongDateFormat ?? DBNull.Value },
                                                             new SqlParameter("CODIGO_FORMATO_HORA_CORTA", SqlDbType.Int) { Value = (object)codeShortTimeFormat ?? DBNull.Value },
                                                             new SqlParameter("CODIGO_FORMATO_HORA_LARGA", SqlDbType.Int) { Value = (object)codeLongTimeFormat ?? DBNull.Value },
                                                             new SqlParameter("CODIGO_FORMATO_NUMERO_ENTERO", SqlDbType.Int) { Value = (object)codeFormatIntegerNumber ?? DBNull.Value },
                                                             new SqlParameter("CODIGO_FORMATO_NUMERO_DECIMAL", SqlDbType.Int) { Value = (object)codeFormatDecimalNumber ?? DBNull.Value },
                                                             new SqlParameter("LIMITE_SUPERIOR_ANIO", SqlDbType.SmallInt) { Value = (object)upperLimitYear ?? DBNull.Value },
                                                             new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)registrationStatus ?? DBNull.Value },
                                                             new SqlParameter("PageNo", SqlDbType.Int) { Value = pageNo },
                                                             new SqlParameter("PageSize", SqlDbType.Int) { Value = pageSize }
                                                            ).ToList();
        }

        /// <summary>
        /// Permite registrar la Cultura
        /// </summary>
        /// <param name="culture">Cultura a registrar</param>
        /// <returns>CAntidad de Registros Afectado</returns>
        public int CultureRegister(CultureEN culture)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_CULTURA_INS",
                                                    new SqlParameter("CODIGO_CULTURA", SqlDbType.Char) { Value = culture.CodigoCultura },
                                                    new SqlParameter("CODIGO_IDIOMA", SqlDbType.Char) { Value = culture.CodigoIdioma },
                                                    new SqlParameter("CODIGO_PAIS", SqlDbType.Char) { Value = culture.CodigoPais },
                                                    new SqlParameter("CODIGO_FORMATO_FECHA_CORTA", SqlDbType.Int) { Value = culture.CodigoFormatoFechaCorta },
                                                    new SqlParameter("CODIGO_FORMATO_FECHA_LARGA", SqlDbType.Int) { Value = culture.CodigoFormatoFechaLarga },
                                                    new SqlParameter("CODIGO_FORMATO_HORA_CORTA", SqlDbType.Int) { Value = culture.CodigoFormatoHoraCorta },
                                                    new SqlParameter("CODIGO_FORMATO_HORA_LARGA", SqlDbType.Int) { Value = culture.CodigoFormatoHoraLarga },
                                                    new SqlParameter("CODIGO_FORMATO_NUMERO_ENTERO", SqlDbType.Int) { Value = culture.CodigoFormatoNumeroEntero },
                                                    new SqlParameter("CODIGO_FORMATO_NUMERO_DECIMAL", SqlDbType.Int) { Value = culture.CodigoFormatoNumeroDecimal },
                                                    new SqlParameter("LIMITE_SUPERIOR_ANIO", SqlDbType.SmallInt) { Value = culture.LimiteSuperiorAnio },
                                                    new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = culture.EstadoRegistro },
                                                    new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = culture.UsuarioCreacion },
                                                    new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = culture.TerminalCreacion },
                                                    new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = culture.CodigoUnidadNegocio }
                                                    );
        }

        /// <summary>
        /// Permite modificar una Cultura
        /// </summary>
        /// <param name="culture">Cultura a modificar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int CultureUpdate(CultureEN culture)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_CULTURA_UPD",
                                                new SqlParameter("CODIGO_CULTURA", SqlDbType.Char) { Value = culture.CodigoCultura },
                                                new SqlParameter("CODIGO_IDIOMA", SqlDbType.Char) { Value = culture.CodigoIdioma },
                                                new SqlParameter("CODIGO_PAIS", SqlDbType.Char) { Value = culture.CodigoPais },
                                                new SqlParameter("CODIGO_FORMATO_FECHA_CORTA", SqlDbType.Int) { Value = culture.CodigoFormatoFechaCorta },
                                                new SqlParameter("CODIGO_FORMATO_FECHA_LARGA", SqlDbType.Int) { Value = culture.CodigoFormatoFechaLarga },
                                                new SqlParameter("CODIGO_FORMATO_HORA_CORTA", SqlDbType.Int) { Value = culture.CodigoFormatoHoraCorta },
                                                new SqlParameter("CODIGO_FORMATO_HORA_LARGA", SqlDbType.Int) { Value = culture.CodigoFormatoHoraLarga },
                                                new SqlParameter("CODIGO_FORMATO_NUMERO_ENTERO", SqlDbType.Int) { Value = culture.CodigoFormatoNumeroEntero },
                                                new SqlParameter("CODIGO_FORMATO_NUMERO_DECIMAL", SqlDbType.Int) { Value = culture.CodigoFormatoNumeroDecimal },
                                                new SqlParameter("LIMITE_SUPERIOR_ANIO", SqlDbType.SmallInt) { Value = culture.LimiteSuperiorAnio },
                                                new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = culture.Observacion },
                                                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = culture.EstadoRegistro },
                                                new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = culture.UsuarioModificacion },
                                                new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = culture.TerminalModificacion },
                                                new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = culture.CodigoUnidadNegocio }
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
