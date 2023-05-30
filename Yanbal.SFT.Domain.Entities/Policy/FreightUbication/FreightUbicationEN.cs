//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.FreightUbication
{
    /// <summary>
    /// Entidad de Negocio que representa la ubicacion
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20170928 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class FreightUbicationEN : PagingBase, IFreightUbication
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<FreightUbicationEN> freightUbicationRepositoryStoreProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FreightUbicationEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="freightUbicationRepositoryStoreProcedure">Repositorio basado en store procedure</param>
        public FreightUbicationEN(IRepositoryStoredProcedure<FreightUbicationEN> countryRepositoryStoreProcedure)
        {
            this.freightUbicationRepositoryStoreProcedure = countryRepositoryStoreProcedure;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de País
        /// </summary>
        public string CodigoPais { get; set; }
        /// <summary>
        /// Código de Provincia
        /// </summary>
        public string CodigoProvincia { get; set; }
        /// <summary>
        /// Código de Ciudad
        /// </summary>
        public string CodigoCiudad { get; set; }
        /// <summary>
        /// Código de Distrito
        /// </summary>
        public string CodigoDistrito { get; set; }
        #endregion

        #region Operations

        /// <summary>
        /// Permite realizar la búsqueda de País
        /// </summary>
        /// <param name="ubicationCode">Código de la Zona del País</param>
        /// <returns>Lista de Países</returns>
        public FreightUbicationEN UbicationSearch(string ubicationCode)
        {
            FreightUbicationEN result;
            result = freightUbicationRepositoryStoreProcedure.ExecWithStoreProcedure("GRL.USP_GET_NIVELES_SEL",
                                                             new SqlParameter("CODIGO_ZONA", SqlDbType.VarChar) { Value = (object)ubicationCode ?? DBNull.Value }
                                                            ).FirstOrDefault();
            return result;
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
