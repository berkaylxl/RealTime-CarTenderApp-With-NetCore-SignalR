using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenderApp.Core.Utilities.Security
{
    public  class JwtToken
    {
        public string Token { get; set; }
        public DateTime Time { get; set; }
    }
}
