using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.UbigeoZoneType
{
    /// <summary>
    /// Entidad de Negocio que representa Tipo de Zona de Ubigeo
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140803 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class UbigeoZoneTypeEN : PagingBase, IUbigeoZoneType
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<UbigeoZoneTypeEN> repositoryProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public UbigeoZoneTypeEN() 
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public UbigeoZoneTypeEN(IRepositoryStoredProcedure<UbigeoZoneTypeEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;        
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de Tipo de Zona de Ubigeo
        /// </summary>
        public int CodigoTipoZonaUbigeo { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int CodigoUnidadNegocio { get; set; }

        /// <summary>
        /// Código de Zona
        /// </summary>
        public string CodigoZona { get; set; }

        /// <summary>
        /// Código de País
        /// </summary>
        public string CodigoPais { get; set; }

        /// <summary>
        /// Descripción de País
        /// </summary>
        public string DescripcionPais { get; set; }

        /// <summary>
        /// Código de Nivel 1
        /// </summary>
        public string CodigoNivel1 { get; set; }

        /// <summary>
        /// Descripción de Nivel 1
        /// </summary>
        public string Nivel1 { get; set; }

        /// <summary>
        /// Código de Nivel 2
        /// </summary>
        public string CodigoNivel2 { get; set; }

        /// <summary>
        /// Descripción de Nivel 2
        /// </summary>
        public string Nivel2 { get; set; }

        /// <summary>
        /// Código de Nivel 3
        /// </summary>
        public string CodigoNivel3 { get; set; }

        /// <summary>
        /// Descripción de Nivel 3
        /// </summary>
        public string Nivel3 { get; set; }

        /// <summary>
        /// Código de Tipo de Zona
        /// </summary>
        public string CodigoTipoZona { get; set; }

        /// <summary>
        /// Descripción de Tipo de Zona
        /// </summary>
        public string DescripcionTipoZona { get; set; }

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
        /// Permite realizar la búsqueda de los Tipos de Zona de Ubigeo
        /// </summary>
        /// <param name="codeTypeZoneUbigeo">Código de Tipo de Zona de Ubigeo</param>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <param name="codeZone">Código de Zona</param>
        /// <param name="codeCountry">Código de País</param>
        /// <param name="codeLevel1">Código de Nivel 1</param>
        /// <param name="level1">Descripción del Nivel 1</param>
        /// <param name="codeLevel2">Código de Nivel 2</param>
        /// <param name="level2">Descripción del Nivel 2</param>
        /// <param name="codeLevel3">Código de Nivel 3</param>
        /// <param name="level3">Descripción del Nivel 3</param>
        /// <param name="codeTypeZone">Código de Tipo de Zona</param>
        /// <param name="status">Estado de Registro</param>
        /// <returns>Lista de Tipos de Zonas de Ubigeos</returns>
        public List<UbigeoZoneTypeEN> UbigeoZoneTypeSearch(int? codeTypeZoneUbigeo, int? businessUnitCode, string codeZone,
                                                           string codeCountry, string codeLevel1, string level1,
                                                           string codeLevel2, string level2, string codeLevel3, string level3,
                                                           string codeTypeZone, string status)
        {
            return UbigeoZoneTypeSearch(codeTypeZoneUbigeo, businessUnitCode, codeZone,
                                                            codeCountry, codeLevel1, level1,
                                                            codeLevel2, level2, codeLevel3, level3,
                                                            codeTypeZone, status, 1, -1);
        }

        /// <summary>
        /// Permite realizar la búsqueda de los Tipos de Zona de Ubigeo
        /// </summary>
        /// <param name="codeTypeZoneUbigeo">Código de Tipo de Zona de Ubigeo</param>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <param name="codeZone">Código de Zona</param>
        /// <param name="codeCountry">Código de País</param>
        /// <param name="codeLevel1">Código de Nivel 1</param>
        /// <param name="level1">Descripción del Nivel 1</param>
        /// <param name="codeLevel2">Código de Nivel 2</param>
        /// <param name="level2">Descripción del Nivel 2</param>
        /// <param name="codeLevel3">Código de Nivel 3</param>
        /// <param name="level3">Descripción del Nivel 3</param>
        /// <param name="codeTypeZone">Código de Tipo de Zona</param>
        /// <param name="status">Estado de Registro</param>
        /// <param name="pageNo">Número de Páginas</param>
        /// <param name="pageSize">Tamaño de Páginas</param>
        /// <returns>Lista de Tipos de Zonas de Ubigeos</returns>
        public List<UbigeoZoneTypeEN> UbigeoZoneTypeSearch(int? codeTypeZoneUbigeo, int? businessUnitCode, string codeZone,
                                                           string codeCountry, string codeLevel1, string level1,
                                                           string codeLevel2, string level2, string codeLevel3, string level3,
                                                           string codeTypeZone, string status, int? pageNo , int? pageSize )
        {
            List<UbigeoZoneTypeEN> returnList = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_TIPO_ZONA_UBIGEO_SEL",
                                            new SqlParameter("CODIGO_TIPO_ZONA_UBIGEO", SqlDbType.Int) { Value = (object)codeTypeZoneUbigeo ?? DBNull.Value },
                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                            new SqlParameter("CODIGO_ZONA", SqlDbType.Char) { Value = (object)codeZone ?? DBNull.Value },
                                            new SqlParameter("CODIGO_PAIS", SqlDbType.Char) { Value = (object)codeCountry ?? DBNull.Value },
                                            new SqlParameter("CODIGO_NIVEL_1", SqlDbType.Char) { Value = (object)codeLevel1 ?? DBNull.Value },
                                            new SqlParameter("NIVEL_1", SqlDbType.NVarChar) { Value = (object)level1 ?? DBNull.Value },
                                            new SqlParameter("CODIGO_NIVEL_2", SqlDbType.Char) { Value = (object)codeLevel2 ?? DBNull.Value },
                                            new SqlParameter("NIVEL_2", SqlDbType.NVarChar) { Value = (object)level2 ?? DBNull.Value },
                                            new SqlParameter("CODIGO_NIVEL_3", SqlDbType.Char) { Value = (object)codeLevel3 ?? DBNull.Value },
                                            new SqlParameter("NIVEL_3", SqlDbType.NVarChar) { Value = (object)level3 ?? DBNull.Value },
                                            new SqlParameter("CODIGO_TIPO_ZONA", SqlDbType.Char) { Value = (object)codeTypeZone ?? DBNull.Value },
                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)status ?? DBNull.Value },
                                            new SqlParameter("PageNo", SqlDbType.Int) { Value = pageNo },
                                            new SqlParameter("PageSize", SqlDbType.Int) { Value = pageSize }
                                            ).ToList();

            return returnList;
        }

        /// <summary>
        /// Permite registrar los Tipos de Zonas de Ubigeos
        /// </summary>
        /// <param name="ubigeoZoneType">Tipo de Zona de Ubigeo a registrar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int UbigeoZoneTypeRegister(UbigeoZoneTypeEN ubigeoZoneType)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_TIPO_ZONA_UBIGEO_INS",
                                                        new SqlParameter("CODIGO_TIPO_ZONA_UBIGEO", SqlDbType.Int) { Value = ubigeoZoneType.CodigoTipoZonaUbigeo },
                                                        new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = ubigeoZoneType.CodigoUnidadNegocio },
                                                        new SqlParameter("CODIGO_ZONA", SqlDbType.Char) { Value = ubigeoZoneType.CodigoZona },
                                                        new SqlParameter("CODIGO_PAIS", SqlDbType.Char) { Value = ubigeoZoneType.CodigoPais },
                                                        new SqlParameter("CODIGO_NIVEL_1", SqlDbType.Char) { Value = (object)ubigeoZoneType.CodigoNivel1 ?? DBNull.Value },
                                                        new SqlParameter("NIVEL_1", SqlDbType.NVarChar) { Value = (object)ubigeoZoneType.Nivel1 ?? DBNull.Value },
                                                        new SqlParameter("CODIGO_NIVEL_2", SqlDbType.Char) { Value = (object)ubigeoZoneType.CodigoNivel2 ?? DBNull.Value },
                                                        new SqlParameter("NIVEL_2", SqlDbType.NVarChar) { Value = (object)ubigeoZoneType.Nivel2 ?? DBNull.Value },
                                                        new SqlParameter("CODIGO_NIVEL_3", SqlDbType.Char) { Value = (object)ubigeoZoneType.CodigoNivel3 ?? DBNull.Value },
                                                        new SqlParameter("NIVEL_3", SqlDbType.NVarChar) { Value = (object)ubigeoZoneType.Nivel3 ?? DBNull.Value },
                                                        new SqlParameter("CODIGO_TIPO_ZONA", SqlDbType.Char) { Value = ubigeoZoneType.CodigoTipoZona },
                                                        new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = ubigeoZoneType.EstadoRegistro },
                                                        new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = ubigeoZoneType.UsuarioCreacion },
                                                        new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = ubigeoZoneType.TerminalCreacion }
                                                        );
        }

        /// <summary>
        /// Permite actualizar los Tipos de Zonas de Ubigeos
        /// </summary>
        /// <param name="ubigeoZoneType">Tipo de Zona de Ubigeo a actualizar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int UbigeoZoneTypeUpdate(UbigeoZoneTypeEN ubigeoZoneType)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_TIPO_ZONA_UBIGEO_UPD",
                                                        new SqlParameter("CODIGO_TIPO_ZONA_UBIGEO", SqlDbType.Int) { Value = ubigeoZoneType.CodigoTipoZonaUbigeo },
                                                        new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = ubigeoZoneType.CodigoUnidadNegocio },
                                                        new SqlParameter("CODIGO_ZONA", SqlDbType.Char) { Value = ubigeoZoneType.CodigoZona },
                                                        new SqlParameter("CODIGO_PAIS", SqlDbType.Char) { Value = ubigeoZoneType.CodigoPais },
                                                        new SqlParameter("CODIGO_NIVEL_1", SqlDbType.Char) { Value = (object)ubigeoZoneType.CodigoNivel1 ?? DBNull.Value },
                                                        new SqlParameter("NIVEL_1", SqlDbType.NVarChar) { Value = (object)ubigeoZoneType.Nivel1 ?? DBNull.Value },
                                                        new SqlParameter("CODIGO_NIVEL_2", SqlDbType.Char) { Value = (object)ubigeoZoneType.CodigoNivel2 ?? DBNull.Value },
                                                        new SqlParameter("NIVEL_2", SqlDbType.NVarChar) { Value = (object)ubigeoZoneType.Nivel2 ?? DBNull.Value },
                                                        new SqlParameter("CODIGO_NIVEL_3", SqlDbType.Char) { Value = (object)ubigeoZoneType.CodigoNivel3 ?? DBNull.Value },
                                                        new SqlParameter("NIVEL_3", SqlDbType.NVarChar) { Value = (object)ubigeoZoneType.Nivel3 ?? DBNull.Value },
                                                        new SqlParameter("CODIGO_TIPO_ZONA", SqlDbType.Char) { Value = ubigeoZoneType.CodigoTipoZona },
                                                        new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = ubigeoZoneType.EstadoRegistro },
                                                        new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = ubigeoZoneType.Observacion },
                                                        new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = ubigeoZoneType.UsuarioModificacion },
                                                        new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = ubigeoZoneType.TerminalModificacion }
                                                        );
        }

        /// <summary>
        /// Destruye y libera el objeto
        /// </summary>
        public void Dispose()
        {
            
        }
        #endregion
    }
}
