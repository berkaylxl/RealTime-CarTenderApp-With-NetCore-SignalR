using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;

namespace TenderApp.Business.SignalRHub
{
    public class TenderListHub : Hub
    {
        private readonly ITenderService tenderService;

        public TenderListHub(ITenderService tenderService)
        {
            this.tenderService = tenderService;
        }

        public async Task SendData()
        {
            var tenderList = tenderService.GetAll();
            await Clients.All.SendAsync("SendDataJs",tenderList);
        }
      
    }
    public class Tender
    {
        public int Id { get; set; }
        public int Price { get; set; }
    }
}
