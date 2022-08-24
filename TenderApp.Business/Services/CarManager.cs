using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;
using TenderApp.Core.Utilities.Result;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;
using static TenderApp.Core.Utilities.Result.ResultStatus;

namespace TenderApp.Business.Services
{
    public class CarManager :ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public async  Task<Result> Add(Car car)
        {
            await _carDal.Add(car);
            return new Result(Status.Success, "Car  Added");
        }
        public async Task<Result> Delete(Guid id)
        {
            var car = await _carDal.Get(u => u.Id == id);
            if (car is null)
                return new Result(Status.Error, "Cannot delete car > (Car Not Found)");
            await _carDal.Delete(car);
            return new Result(Status.Success, "Car  Deleted");
        }
        public async Task<DataResult<List<Car>>> GetAll()
        {
            var data = await _carDal.GetAll();
            return new DataResult<List<Car>>(Status.Success, data, "Cars Listed");
        }
        public async Task<DataResult<Car>> GetById(Guid id)
        {
            var data = await _carDal.Get(u => u.Id == id);
            if (data is null)
                return new DataResult<Car>(Status.Error, data, "Car Not Found");
            return new DataResult<Car>(Status.Success, data);
        }
        public async Task<Result> Update(Car car)
        {
            await _carDal.Update(car);
            return new Result(Status.Success, "Car  Updated");
        }
    }
}
