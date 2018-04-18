using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetSystem.Models
{
    public class AddressType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}