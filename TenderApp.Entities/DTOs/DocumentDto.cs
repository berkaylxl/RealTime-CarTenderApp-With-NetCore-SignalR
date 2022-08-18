using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenderApp.Entities.DTOs
{
    public class DocumentDto
    {
        public Guid CarId { get; set; }
        public Guid CreateByUserId { get; set; }
    }
}
