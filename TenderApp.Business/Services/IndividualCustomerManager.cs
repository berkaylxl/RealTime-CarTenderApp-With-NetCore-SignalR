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
    public class IndividualCustomerManager : IIndividualCustomerService
    {
        private readonly IIndividualCustomerDal individualCustomerDal;
        public async Task<Result> Add(IndividualCustomer IndividualCustomer)
        {
            await individualCustomerDal.Add(IndividualCustomer);
            return new Result(Status.Success);
        }

        public async Task<Result> DeleteById(Guid id)
        {
            var customer = await individualCustomerDal.Get(u => u.Id == id);
            await individualCustomerDal.Delete(customer);
            return new Result(Status.Success);
        }

        public async Task<DataResult<List<IndividualCustomer>>> GetAll()
        {
            var data = await individualCustomerDal.GetAll();
            return new DataResult<List<IndividualCustomer>>(Status.Success, data);
        }

        public async Task<DataResult<IndividualCustomer>> GetById(Guid id)
        {
            var data = await individualCustomerDal.Get(c => c.Id == id);
            return new DataResult<IndividualCustomer>(Status.Success, data);
        }

        public async Task<Result> Update(IndividualCustomer individualCustomer)
        {
            await individualCustomerDal.Update(individualCustomer);
            return new Result(Status.Success);
        }
    }
}
