using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FleetSystem.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ServiceNo { get; set; }
        public int FromId { get; set; }
        public virtual Destination FromAddress {get;set;}
        public int ToId { get; set; }
        public virtual Destination ToAddress { get; set; }
        public int VehicleId { get; set; }
        public virtual VehicleModel Vehicle { get; set; }
        public int StartKm { get; set; }
        public int EndKm { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}