using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null,
          Expression<Func<TEntity, object>>[]? includes = null,
          Expression<Func<TEntity, TEntity>>? selector = null,
          bool asNoTracking = false,
          CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllAsync(
           Expression<Func<TEntity, bool>>? filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = default,
            Expression<Func<TEntity, object>>[]? includeProperties = null,
           Expression<Func<TEntity, TEntity>>? predicate = null,
           bool asNoTracking = false,
           CancellationToken cancellationToken = default);
        Task<BasePaginationEntity<TEntity>> PaginationAsync(int page = 0,
         int pageSize = 20,
         Expression<Func<TEntity, bool>>? filter = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = default,
         Expression<Func<TEntity, TEntity>>? predicate = null,
         Expression<Func<TEntity, object>>[]? includeProperties = null,
         bool asNoTracking = false,
         CancellationToken cancellationToken = default);

        void Insert(TEntity entity);
        void InsertMultiple(List<TEntity> entities);
        void Delete(TEntity entityToDelete);
        void DeleteEntities(IEnumerable<TEntity> list);
        void Update(TEntity entityToUpdate, string[]? propertiesToUpdate = null, Action<TEntity>? updateAction = null);
        void UpdateEntities(IEnumerable<TEntity> list);
    }
}
