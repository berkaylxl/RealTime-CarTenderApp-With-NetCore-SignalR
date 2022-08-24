using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenderApp.Entities.DTOs
{
    public class CorporateRegisterDto
    {
        public string CompanyTitle { get; set; }
        public string CompanyType { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
