using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Abstract;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;

namespace TenderApp.Business
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async Task AddAsync(Car car)
        {
          await  _carDal.AddAsync(car);
        }

        public async Task DeleteAsync(Guid id)
        {
           var car = await _carDal.Get(c => c.Id == id);
           await _carDal.DeleteAsync(car);
        }

        public async  Task<Car> Get(Guid id)
        {
            return await _carDal.Get(c =>c.Id==id);
        }

        public async Task<List<Car>> GetAll()
        {
            return await _carDal.GetAll();
        }

        public async Task UpdateAsync(Car car)
        {
             await _carDal.UpdateAsync(car);
        }
    }
}
