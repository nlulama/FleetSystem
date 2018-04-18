using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetSystem.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        [Required]
        public int AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }
       
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        [Required]
        public string Code { get; set; }

        public virtual ICollection<AddressType> AddressTypes { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}