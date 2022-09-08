using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;
using TenderApp.Core.Utilities.Result;
using TenderApp.DataAccess;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;
using static TenderApp.Core.Utilities.Result.ResultStatus;

namespace TenderApp.Business.Services
{
	public class TenderBidManager : ITenderBidService
	{
		private readonly ITenderBidDal tenderBidDal;
		private readonly IAuthService authService;

		public TenderBidManager(ITenderBidDal tenderBidDal, IAuthService authService)
		{
			this.tenderBidDal = tenderBidDal;
			this.authService = authService;
		}

		public async Task Add(TenderBid tenderBid)
		{
			var email = await authService.GetMailById(tenderBid.UserId);
			tenderBid.UserMail = email;
            await tenderBidDal.Add(tenderBid);
        }
		public async Task Delete(Guid id)
		{
			var tenderBid = await tenderBidDal.Get(u => u.Id == id);
			await tenderBidDal.Delete(tenderBid);
		}
		public async Task<List<TenderBid>> GetAll()
		{
			return await tenderBidDal.GetAll();
		}
		public async Task<List<TenderBid>> GetAllByTenderId(Guid tenderId)
		{
			return await tenderBidDal.GetAll(u => u.TenderId == tenderId);
		}

		public async Task Update(TenderBid tenderBid)
		{
            await tenderBidDal.Update(tenderBid);
        }
	}
}
