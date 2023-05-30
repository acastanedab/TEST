using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Infrastructure.CrossCutting.Integracion.Repositories;
using Yanbal.SFT.Infrastructure.CrossCutting.Repositories;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Integracion
{
    /// <summary>
    /// Clase de Contexto de Base de Dato
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140922 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class DataBaseContext : DbContext, IDbContext
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public DataBaseContext()
            : base("FletesConnectionString")
        {
            Database.SetInitializer<DataBaseContext>(null);
        }
        /// <summary>
        /// Permite la actualización del repositorio de la entidad
        /// </summary>
        /// <typeparam name="TEntity">Entidad</typeparam>
        /// <returns>Repositorio de la entidad</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    
        /// <summary>
        /// Permite la obtención del repositorio de la entidad
        /// </summary>
        /// <typeparam name="TEntity">Tipo de entidad</typeparam>
        /// <param name="entity">Entidad</param>
        /// <returns>Repositorio de la entidad</returns>
        public DbEntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class
        {
            return this.Entry(entity);
        }
    }
}
