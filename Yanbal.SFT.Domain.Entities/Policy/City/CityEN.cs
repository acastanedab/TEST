using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.City
{
    /// <summary>
    /// Entidad de Negocio que representa Ciudad
    /// </summary>
    /// <remarks>
    /// Creación: GMD  20140803 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class CityEN : PagingBase, ICity
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<CityEN> repositoryProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public CityEN() 
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public CityEN(IRepositoryStoredProcedure<CityEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;        
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de Provincia
        /// </summary>
        public string CodigoProvincia { get; set; }

        /// <summary>
        /// Código de Ciudad
        /// </summary>
        public string CodigoCiudad { get; set; }

        /// <summary>
        /// Descripción de Ciudad
        /// </summary>
        public string NombreCiudad { get; set; }
        #endregion

        #region Operations
        
        /// <summary>
        /// Permite Listar las ciudades
        /// </summary>
        /// <param name="provinceCode">Código de Provincia</param>
        /// <param name="cityCode">Código de Ciudad</param>
        /// <returns>Lista de Ciudad</returns>
        public List<CityEN> CitySearch(string provinceCode, string cityCode)
        {
            List<CityEN> returnList = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_ZONA_CIUDAD_SEL",
                                                            new SqlParameter("CODIGO_PROVINCIA", SqlDbType.VarChar) { Value = (object)provinceCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_CIUDAD", SqlDbType.VarChar) { Value = (object)cityCode ?? DBNull.Value }
                                                            ).ToList();
            return returnList;
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
