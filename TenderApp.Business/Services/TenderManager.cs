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
    public class TenderManager : ITenderService
    {
        private readonly ITenderDal _tenderDal;

        public TenderManager(ITenderDal tenderDal)
        {
            _tenderDal = tenderDal;
        }

        public async Task<Result> Add(Tender tender)
        {
            await _tenderDal.Add(tender);
            return new Result(Status.Success,"Tender added");
        }

        public async Task<Result> Delete(Guid id)
        {
            var tender = await _tenderDal.Get(u => u.Id == id);
            if (tender is null)
                return new Result(Status.Error, "Cannot delete tender > (Tender Not Found)");
            await _tenderDal.Delete(tender);
            return new Result(Status.Success, "Tender  Deleted");
        }
        public async Task<DataResult<Tender>> GetById(Guid id)
        {
            var data = await _tenderDal.Get(u => u.Id == id);
            if (data is null)
                return new DataResult<Tender>(Status.Error, data, "Tender Not Found");
            return new DataResult<Tender>(Status.Success, data);
        }

        public async Task<DataResult<List<Tender>>> GetAll()
        {
            var data = await _tenderDal.GetAll();
            return new DataResult<List<Tender>>(Status.Success, data, "Tenders Listed");
        }
        public async Task<Result> Update(Tender tender)
        {
            await _tenderDal.Update(tender);
            return new Result(Status.Success, "Tender  Updated");
        }
    }
}
