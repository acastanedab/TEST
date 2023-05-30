using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.Language
{
    /// <summary>
    /// Entidad de Negocio que representa el Idioma
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class LanguageEN : PagingBase, ILanguage
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<LanguageEN> repositoryStoreProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public LanguageEN()
        {
        }
        
        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryStoreProcedure">Procedimiento almacenado</param>
        public LanguageEN(IRepositoryStoredProcedure<LanguageEN> repositoryStoreProcedure)
        {
            this.repositoryStoreProcedure = repositoryStoreProcedure;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Código de Idioma
        /// </summary>
        public string CodigoIdioma { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }        

        #endregion

        #region Operations

        /// <summary>
        /// Permite realizar la búsqueda de Idioma
        /// </summary>
        /// <param name="languageCode">Código de Idioma</param>
        /// <param name="name">Nombre</param>
        /// <param name="registrationStatus">Estado de Registro</param>
        /// <returns>Lista de Búsqueda</returns>
        public List<LanguageEN> LanguageSearch(string languageCode, string name, string registrationStatus)
        {
            return repositoryStoreProcedure.ExecWithStoreProcedure("MNT.USP_IDIOMA_SEL",
                   new SqlParameter("CODIGO_IDIOMA", SqlDbType.Char) { Value = (object)languageCode ?? DBNull.Value },
                   new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = (object)name ?? DBNull.Value },
                   new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)registrationStatus ?? DBNull.Value }
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
