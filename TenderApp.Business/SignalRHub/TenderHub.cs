using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenderApp.Business.SignalRHub
{
    public class TenderHub : Hub
    {
        public async Task SendMessage(string price)
        {
            await Clients.All.SendAsync("NewPrice", price);
        }
      

        
    }
}
