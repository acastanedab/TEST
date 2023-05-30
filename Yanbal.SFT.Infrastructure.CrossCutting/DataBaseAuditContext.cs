using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Yanbal.SFT.Infrastructure.CrossCutting.Repositories;

namespace Yanbal.SFT.Infrastructure.CrossCutting
{
    /// <summary>
    /// Clase de infraestructura que maneja el contexto del entity framework y las conexiones a la base de datos Felete Auditoría
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140915 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class DataBaseAuditContext : DbContext, IDbContext
    {
        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public DataBaseAuditContext()
            : base("FleteAuditoriaConnectionString")
        {
            Database.SetInitializer<DataBaseAuditContext>(null);
        }

        /// <summary>
        /// Permite la actualización del repositorio de la entidad
        /// </summary>
        /// <typeparam name="TEntity">Tipi Entidad</typeparam>
        /// <returns>Repositorio de la entidad</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Permite la obtención del repositorio de la entidad
        /// </summary>
        /// <typeparam name="TEntity">Tipo Entidad</typeparam>
        /// <param name="entity">Entidad</param>
        /// <returns>Repositorio de la entidad</returns>
        public DbEntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class
        {
            return this.Entry(entity);
        }
    }
}
