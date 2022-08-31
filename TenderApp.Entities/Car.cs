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
    public  class Car: IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public string PlateState { get; set; }
        public string ChassisNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int EngineSize { get; set; }
        public string FuelType { get; set; }
        public string Gear { get; set; }
        public int Mileage { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }
    }
}
