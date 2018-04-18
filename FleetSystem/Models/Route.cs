using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetSystem.Models
{
    public class Route
    {
        public int Id { get; set; }
       [Required]
       public string RouteName { get; set; }
    }
}