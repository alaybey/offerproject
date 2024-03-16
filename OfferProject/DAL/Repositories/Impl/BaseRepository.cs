using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.Common;
using DAL.Exceptions;
using DAL.Persistence;
using DAL.Commons;
namespace DAL.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
where TEntity : class
{
    protected readonly DatabaseContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(DatabaseContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

     public async Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntity = (await DbSet.AddAsync(entity)).Entity;
        await Context.SaveChangesAsync();

        return addedEntity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var removedEntity = DbSet.Remove(entity).Entity;
        await Context.SaveChangesAsync();

        return removedEntity;
    }

    public async Task<PaginationResult<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Pagination pagination)
    {
        var query = DbSet.Where(predicate);
        var result = query.Skip((pagination.Page - 1) * pagination.Size).Take(pagination.Size);
        var total = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)total / pagination.Size);

        return new PaginationResult<TEntity>{
            Data = result,
            Total = total,
            Pages = totalPages
        };
    }

    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await DbSet.Where(predicate).FirstOrDefaultAsync() ?? throw new NotFoundException("There is no record.");
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }
}


public class PaginationResult<TEntity>
{
    public required IQueryable<TEntity> Data { get; set; }
    public int Total { get; set; }

    public int Pages { get; set; }
}