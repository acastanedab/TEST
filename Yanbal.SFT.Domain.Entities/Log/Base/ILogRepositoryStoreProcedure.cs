using System;
using System.Collections.Generic;

namespace Yanbal.SFT.Domain.Entities.Log.Base
{
    /// <summary>
    /// Interface que representa el Repositorio de Procedure TEntity
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140310 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface ILogRepositoryStoreProcedure<in TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> ExecWithStoreProcedure(string query, params object[] parameters);
        long ExecWithStoreProcedureScalarID(string query, params object[] parameters);
        int ExecWithStoreProcedureSave(string query, params object[] parameters);
    }
}
