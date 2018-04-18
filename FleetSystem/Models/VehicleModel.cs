using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetSystem.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string RegNo { get; set; }
        public int NoOfPassengers { get; set; }
        public int ArrivalKms { get; set; }
        [Required]
        public DateTime DateArrived { get; set; }
        public int VehicleColorId { get; set; }
        public virtual VehicleColor VehicleColor { get; set;}

    }
}