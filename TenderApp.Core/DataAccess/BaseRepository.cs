using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Entities;
using TenderApp.Core.DataAccess;

namespace TenderApp.Core.DataAccess
{
    public class BaseRepository<TEntity,TContext> : IGenericRepository<TEntity> 
        where TEntity :class,IEntity
        where TContext:DbContext,new()   
    {
        public async Task Add(TEntity entity)
        {
            using (TContext context =new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }
        public async Task Add(IEnumerable<TEntity> entities)
        {
            using(TContext context =new TContext())
            {
                await context.Set<TEntity>().AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context =new TContext())
            {
                var response = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
                return response;
            }
        }
        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter=null)
        {
            using (TContext context = new TContext())
            {
                if(filter is null)
                    return await context.Set<TEntity>().ToListAsync();
                return  await context.Set<TEntity>().Where(filter).ToListAsync();
               
            }
        }
        public async Task Update( TEntity entity)
        {
            using(TContext context =new TContext())
            {
                 context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();

            }
        }
    }
}
