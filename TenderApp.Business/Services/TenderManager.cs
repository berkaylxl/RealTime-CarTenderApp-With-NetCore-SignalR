using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;

namespace TenderApp.Business.Services
{
    public class TenderManager : ITenderService
    {
        public Task Add(Tender tender)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Tender> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tender>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Tender tender)
        {
            throw new NotImplementedException();
        }
    }
}
