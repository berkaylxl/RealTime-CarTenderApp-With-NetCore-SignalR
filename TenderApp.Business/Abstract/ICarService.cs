using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Entities;

namespace TenderApp.Business.Abstract
{
    public interface ICarService
    {
        Task AddAsync(Car car);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Car car);
        Task<List<Car>> GetAll();
        Task<Car> Get(Guid id);


    }
}
