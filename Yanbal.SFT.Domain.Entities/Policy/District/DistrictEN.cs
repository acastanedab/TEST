using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.District
{
    /// <summary>
    /// Entidad de Negocio que representa Ubigeo
    /// </summary>
    /// <remarks>
    /// Creación: GMD  20140803 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class DistrictEN : PagingBase, IDistrict
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<DistrictEN> repositoryProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public DistrictEN() 
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public DistrictEN(IRepositoryStoredProcedure<DistrictEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;        
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de Ciudad
        /// </summary>
        public string CodigoCiudad { get; set; }

        /// <summary>
        /// Código de Distrito
        /// </summary>
        public string CodigoDistrito { get; set; }

        /// <summary>
        /// Descripción de Distrito
        /// </summary>
        public string NombreDistrito { get; set; }
        #endregion

        #region Operations
        
        /// <summary>
        /// Permite Listar los Distritos
        /// </summary>
        /// <param name="cityCode">Código de Ciudad</param>
        /// <param name="districtCode">Código de Distrito</param>
        /// <returns>Lista de Distritos</returns>
        public List<DistrictEN> DistrictSearch(string cityCode, string districtCode)
        {
            List<DistrictEN>  returnList = repositoryProcedure.ExecWithStoreProcedure("MNT.USP_ZONA_DISTRITO_SEL",
                                                            new SqlParameter("CODIGO_CIUDAD", SqlDbType.VarChar) { Value = (object)cityCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_DISTRITO", SqlDbType.VarChar) { Value = (object)districtCode ?? DBNull.Value }
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
