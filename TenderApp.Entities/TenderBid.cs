using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Entities;

namespace TenderApp.Entities
{
	 public class TenderBid:IEntity
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid TenderId { get; set; }
        public Guid UserId { get; set; }
        public string? UserMail { get; set; }
        public int BidPrice { get; set; }
        public DateTime BidDate { get; set; }
    }
}
