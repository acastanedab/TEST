using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Freight.Base
{
    /// <summary>
    /// Interfacce de Negocio que representa la Consulta al repositorio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140723 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IRepositoryQuery<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity item);
        void Modify(TEntity item);
        void Remove(TEntity item);
        void Merge(TEntity persisted, TEntity current);
        TEntity Get(object keyValues);
        void SaveChange();
        List<TEntity> GetAll(List<string> includes);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter ,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy ,
            IEnumerable<string> includeProperties, bool asNoTracking , string estadoRegistro);
    }
}
