using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Repositories
{
    /// <summary>
    /// Interfaz que implementa los repositorios de las entidades
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140615 <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// Set
        /// </summary>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        /// <summary>
        /// GetEntry
        /// </summary>
        DbEntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// SaveChanges
        /// </summary>
        int SaveChanges();
    }
}
