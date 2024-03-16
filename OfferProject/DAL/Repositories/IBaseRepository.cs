using System.Linq.Expressions;
using Core.Common;
using DAL.Commons;
namespace DAL.Repositories;

public interface IBaseRepository<TEntity> : IRepository
{
    Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

    Task<PaginationResult<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Pagination pagination);

    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<TEntity> DeleteAsync(TEntity entity);
}

public interface IRepository {}