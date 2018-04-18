using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetSystem.Models
{
    public class InspectChecklist
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
        public int VehicleId { get; set; }
        public virtual VehicleModel Model { get; set; }
        public int StartKm { get; set; }
        
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}