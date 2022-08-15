using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Entities;

namespace TenderApp.Entities
{
    
    public class Document:BaseEntity
    {

        public Guid CarId { get; set; }
        public  string Url { get; set; }
    }
}
