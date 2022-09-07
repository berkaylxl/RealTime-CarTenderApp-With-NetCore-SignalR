using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Entities;

namespace TenderApp.Entities
{
    public class IndividualCustomer:User,IEntity
    {
        
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthPlace { get; set; }
      
    }
}
