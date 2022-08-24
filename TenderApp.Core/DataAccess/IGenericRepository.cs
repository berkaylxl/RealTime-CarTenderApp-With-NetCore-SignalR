using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Entities;

namespace TenderApp.Core.DataAccess
{
    public interface IGenericRepository<TEntity> where TEntity :IEntity
    {
        Task Add(TEntity entity);
        Task Add(IEnumerable<TEntity> entities);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<List<TEntity>>GetAll(Expression<Func<TEntity,bool>> filter=null);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
       






    }
}
