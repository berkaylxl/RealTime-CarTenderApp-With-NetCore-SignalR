using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Utilities.Result;
using TenderApp.Entities;

namespace TenderApp.Business.Services.Abstract
{
    public interface IIndividualCustomerService
    {
        Task<Result> Add(IndividualCustomer invidualCustomer);
        Task<DataResult<List<IndividualCustomer>>> GetAll();
        Task<DataResult<IndividualCustomer>> GetById(Guid id);
        Task<Result> Update(IndividualCustomer invidualCustomer);
        Task<Result> DeleteById(Guid id);
    }
}
