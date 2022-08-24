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
    
    public class Document: IEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid CreateByUserId { get; set; }
        public  string Url { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public DocumentType DocumentType { get; set; }

    }
    public enum DocumentType
    {
        DocumentPdf=1,
        DocumentImage=2
    }
}
