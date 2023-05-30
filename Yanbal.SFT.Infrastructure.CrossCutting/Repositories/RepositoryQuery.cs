using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Repositories
{
    /// <summary>
    /// Clase repositorio generico basado en entity framework
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140201 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class RepositoryQuery<TEntity> : IRepositoryQuery<TEntity> where TEntity : Entity
    {
        #region Properties
        private readonly IDbContext dBContext;

        private IDbSet<TEntity> Entities
        {
            get { return this.dBContext.Set<TEntity>(); }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor que permite inicializar el context
        /// </summary>
        /// <param name="context">Contexto de la Conexión</param>
        public RepositoryQuery(IDbContext context)
        {
            this.dBContext = context;

        }

        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public RepositoryQuery()
        {
            try
            {
                this.dBContext = new DataBaseContext();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Operations
        /// <summary>
        /// Permite adicionar una entidad al repositorio
        /// </summary>
        /// <param name="item">entidad</param>
        public void Add(TEntity item)
        {
            try
            {
                Entities.Add(item);

                dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Permite adicionar una lista de entidades al repositorio
        /// </summary>
        /// <param name="list">lista de entidades</param>
        public void AddRange(List<TEntity> list)
        {
            try
            {
                foreach (var item in list)
                {
                    Entities.Add(item);
                }

                dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Permite actualizar una entidad del repositorio
        /// </summary>
        /// <param name="item">entidad</param>
        public void Modify(TEntity item)
        {
            try
            {
                Entities.Attach(item);
                dBContext.GetEntry(item).State = System.Data.Entity.EntityState.Modified;
                dBContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Permite remover una entidad del repositorio
        /// </summary>
        /// <param name="item">entidad</param>
        public void Remove(TEntity item)
        {
            try
            {
                Entities.Remove(item);
                dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Permite persistir los cambios del repositorio en la contexto y base de datos
        /// </summary>
        public void SaveChange()
        {
            try
            {
                dBContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Permite realizar la combinacion de entidades
        /// </summary>
        /// <param name="persisted">entidad a persistir</param>
        /// <param name="current">entidad a proveer</param>
        public void Merge(TEntity persisted, TEntity current)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permite obtener una entidad
        /// </summary>
        /// <param name="keyValues">valores de busqueda</param>
        public TEntity Get(object keyValues)
        {
            return Entities.Find(keyValues);
        }

        /// <summary>
        /// Permite obtener el listado total de entidades
        /// </summary>
        /// <param name="includes">entidades a incluir</param>
        public List<TEntity> GetAll(List<string> includes)
        {
            return Entities.ToList();
        }

        /// <summary>
        /// Permite obtener el listado de entidades
        /// </summary>
        ///<returns>Lista de entidades</returns>
        public virtual IEnumerable<TEntity> Get()
        {
            return IEnumerable<Tentity>(null, null, null, false, Enumerados.EstadoRegistro.Activo);
        }

        /// <summary>
        /// Permite obtener el listado de entidades
        /// </summary>
        ///<param name="filter">filtros que definen el universo de entidades</param>
        ///<param name="orderBy">campo a aplicar el ordenamiento</param>
        ///<param name="includeProperties">entidades a incluir</param>
        ///<param name="asNoTracking">Indicador para aplicar AsNoTracking</param>
        ///<param name="estadoRegistro">Estado del registro</param>
        ///<returns>Lista de entidades</returns>
        public virtual IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy , IEnumerable<string> includeProperties , bool asNoTracking , string estadoRegistro )
        {
            IQueryable<TEntity> query = Entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (estadoRegistro != null)
            {
                query = query.Where(e => e.EstadoRegistro == estadoRegistro);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Permite obtener Queryble del repositorio
        /// </summary>
        ///<param name="filter">filtros que definen el universo de entidades</param>
        ///<param name="orderBy">campo a aplicar el ordenamiento</param>
        ///<param name="includeProperties">entidades a incluir</param>
        ///<param name="asNoTracking">Indicador para aplicar AsNoTracking</param>
        ///<param name="estadoRegistro">Estado del registro</param>
        ///<returns>Queryble del repositorio</returns>
        public virtual IQueryable<TEntity> GetQueryable()
        {
            return IQueryable<TEntity> GetQueryable ( null, null, null, false, Enumerados.EstadoRegistro.Activo);
        }

        /// <summary>
        /// Permite obtener Queryble del repositorio
        /// </summary>
        ///<param name="filter">filtros que definen el universo de entidades</param>
        ///<param name="orderBy">campo a aplicar el ordenamiento</param>
        ///<param name="includeProperties">entidades a incluir</param>
        ///<param name="asNoTracking">Indicador para aplicar AsNoTracking</param>
        ///<param name="estadoRegistro">Estado del registro</param>
        ///<returns>Queryble del repositorio</returns>
        public virtual IQueryable<TEntity> GetQueryable(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy , IEnumerable<string> includeProperties , bool asNoTracking, string estadoRegistro)
        {
            IQueryable<TEntity> query = Entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (estadoRegistro != null)
            {
                query = query.Where(e => e.EstadoRegistro == estadoRegistro);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        /// <summary>
        /// Destruye y libera el objeto
        /// </summary>
        public void Dispose()
        {
            if (dBContext != null)
            {
                dBContext.Dispose();
            }
        }
        #endregion
    }
}
