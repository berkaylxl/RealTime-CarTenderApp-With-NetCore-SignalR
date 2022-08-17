using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Entities;

namespace TenderApp.Business.Services.Abstract
{
    public interface ITenderService
    {
        Task  Add(Tender tender);
        Task Delete(Guid id);
        Task Update(Tender tender);
        Task<List<Tender>> GetAll();
        Task<Tender> Get(Guid id);
    }
}
