using System;
using System.Data.Entity;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Integracion.Repositories
{
    /// <summary>
    /// Interface que representa el Contexto de la Conexión
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IDbContextIntegracion : IDisposable
    {
        /// <summary>
        /// Set
        /// </summary>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        /// <summary>
        /// SaveChanges
        /// </summary>
        int SaveChanges();
    }
}
