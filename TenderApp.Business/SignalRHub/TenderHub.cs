using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;
using TenderApp.Entities;

namespace TenderApp.Business.SignalRHub
{
    public class TenderHub : Hub
    {
        private readonly ITenderService tenderService;
        private readonly ITenderBidService tenderBidService;

        public TenderHub(ITenderService tenderService, ITenderBidService tenderBidService)
        {
            this.tenderService = tenderService;
            this.tenderBidService = tenderBidService;
        }

        public async Task UpPrice(string userId, string newBid, string tenderId)
        {

            Guid _tenderId = Guid.Parse(tenderId);
            Guid _userId = Guid.Parse(userId);

            await tenderBidService.Add(new TenderBid
            {
                TenderId = _tenderId,
                UserId = _userId,
                BidPrice = Convert.ToInt32(newBid),
                BidDate = DateTime.Now
            });
            var tenderData = await tenderService.GetById(_tenderId);
            var tender = tenderData.Data;
            tender.LastBidOwner = _userId;
            tender.LastBidPrice = tender.LastBidPrice + Convert.ToInt32(newBid);
            await tenderService.Update(tender);

            var updateTender = await tenderService.GetById(_tenderId);
            var bidsList = await tenderBidService.GetAllByTenderId(_tenderId);
            await Clients.All.SendAsync("SendDataJs", updateTender.Data.LastBidOwner, updateTender.Data.LastBidPrice, bidsList.OrderByDescending(b => b.BidDate));

        }
        public async Task SendBidsList(string tenderId)
        {
            Guid _tenderId = Guid.Parse(tenderId);

            var bidsList = await tenderBidService.GetAllByTenderId(_tenderId);
            await Clients.All.SendAsync("GetBidsList", bidsList.OrderByDescending(b => b.BidDate));
        }


        static Guid StringToGUID(string value)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            return new Guid(data);
        }







    }


}
