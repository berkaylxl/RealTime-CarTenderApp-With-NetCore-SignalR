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
        private readonly IDocumentService _documentService;

        public CarManager(ICarDal carDal, IDocumentService documentService)
        {
            _carDal = carDal;
            _documentService = documentService;
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
            foreach (var item in data)
            {
                var document = await _documentService.GetListByCarId(item.Id);
                item.Document = document.Data;
            }
            return new DataResult<List<Car>>(Status.Success, data, "Cars Listed");

        }
        public async Task<DataResult<Car>> GetById(Guid id)
        {
            var data = await _carDal.Get(u => u.Id == id);
            var document = await _documentService.GetListByCarId(data.Id);
            data.Document = document.Data;
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
