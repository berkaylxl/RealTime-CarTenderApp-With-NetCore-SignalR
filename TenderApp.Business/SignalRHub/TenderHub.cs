using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;

namespace TenderApp.Business.SignalRHub
{
    public class TenderHub : Hub
    {
        private readonly ITenderService tenderService;

        public TenderHub(ITenderService tenderService)
        {
            this.tenderService = tenderService;
        }

        public async Task UpPrice(int newBid)
        {
            await Clients.All.SendAsync("SendDataJs");
        }
      
    }
    public class Tender
    {
        public int Id { get; set; }
        public int Price { get; set; }
    }
}
