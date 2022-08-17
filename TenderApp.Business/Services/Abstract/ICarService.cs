using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Entities;

namespace TenderApp.Business.Services.Abstract
{
    public interface ICarService
    {
        Task Add(Car car);
        Task Delete(Guid id);
        Task Update(Car car);
        Task<List<Car>> GetAll();
        Task<Car> Get(Guid id);


    }
}
