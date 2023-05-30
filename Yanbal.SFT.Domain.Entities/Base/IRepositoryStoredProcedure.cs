using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.General;

namespace Yanbal.SFT.Domain.Entities.Base
{
    /// <summary>
    /// Interface que representa el Repositorio de Procedure TEntity
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140710 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IRepositoryStoredProcedure<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// ExecWithStoreProcedure
        /// </summary>
        IEnumerable<TEntity> ExecWithStoreProcedure(string query, params object[] parameters);
        /// <summary>
        /// ExecWithStoreProcedure
        /// </summary>
        IEnumerable<T> ExecWithStoreProcedure<T>(string query, params object[] parameters);
        /// <summary>
        /// ExecWithStoreProcedureScalar
        /// </summary>
        int ExecWithStoreProcedureScalar(string query, params object[] parameters);
        /// <summary>
        /// ExecWithStoreProcedureScalarType
        /// </summary>
        T ExecWithStoreProcedureScalarType<T>(string query, params object[] parameters);
        /// <summary>
        /// ExecWithStoreProcedureSave
        /// </summary>
        int ExecWithStoreProcedureSave(string query, params object[] parameters);
        /// <summary>
        /// ExecWithStoreProcedureNonQuery
        /// </summary>
        int ExecWithStoreProcedureNonQuery(string procedureName, params object[] parameters);
        /// <summary>
        /// ExecQueryDynamicEntity
        /// </summary>
        List<List<DynamicEntityEN>> ExecQueryDynamicEntity(string query);
        /// <summary>
        /// ExecQueryEntidadDictionary
        /// </summary>
        List<Dictionary<string, object>> ExecQueryEntidadDictionary(string query);
        /// <summary>
        /// ExecQueryRegistroDinamico
        /// </summary>
        int ExecQueryRegistroDinamico(string query);
    }
}
