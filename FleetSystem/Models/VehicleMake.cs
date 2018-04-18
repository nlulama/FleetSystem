using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetSystem.Models
{
    public class VehicleMake
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }

        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}