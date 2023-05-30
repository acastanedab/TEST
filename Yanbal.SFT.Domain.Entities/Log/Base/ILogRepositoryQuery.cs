using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Yanbal.SFT.Domain.Entities.Log.Base
{
    /// <summary>
    /// Entidad de Negocio que representa la clase ILogRepositoryQuery
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140326 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface ILogRepositoryQuery<TEntity> : IDisposable where TEntity : LogEntity
    {
        void Add(TEntity item);
        TEntity Get(object keyValues);

        void SaveChange();
        List<TEntity> GetAll(List<string> includes);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy ,
            IEnumerable<string> includeProperties , bool asNoTracking );
    }
}
