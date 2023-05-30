using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.BusinessUnit
{
    /// <summary>
    /// Entidad de Negocio que representa la Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class BusinessUnitEN : PagingBase, IBusinessUnit
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<BusinessUnitEN> repositoryProcedure;
        //Fin Sonar
        #region Constructors
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BusinessUnitEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public BusinessUnitEN(IRepositoryStoredProcedure<BusinessUnitEN> repositoryProcedure)
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
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Código de País
        /// </summary>
        public string CodigoPais { get; set; }

        /// <summary>
        /// Código de País Zona
        /// </summary>
        public string CodigoPaisZona { get; set; }        

        /// <summary>
        /// Nombre de País
        /// </summary>
        public string NombrePais { get; set; }

        /// <summary>
        /// Código de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }

        /// <summary>
        /// Razón Social de Compañía
        /// </summary>
        public string RazonSocialCompania { get; set; }
        
        /// <summary>
        /// Direción de Compañía
        /// </summary>
        public string DireccionCompania { get; set; }

        /// <summary>
        /// Documento de Compañía
        /// </summary>
        public string DocumentoCompania { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Descripción de Estado de Registro
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
        public string   TerminalCreacion { get; set; }

        /// <summary>
        /// Usuario de Modificación
        /// </summary>
        public string   UsuarioModificacion { get; set; }

        /// <summary>
        /// Fecha de Modificación
        /// </summary>
        public DateTime?FechaModificacion { get; set; }

        /// <summary>
        /// Terminal de Modificación
        /// </summary>
        public string   TerminalModificacion { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio del Contexto
        /// </summary>
        public int CodigoUnidadNegocioContexto { get; set; }
        #endregion

        #region Operations
        /// <summary>
        /// Permite realizar la búsqueda de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <param name="businessUnitCodeContext">Código de Unidad de Negocio desde la que se consulta</param>
        /// <param name="name">Nombre de la Unidad de Negocio</param>
        /// <param name="businessUnitName">Nombre de unidad de negocio</param>
        /// <param name="countryCode">Código del Pais</param>
        /// <param name="registrationStatus">Estado de Registro</param>
        /// <param name="pageNo">Número de Pagina</param>
        /// <param name="pageSize">Tamaño de Página</param>
        /// <returns>Lista de Unidad de Negocio</returns>
        public List<BusinessUnitEN> BusinessUnitSearch(int? businessUnitCode, int? businessUnitCodeContext, string name, string businessUnitName, string countryCode, string registrationStatus, int? pageNo, int? pageSize)
        {
            List<BusinessUnitEN> result = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_UNIDAD_NEGOCIO_SEL",
                                                                         new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int)                   { Value = (object)businessUnitCode ?? DBNull.Value },
                                                                         new SqlParameter("CODIGO_UNIDAD_NEGOCIO_CONTEXTO", SqlDbType.Int)          { Value = (object)businessUnitCodeContext ?? DBNull.Value },
                                                                         new SqlParameter("NOMBRE", SqlDbType.NVarChar)                             { Value = (object)name ?? DBNull.Value },
                                                                         new SqlParameter("RAZON_SOCIAL_COMPANIA", SqlDbType.NVarChar)                             { Value = (object)businessUnitName ?? DBNull.Value },
                                                                         new SqlParameter("CODIGO_PAIS", SqlDbType.Char)                            { Value = (object)countryCode ?? DBNull.Value },
                                                                         new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char)                        { Value = (object)registrationStatus ?? DBNull.Value },
                                                                         new SqlParameter("PageNo", SqlDbType.Int)                                  { Value = (object)pageNo ?? DBNull.Value },
                                                                         new SqlParameter("PageSize", SqlDbType.Int)                                { Value = (object)pageSize ?? DBNull.Value }
                                                                        ).ToList();
            return result;
        }

        /// <summary>
        /// Permite registrar una Unidad de Negocio
        /// </summary>
        /// <param name="businessUnit">Unidad de Negocio a registrar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int BusinessUnitRegister(BusinessUnitEN businessUnit)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_UNIDAD_NEGOCIO_INS",
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = businessUnit.CodigoUnidadNegocio },
                                                            new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = businessUnit.Nombre },
                                                            new SqlParameter("CODIGO_PAIS", SqlDbType.Char) { Value = businessUnit.CodigoPais },
                                                            new SqlParameter("RAZON_SOCIAL_COMPANIA", SqlDbType.NVarChar) { Value = businessUnit.RazonSocialCompania },
                                                            new SqlParameter("DIRECCION_COMPANIA", SqlDbType.NVarChar) { Value = businessUnit.DireccionCompania },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = businessUnit.EstadoRegistro },
                                                            new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = businessUnit.UsuarioCreacion },
                                                            new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = businessUnit.TerminalCreacion },
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO_CONTEXTO", SqlDbType.Int) { Value = businessUnit.CodigoUnidadNegocioContexto });
        }

        /// <summary>
        /// Permite modificar una Unidad de Negocio
        /// </summary>
        /// <param name="businessUnit">Unidad de Negocio a modificar</param>
        /// <returns>Cantidad de registro afectados</returns>
        public int BusinessUnitUpdate(BusinessUnitEN businessUnit)
        {
            return repositoryProcedure.ExecWithStoreProcedureSave("MNT.USP_UNIDAD_NEGOCIO_UPD",
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = businessUnit.CodigoUnidadNegocio },
                                                            new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = businessUnit.Nombre },
                                                            new SqlParameter("CODIGO_PAIS", SqlDbType.Char) { Value = businessUnit.CodigoPais },
                                                            new SqlParameter("RAZON_SOCIAL_COMPANIA", SqlDbType.NVarChar) { Value = businessUnit.RazonSocialCompania },
                                                            new SqlParameter("DIRECCION_COMPANIA", SqlDbType.NVarChar) { Value = businessUnit.DireccionCompania },
                                                            new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = businessUnit.Observacion },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = businessUnit.EstadoRegistro },
                                                            new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = businessUnit.UsuarioModificacion },
                                                            new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = businessUnit.TerminalModificacion },
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO_CONTEXTO", SqlDbType.Int) { Value = businessUnit.CodigoUnidadNegocioContexto });
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
