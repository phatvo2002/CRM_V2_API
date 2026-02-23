using CRM.Application.Common.Interface;
using CRM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repository
{
    public class BaseRepository<TContext , TEntity> : IBaseRepository<TEntity>  where TContext : CrmDbContext where TEntity : class
    {
        protected readonly TContext _context;
        public BaseRepository(TContext context)
        {
            _context = context;
        }

        #region Query
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Expression<Func<TEntity, object>>[]? includeProperties = null, bool asNoTracking = false, Expression<Func<TEntity, TEntity>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Expression<Func<TEntity, object>>[]? includeProperties = null, Expression<Func<TEntity, TEntity>>? predicate = null, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if(includeProperties!= null)
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (predicate != null)
            {
                query = query.Select(predicate);
            }
            if(orderBy != null)
            {
                return  asNoTracking ? await orderBy(query).AsNoTracking().ToListAsync(cancellationToken) : await orderBy(query).ToListAsync(cancellationToken);
            }
            else
            {
                return   asNoTracking ? await  query.AsNoTracking().ToListAsync(cancellationToken) : await query.ToListAsync(cancellationToken);   
            }
        }

        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>[]? includes = null, Expression<Func<TEntity, TEntity>>? selector = null, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if(filter != null)
            {
                query.Where(filter);    
            }    
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query.Include(include);
                }   
            }    
            if(selector != null)
            {
                query.Select(selector);
            }
            return asNoTracking ? query.AsNoTracking().FirstOrDefaultAsync(cancellationToken) : query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<BasePaginationEntity<TEntity>> PaginationAsync(int page = 0, int pageSize = 20, Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Expression<Func<TEntity, TEntity>>? predicate = null, Expression<Func<TEntity, object>>[]? includeProperties = null, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (predicate != null)     
            {
               query.Select(predicate); 
            }
            var total = await query.CountAsync(cancellationToken);
            query = query.Skip((page - 1) * pageSize)
            .Take(pageSize);

            var totalpage = (int)Math.Ceiling(total / (double)pageSize);
            List<TEntity>? data;
            if (orderBy != null)
            {
                data = asNoTracking
               ? await orderBy(query).AsNoTracking().ToListAsync(cancellationToken)
               : await orderBy(query).ToListAsync(cancellationToken);
            }
            else
            {
                data = asNoTracking
               ? await query.AsNoTracking().ToListAsync(cancellationToken)
               : await query.ToListAsync(cancellationToken);
            }    
                
            return new BasePaginationEntity<TEntity>
            {
                Total = total,
                TotalPages = totalpage,
                Data = data
            };  
        }
        #endregion

        #region Command
        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void InsertMultiple(List<TEntity> entities)
        {
           _context.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entityToUpdate, string[]? propertiesToUpdate = null, Action<TEntity>? updateAction = null)
        {
            if (propertiesToUpdate?.Length > 0)
            {
                foreach (var item in propertiesToUpdate)
                {
                    var propertyName = item;
                    _context.Entry(entityToUpdate).Property(propertyName).IsModified = true;
                }
            }
            else if (updateAction != null)
            {
                _context.Set<TEntity>().Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
                updateAction(entityToUpdate);
            }
            else
            {
                _context.Set<TEntity>().Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
            }
        }

        public void UpdateEntities(IEnumerable<TEntity> list)
        {
            _context.Set<TEntity>().UpdateRange(list);  
        }
        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(entityToDelete);
            }
            _context.Set<TEntity>().Remove(entityToDelete);
        }
        public void DeleteEntities(IEnumerable<TEntity> list)
        {
            _context.Set<TEntity>().RemoveRange(list);
        }
        #endregion


    }
}
