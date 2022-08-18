using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;
using TenderApp.Core.Utilities.Result;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;

namespace TenderApp.Business.Services
{
    public class CarManager :ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public Task<Result> Add(Car car)
        {
            throw new NotImplementedException();
        }
        public Task<Result> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<DataResult<List<Car>>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<DataResult<Car>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<Result> Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
