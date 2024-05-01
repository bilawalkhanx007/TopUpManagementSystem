using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstructions
{
    /// <summary>
    /// This is generic Interface for repositoy
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : IEntityBase
    {
        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(List<TEntity> entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        void UpdateRange(List<TEntity> entity);

        Task<TEntity> GetByIdAsync(object id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllAsync<TProperty>
        (Expression<Func<TEntity, TProperty>> include, CancellationToken cancellationToken = default);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
