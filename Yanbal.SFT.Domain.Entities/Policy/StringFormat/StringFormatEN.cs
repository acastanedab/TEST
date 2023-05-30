using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.StringFormat
{
    /// <summary>
    /// Entidad de Negocio que representa la Formato Cadena
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class StringFormatEN : PagingBase, IStringFormat
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<StringFormatEN> repositoryStoreProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public StringFormatEN()
        {
        }
        
        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryStoreProcedure">Procedimiento almacenado</param>
        public StringFormatEN(IRepositoryStoredProcedure<StringFormatEN> repositoryStoreProcedure)
        {
            this.repositoryStoreProcedure = repositoryStoreProcedure;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Código de Formato Cadena
        /// </summary>
        public int CodigoFormatoCadena { get; set; }

        /// <summary>
        /// Formato
        /// </summary>
        public string Formato { get; set; }

        /// <summary>
        /// Tipo de Formato
        /// </summary>
        public string TipoFormato { get; set; }

        /// <summary>
        /// Formato Largo
        /// </summary>
        public bool FormatoLargo { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }        

        #endregion

        #region Operations

        /// <summary>
        /// Permite buscar el Formato de cadena
        /// </summary>
        /// <param name="stringFormatCode">Código de Formato Cadena</param>
        /// <param name="format">Formato</param>
        /// <param name="formatType">Tipo de Formato</param>
        /// <param name="longFormat">Formato Largo</param>
        /// <param name="registrationstatus">Estado de Registro</param>
        /// <returns>Lista de Búsqueda</returns>
        public List<StringFormatEN> StringFormatSearch(int? stringFormatCode, string format, string formatType, bool? longFormat, string registrationstatus)
        {
            return repositoryStoreProcedure.ExecWithStoreProcedure("MNT.USP_FORMATO_CADENA_SEL",
                   new SqlParameter("CODIGO_FORMATO_CADENA", SqlDbType.Int) { Value = (object)stringFormatCode ?? DBNull.Value },
                   new SqlParameter("FORMATO", SqlDbType.NVarChar) { Value = (object)format ?? DBNull.Value },
                   new SqlParameter("TIPO_FORMATO", SqlDbType.Char) { Value = (object)formatType ?? DBNull.Value },
                   new SqlParameter("FORMATO_LARGO", SqlDbType.Bit) { Value = (object)longFormat ?? DBNull.Value },
                   new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)registrationstatus ?? DBNull.Value }
                   ).ToList();
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
