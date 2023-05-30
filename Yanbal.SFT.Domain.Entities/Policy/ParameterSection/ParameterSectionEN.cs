using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.ParameterSection
{
    /// <summary>
    /// Entidad de Negocio que representa Parámetro Sección
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ParameterSectionEN : PagingBase, IParameterSection
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<ParameterSectionEN> repositoryProcedure;
        //Fin Sonar
        #region Constructors
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterSectionEN()
        {
        }
        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public ParameterSectionEN(IRepositoryStoredProcedure<ParameterSectionEN> repositoryProcedure)
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
        /// Código de Unidad de Negocio
        /// </summary>
        public int CodigoUnidadNegocio { get; set; }

        /// <summary>
        /// Código Seccion
        /// </summary>
        public int CodigoSeccion { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Tipo Sección
        /// </summary>
        public string TipoSeccion { get; set; }
        
        /// <summary>
        /// Indicador que determina si la Sección es Solo de Lectura
        /// </summary>
        public bool IndicadorSoloLectura { get; set; }

        /// <summary>
        /// Indicador que determina si la Sección es un dato Obligatorio a Registrar
        /// </summary>
        public bool IndicadorObligatorio { get; set; }

        /// <summary>
        /// Indicador que determina si la Sección es un Valor Inicial o un Valor Final del Rango
        /// </summary>
        public string IndicadorRango { get; set; }

        /// <summary>
        /// Indicador que determina si es una Sección creada automaticamente por el tipo de Parámetro
        /// </summary>
        public bool IndicadorCreacion { get; set; }        

        /// <summary>
        /// Descripción Tipo Sección
        /// </summary>
        public string DescripcionTipoSeccion { get; set; }

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
        public string Observacion { get; set; }

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
        /// Permite realizar la búsqueda de las Secciones de los Parametros
        /// </summary>
        /// <param name="businessUnitCode">Código Unidad Negocio</param>
        /// <param name="parameterCode">Código Parametro</param>
        /// <param name="sectionCode">Código Sección</param>
        /// <param name="name">Nombre</param>
        /// <param name="readOnlyIndicator">Indicador de Solo Lectura</param>
        /// <param name="requiredIndicator">Indicador de Sección Requerida</param>
        /// <param name="sectionType">Tipo de Sección</param>
        /// <param name="status">Estado</param>
        /// <returns>Lista de Secciones de Parametros</returns>
        public List<ParameterSectionEN> ParameterSectionSearch(int? businessUnitCode, int? parameterCode, int? sectionCode, string name, bool? readOnlyIndicator, bool? requiredIndicator, string sectionType, string status)
        {
            return ParameterSectionSearch (businessUnitCode, parameterCode, sectionCode, name, readOnlyIndicator, requiredIndicator, sectionType,  status,   1,  -1);
        }

        /// <summary>
        /// Permite realizar la búsqueda de las Secciones de los Parametros
        /// </summary>
        /// <param name="businessUnitCode">Código Unidad Negocio</param>
        /// <param name="parameterCode">Código Parametro</param>
        /// <param name="sectionCode">Código Sección</param>
        /// <param name="name">Nombre</param>
        /// <param name="readOnlyIndicator">Indicador de Solo Lectura</param>
        /// <param name="requiredIndicator">Indicador de Sección Requerida</param>
        /// <param name="sectionType">Tipo de Sección</param>
        /// <param name="status">Estado</param>
        /// <param name="pageNo">Número de Pagína</param>
        /// <param name="pageSize">Tamaño de Pagína, cantidad de registros que mostrará</param>
        /// <returns>Lista de Secciones de Parametros</returns>
        public List<ParameterSectionEN> ParameterSectionSearch(int? businessUnitCode, int? parameterCode, int? sectionCode, string name, bool? readOnlyIndicator, bool? requiredIndicator, string sectionType, string status, int? pageNo , int? pageSize)
        {
            List<ParameterSectionEN> returnList = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_PARAMETRO_SECCION_SEL",
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = (object)parameterCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_SECCION", SqlDbType.Int) { Value = (object)sectionCode ?? DBNull.Value },
                                                            new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = (object)name ?? DBNull.Value },
                                                            new SqlParameter("INDICADOR_SOLO_LECTURA", SqlDbType.Bit) { Value = (object)readOnlyIndicator ?? DBNull.Value },
                                                            new SqlParameter("INDICADOR_OBLIGATORIO", SqlDbType.Bit) { Value = (object)requiredIndicator ?? DBNull.Value },
                                                            new SqlParameter("TIPO_SECCION", SqlDbType.Char) { Value = (object)sectionType ?? DBNull.Value },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)status ?? DBNull.Value },
                                                            new SqlParameter("PageNo", SqlDbType.Int) { Value = pageNo },
                                                            new SqlParameter("PageSize", SqlDbType.Int) { Value = pageSize }
                                                            ).ToList();
            return returnList;
        }

        /// <summary>
        /// Permite registrar las Secciones de los Parametros
        /// </summary>
        /// <param name="register">Sección de Parámetro a registrar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int ParameterSectionRegister(ParameterSectionEN register)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_PARAMETRO_SECCION_INS",
                                                        new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = register.CodigoParametro },
                                                        new SqlParameter("CODIGO_SECCION", SqlDbType.Int) { Value = register.CodigoSeccion },
                                                        new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = register.Nombre },
                                                        new SqlParameter("INDICADOR_SOLO_LECTURA", SqlDbType.Bit) { Value = register.IndicadorSoloLectura },
                                                        new SqlParameter("INDICADOR_OBLIGATORIO", SqlDbType.Bit) { Value = register.IndicadorObligatorio },
                                                        new SqlParameter("INDICADOR_RANGO", SqlDbType.Char) { Value = (object)register.IndicadorRango ?? DBNull.Value },
                                                        new SqlParameter("INDICADOR_CREACION", SqlDbType.Bit) { Value = register.IndicadorCreacion },
                                                        new SqlParameter("TIPO_SECCION", SqlDbType.Char) { Value = register.TipoSeccion },
                                                        new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = register.EstadoRegistro },
                                                        new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = register.UsuarioCreacion  },
                                                        new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = register.TerminalCreacion  },
                                                        new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = register.CodigoUnidadNegocio }
                                                       );
        }

        /// <summary>
        /// Permite actualizar las Secciones de los Parametros
        /// </summary>
        /// <param name="register">Sección de Parámetro a actualizar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int ParameterSectionUpdate(ParameterSectionEN register)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_PARAMETRO_SECCION_UPD",
                                                        new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int) { Value = register.CodigoParametro },
                                                        new SqlParameter("CODIGO_SECCION", SqlDbType.Int) { Value = register.CodigoSeccion },
                                                        new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = register.Nombre },
                                                        new SqlParameter("INDICADOR_SOLO_LECTURA", SqlDbType.Bit) { Value = register.IndicadorSoloLectura },
                                                        new SqlParameter("INDICADOR_OBLIGATORIO", SqlDbType.Bit) { Value = register.IndicadorObligatorio },
                                                        new SqlParameter("TIPO_SECCION", SqlDbType.Char) { Value = register.TipoSeccion },
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
