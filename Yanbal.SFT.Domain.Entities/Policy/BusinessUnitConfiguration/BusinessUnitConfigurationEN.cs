using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.BusinessUnitConfiguration
{
    /// <summary>
    /// Entidad de Negocio que representa la Unidad de Negocio Configuración
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class BusinessUnitConfigurationEN : PagingBase, IBusinessUnitConfiguration
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<BusinessUnitConfigurationEN> repositoryProcedure;
        //Fin Sonar
        #region Constructors
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BusinessUnitConfigurationEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public BusinessUnitConfigurationEN(IRepositoryStoredProcedure<BusinessUnitConfigurationEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de Unidad de Negocio Configuración
        /// </summary>
        public int CodigoUnidadNegocioConfiguracion { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int CodigoUnidadNegocio { get; set; }

        /// <summary>
        /// Nombre de Unidad de Negocio
        /// </summary>
        public string NombreUnidadNegocio { get; set; }

        /// <summary>
        /// Código de Cultura
        /// </summary>
        public string CodigoCultura { get; set; }

        /// <summary>
        /// Código de Zona Horaria
        /// </summary>
        public int CodigoZonaHoraria { get; set; }

        /// <summary>
        /// Descripción de Zona Horaria
        /// </summary>
        public string DescripcionZonaHoraria { get; set; }

        /// <summary>
        /// Filas por Pagina
        /// </summary>
        public byte FilasPorPagina { get; set; }

        /// <summary>
        /// Forma de Visualización de Reporte
        /// </summary>
        public string FormaVisualizacionReporte { get; set; }

        /// <summary>
        /// Descripcion de Forma de Visualización de Reporte
        /// </summary>
        public string DescripcionFormaVisualizacionReporte { get; set; }

        /// <summary>
        /// Logo de Compañia
        /// </summary>
        public byte[] LogoCompania { get; set; }

        /// <summary>
        /// Logo de Reporte
        /// </summary>
        public byte[] LogoReporte { get; set; }

        /// <summary>
        /// Maximo Número de Filas por Consulta
        /// </summary>
        public int MaximoFilasPorConsulta { get; set; }
        
        /// <summary>
        /// Mínimo de Caracteres de Glosa
        /// </summary>
        public byte? MinimoCaracteresGlosa { get; set; }

        /// <summary>
        /// Mínimo de Vocales de Glosa
        /// </summary>
        public byte? MinimoVocalesGlosa { get; set; }

        /// <summary>
        /// Indicador de Contraer el Menú
        /// </summary>
        public bool? IndicadorContraerMenu { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Descripcion Estado  de Registro
        /// </summary>
        public string DescripcionEstadoRegistro { get; set; }

        /// <summary>
        /// Observación
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

        /// <summary>
        /// Código de Unidad de Negocio del Contexto
        /// </summary>
        public int CodigoUnidadNegocioContexto { get; set; }
        #endregion

        #region Operations
        /// <summary>
        /// Permite realizar la búsqueda de Unidad de Negocio Configuración
        /// </summary>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <param name="businessUnitCodeConfiguration">Código de Unidad de Negocio Configuración</param>
        /// <param name="businessUnitCodeContext">Código de Unidad de Negocio desde la que se consulta</param>
        /// <param name="cultureCode">Código de Cultura</param>
        /// <param name="registrationStatus">Estado de Registro</param>
        /// <param name="pageNo">Número de Pagina</param>
        /// <param name="pageSize">Tamaño de Página</param>
        /// <returns>Lista de Unidad de Negocio Configuración</returns>
        public List<BusinessUnitConfigurationEN> BusinessUnitConfigurationSearch(int? businessUnitCode, int? businessUnitCodeConfiguration, int? businessUnitCodeContext, string cultureCode, string registrationStatus, int? pageNo, int? pageSize)
        {
            List<BusinessUnitConfigurationEN>  listBusinessUnitConfiguration = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL",
                                                                         new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                                         new SqlParameter("CODIGO_UNIDAD_NEGOCIO_CONFIGURACION", SqlDbType.Int) { Value = (object)businessUnitCodeConfiguration ?? DBNull.Value },
                                                                         new SqlParameter("CODIGO_UNIDAD_NEGOCIO_CONTEXTO", SqlDbType.Int) { Value = (object)businessUnitCodeContext ?? DBNull.Value },
                                                                         new SqlParameter("CODIGO_CULTURA", SqlDbType.Char) { Value = (object)cultureCode ?? DBNull.Value },
                                                                         new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)registrationStatus ?? DBNull.Value },
                                                                         new SqlParameter("PageNo", SqlDbType.Int) { Value = pageNo },
                                                                         new SqlParameter("PageSize", SqlDbType.Int) { Value = pageSize }
                                                                        ).ToList();
            return listBusinessUnitConfiguration;
        }

        /// <summary>
        /// Permite realizar la Búsqueda de Logos de Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitCodeConfiguration">Código de Configuración de Unidad de Negocio</param>
        /// <returns>Lista de Logos de Configuración de Unidad de Negocio</returns>
        public List<BusinessUnitConfigurationEN> GetLogoBusinessUnitConfiguration(int businessUnitCodeConfiguration)
        {
            List<BusinessUnitConfigurationEN> listBusinessUnitConfiguration = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_UNIDAD_NEGOCIO_CONFIGURACION_LOGO_SEL",
                                                                         new SqlParameter("CODIGO_UNIDAD_NEGOCIO_CONFIGURACION", SqlDbType.Int) { Value = (object)businessUnitCodeConfiguration ?? DBNull.Value }
                                                                        ).ToList();
            return listBusinessUnitConfiguration;
        }

        /// <summary>
        /// Permite registrar una Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitConfiguration">Configuración de Unidad de Negocio</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int BusinessUnitConfigurationRegister(BusinessUnitConfigurationEN businessUnitConfiguration)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_UNIDAD_NEGOCIO_CONFIGURACION_INS",
                                 new SqlParameter("CODIGO_UNIDAD_NEGOCIO_CONFIGURACION", SqlDbType.Int) { Value = businessUnitConfiguration.CodigoUnidadNegocioConfiguracion },
                                 new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = businessUnitConfiguration.CodigoUnidadNegocio },
                                 new SqlParameter("CODIGO_CULTURA", SqlDbType.Char) { Value = businessUnitConfiguration.CodigoCultura },
                                 new SqlParameter("CODIGO_ZONA_HORARIA", SqlDbType.Int) { Value = businessUnitConfiguration.CodigoZonaHoraria },
                                 new SqlParameter("FORMA_VISUALIZACION_REPORTE", SqlDbType.Char) { Value = businessUnitConfiguration.FormaVisualizacionReporte },
                                 new SqlParameter("LOGO_COMPANIA", SqlDbType.Image) { Value = (object)businessUnitConfiguration.LogoCompania ?? DBNull.Value },
                                 new SqlParameter("LOGO_REPORTE", SqlDbType.Image) { Value = (object)businessUnitConfiguration.LogoReporte ?? DBNull.Value },
                                 new SqlParameter("FILAS_POR_PAGINA", SqlDbType.TinyInt) { Value = businessUnitConfiguration.FilasPorPagina },
                                 new SqlParameter("MINIMO_CARACTERES_GLOSA", SqlDbType.TinyInt) { Value = (object)businessUnitConfiguration.MinimoCaracteresGlosa ?? DBNull.Value },
                                 new SqlParameter("MINIMO_VOCALES_GLOSA", SqlDbType.TinyInt) { Value = (object)businessUnitConfiguration.MinimoVocalesGlosa ?? DBNull.Value },
                                 new SqlParameter("INDICADOR_CONTRAER_MENU", SqlDbType.Bit) { Value = (object)businessUnitConfiguration.IndicadorContraerMenu ?? DBNull.Value },
                                 new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = businessUnitConfiguration.EstadoRegistro },
                                 new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = businessUnitConfiguration.UsuarioCreacion },
                                 new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = businessUnitConfiguration.TerminalCreacion },
                                 new SqlParameter("CODIGO_UNIDAD_NEGOCIO_CONTEXTO", SqlDbType.Int) { Value = businessUnitConfiguration.CodigoUnidadNegocioContexto }
                                 );
        }

        /// <summary>
        /// Permite modificar una Configuración de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitConfiguration">Configuración de Unidad de Negocio</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int BusinessUnitConfigurationUpdate(BusinessUnitConfigurationEN businessUnitConfiguration)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD",
                                 new SqlParameter("CODIGO_UNIDAD_NEGOCIO_CONFIGURACION", SqlDbType.Int) { Value = businessUnitConfiguration.CodigoUnidadNegocioConfiguracion },
                                 new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = businessUnitConfiguration.CodigoUnidadNegocio },
                                 new SqlParameter("CODIGO_CULTURA", SqlDbType.Char) { Value = businessUnitConfiguration.CodigoCultura },
                                 new SqlParameter("CODIGO_ZONA_HORARIA", SqlDbType.Int) { Value = businessUnitConfiguration.CodigoZonaHoraria },
                                 new SqlParameter("FORMA_VISUALIZACION_REPORTE", SqlDbType.Char) { Value = businessUnitConfiguration.FormaVisualizacionReporte },
                                 new SqlParameter("LOGO_COMPANIA", SqlDbType.Image) { Value = (object)businessUnitConfiguration.LogoCompania ?? DBNull.Value },
                                 new SqlParameter("LOGO_REPORTE", SqlDbType.Image) { Value = (object)businessUnitConfiguration.LogoReporte ?? DBNull.Value },
                                 new SqlParameter("FILAS_POR_PAGINA", SqlDbType.TinyInt) { Value = businessUnitConfiguration.FilasPorPagina },
                                 new SqlParameter("MINIMO_CARACTERES_GLOSA", SqlDbType.TinyInt) { Value = (object)businessUnitConfiguration.MinimoCaracteresGlosa ?? DBNull.Value },
                                 new SqlParameter("MINIMO_VOCALES_GLOSA", SqlDbType.TinyInt) { Value = (object)businessUnitConfiguration.MinimoVocalesGlosa ?? DBNull.Value },
                                 new SqlParameter("INDICADOR_CONTRAER_MENU", SqlDbType.Bit) { Value = (object)businessUnitConfiguration.IndicadorContraerMenu ?? DBNull.Value },
                                 new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = businessUnitConfiguration.Observacion },
                                 new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = businessUnitConfiguration.EstadoRegistro },
                                 new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = businessUnitConfiguration.UsuarioModificacion },
                                 new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = businessUnitConfiguration.TerminalModificacion },
                                 new SqlParameter("CODIGO_UNIDAD_NEGOCIO_CONTEXTO", SqlDbType.Int) { Value = businessUnitConfiguration.CodigoUnidadNegocioContexto }
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
