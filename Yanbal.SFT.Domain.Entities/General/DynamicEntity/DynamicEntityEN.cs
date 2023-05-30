using System.Collections.Generic;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.General
{
    /// <summary>
    /// Entidad de Negocio que representa a un Entidad Dinamica
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class DynamicEntityEN : IDynamicEntity
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<DynamicEntityEN> repositoryProcedure;
        //Fin Sonar
        #region Constructors

        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public DynamicEntityEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public DynamicEntityEN(IRepositoryStoredProcedure<DynamicEntityEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Nombre del Dato Obtenido
        /// </summary>
        public string DataName { get; set; }
        /// <summary>
        /// Tipo de Dato Obtenido
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// Valor de Dato Obtenido
        /// </summary>
        public object DataValue { get; set; }
        #endregion

        #region Operations
        /// <summary>
        /// Permite ejecutar un query dinamico y almacenarlo en la Entidad de Dinamica
        /// </summary>
        /// <param name="query">Query a ejecutar</param>
        /// <returns>Lista de Entidades de Negocio</returns>
        public List<List<DynamicEntityEN>> ExecuteDynamicQueryDynamicEntity(string query)
        {
            var result = repositoryProcedure.ExecQueryDynamicEntity(query);
            return result;
        }

        /// <summary>
        /// Permite ejecutar un script de consulta dinamico y almacenarlo en un Dictionary
        /// </summary>
        /// <param name="query">Script de consulta a ejecutar</param>
        /// <returns>Lista de Dictionary</returns>
        public List<Dictionary<string, object>> ExecuteDynamicQueryDictionary(string query)
        {
            var result = repositoryProcedure.ExecQueryEntidadDictionary(query);
            return result;
        }

        /// <summary>
        /// Permite ejecutar un script de inserción o actualización
        /// </summary>
        /// <param name="query">script de inserción o actualización</param>
        /// <returns>Cantidad de registros afectados</returns>
        public int ExecuteDynamicQueryRegister(string query)
        {
            var result = repositoryProcedure.ExecQueryRegistroDinamico(query);
            return result;
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
