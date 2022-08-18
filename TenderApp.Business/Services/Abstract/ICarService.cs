using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Utilities.Result;
using TenderApp.Entities;

namespace TenderApp.Business.Services.Abstract
{
    public interface ICarService
    {
        Task<Result> Add(Car car);
        Task<Result>Delete(Guid id);
        Task<Result> Update(Car car);
        Task<DataResult<List<Car>>> GetAll();
        Task<DataResult<Car>> GetById(Guid id);
    }
}
