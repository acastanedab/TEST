using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.Country
{
    /// <summary>
    /// Entidad de Negocio que representa el País
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class CountryEN : PagingBase, ICountry
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<CountryEN> countryRepositoryStoreProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CountryEN()
        {
        }
        
        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="countryRepositoryStoreProcedure">Repositorio basado en store procedure</param>
        public CountryEN(IRepositoryStoredProcedure<CountryEN> countryRepositoryStoreProcedure)
        {
            this.countryRepositoryStoreProcedure = countryRepositoryStoreProcedure;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Código de País
        /// </summary>
        public string CodigoPais { get; set; }

        /// <summary>
        /// Código de la Zona del País
        /// </summary>
        public string CodigoPaisZona { get; set; }

        /// <summary>
        /// Nombre del País
        /// </summary>
        public string Nombre { get; set; }        

        #endregion

        #region Operations

        /// <summary>
        /// Permite realizar la búsqueda de País
        /// </summary>
        /// <param name="countryCode">Código de País</param>
        /// <param name="countryZoneCode">Código de la Zona del País</param>
        /// <returns>Lista de Países</returns>
        public List<CountryEN> CountrySearch(string countryCode, string countryZoneCode)
        {
            return countryRepositoryStoreProcedure.ExecWithStoreProcedure("MNT.USP_PAIS_SEL",
                                                             new SqlParameter("CODIGO_PAIS", SqlDbType.Char) { Value = (object)countryCode ?? DBNull.Value },
                                                             new SqlParameter("CODIGO_PAIS_ZONA", SqlDbType.Char) { Value = (object)countryZoneCode ?? DBNull.Value }
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
