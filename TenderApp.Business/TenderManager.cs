using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Abstract;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;

namespace TenderApp.Business
{
    public class TenderManager : ITenderService
    {
        private readonly ITenderDal _tenderDal;

        public TenderManager(ITenderDal tenderDal)
        {
            _tenderDal = tenderDal;
        }

        public async Task Add(Tender tender)
        {
            await  _tenderDal.AddAsync(tender);
        }

        public async Task Delete(Guid id)
        {
            var tender = await _tenderDal.Get(t => t.Id == id);
            await _tenderDal.DeleteAsync(tender);
        }

        public async Task<Tender> Get(Guid id)
        {
            return await _tenderDal.Get(t => t.Id == id);
        }

        public async Task<List<Tender>> GetAll()
        {
            return await _tenderDal.GetAll();
        }

        public async Task Update(Tender tender)
        {
            await _tenderDal.UpdateAsync(tender);
        }
    }
}
