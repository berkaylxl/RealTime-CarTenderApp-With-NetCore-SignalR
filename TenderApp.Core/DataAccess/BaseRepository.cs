using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Entities;

namespace TenderApp.Core.DataAccess
{
    public class BaseRepository<TEntity,TContext> : IGenericRepository<TEntity> 
        where TEntity : class,new()
        where TContext : DbContext,new()
    {
        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            using (TContext context = new TContext())
            {
                await context.AddRangeAsync(entities);
                await context.SaveChangesAsync(true);
            }
        }
        public async Task AddAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                await context.AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
               context.Remove(entity);
               await context.SaveChangesAsync();
            }
        }
        public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                if (filter is null)
                {
                    return await context.Set<TEntity>().ToListAsync();
                }
                return await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedentity = context.Entry(entity);
                updatedentity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
           
        }
    }
}
