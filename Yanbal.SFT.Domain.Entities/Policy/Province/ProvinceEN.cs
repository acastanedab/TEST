using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.Province
{
    /// <summary>
    /// Entidad de Negocio que representa Provincia
    /// </summary>
    /// <remarks>
    /// Creación: GMD  20140803 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ProvinceEN : PagingBase, IProvince
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<ProvinceEN> repositoryProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public ProvinceEN() 
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public ProvinceEN(IRepositoryStoredProcedure<ProvinceEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;        
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
        /// Descripción de Provincia
        /// </summary>
        public string NombreProvincia { get; set; }
        #endregion

        #region Operations
        
        /// <summary>
        /// Permite Listar las provincias
        /// </summary>
        /// <param name="codePais">Código de Pais</param>
        /// <param name="codeProvince">Código de Provincia</param>
        /// <returns>Lista de Provincias</returns>
        public List<ProvinceEN> ProvinceSearch(string codePais, string codeProvince)
        {
            List<ProvinceEN> returnList = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_ZONA_PROVINCIA_SEL",
                                                            new SqlParameter("CODIGO_PAIS", SqlDbType.VarChar) { Value = (object)codePais ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_PROVINCIA", SqlDbType.VarChar) { Value = (object)codeProvince ?? DBNull.Value }
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
