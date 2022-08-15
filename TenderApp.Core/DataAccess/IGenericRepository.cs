using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Entities;

namespace TenderApp.Core.DataAccess
{
    public interface IGenericRepository<TEntity> where TEntity :class ,new()
    {
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<List<TEntity>> GetAll(Expression<Func<TEntity,bool>> filter=null);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter );
       






    }
}
