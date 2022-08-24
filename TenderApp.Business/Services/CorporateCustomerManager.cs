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
    public class CorporateCustomerManager : ICorporateCustomerService
    {
        private readonly ICorporateCustomerDal corporateCustomerDal;

        public CorporateCustomerManager(ICorporateCustomerDal corporateCustomerDal)
        {
            this.corporateCustomerDal = corporateCustomerDal;
        }

        public async Task<Result> Add(CorporateCustomer corporateCustomer)
        {
            await corporateCustomerDal.Add(corporateCustomer);
            return new Result(Status.Success);
        }

        public  async Task<Result> DeleteById(Guid id)
        {
            var customer = await corporateCustomerDal.Get(u => u.Id == id);
            await corporateCustomerDal.Delete(customer);
            return new Result(Status.Success);
        }

        public async Task<DataResult<List<CorporateCustomer>>> GetAll()
        {
            var data = await corporateCustomerDal.GetAll();
            return new DataResult<List<CorporateCustomer>>(Status.Success, data);
        }

        public async Task<DataResult<CorporateCustomer>> GetById(Guid id)
        {
            var data = await corporateCustomerDal.Get(c => c.Id == id);
            return new DataResult<CorporateCustomer>(Status.Success,data);
        }

        public async Task<Result> Update(CorporateCustomer corporateCustomer)
        {
            await corporateCustomerDal.Update(corporateCustomer);
            return new Result(Status.Success);
        }
    }
}
