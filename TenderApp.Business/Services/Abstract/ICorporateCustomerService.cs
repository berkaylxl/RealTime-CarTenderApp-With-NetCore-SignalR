using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Utilities.Result;
using TenderApp.Entities;

namespace TenderApp.Business.Services.Abstract
{
    public interface ICorporateCustomerService
    {
        Task<Result> Add(CorporateCustomer corporateCustomer);
        Task<DataResult<List<CorporateCustomer>>> GetAll();
        Task<DataResult<CorporateCustomer>> GetById(Guid id);
        Task<Result> Update(CorporateCustomer corporateCustomer);
        Task<Result> DeleteById(Guid id);
    }
}
