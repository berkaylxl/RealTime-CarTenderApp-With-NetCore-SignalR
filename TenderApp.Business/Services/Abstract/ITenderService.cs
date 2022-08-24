using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Utilities.Result;
using TenderApp.Entities;

namespace TenderApp.Business.Services.Abstract
{
    public interface ITenderService
    {
        Task<Result>  Add(Tender tender);
        Task<Result> Delete(Guid id);
        Task<Result> Update(Tender tender);
        Task<DataResult<List<Tender>>> GetAll();
        Task<DataResult<Tender>> GetById(Guid id);
    }
}
