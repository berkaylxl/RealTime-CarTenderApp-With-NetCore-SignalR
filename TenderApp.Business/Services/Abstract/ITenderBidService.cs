using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Utilities.Result;
using TenderApp.Entities;

namespace TenderApp.Business.Services.Abstract
{
	public interface ITenderBidService
	{
        Task Add(TenderBid tenderBid);
        Task Delete(Guid id);
        Task Update(TenderBid tenderBid);
        Task<List<TenderBid>> GetAll();
        Task<List<TenderBid>> GetAllByTenderId(Guid tenderId);
    }
}
