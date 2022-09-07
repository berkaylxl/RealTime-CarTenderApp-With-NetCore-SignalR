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
    public class CorporateCustomer:User,IEntity
    {
        
        public string CompanyTitle { get; set; }
        public string CompanyType { get; set; }
        public string TaxNo { get; set; }
        public string  TaxOffice { get; set; }

    }
}
