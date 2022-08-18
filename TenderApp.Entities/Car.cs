using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Entities;

namespace TenderApp.Entities
{
    public  class Car: BaseEntity
    {
        public string Plate { get; set; }
        public string PlateState { get; set; }
        public string ChassisNumber { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public int EngineSize { get; set; }
        public string FuelType { get; set; }
        public int DepositValue { get; set; }
        public int FairValue { get; set; }
        public int StartPrice { get; set; }
        public string Gear { get; set; }
        public int Mileage { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
