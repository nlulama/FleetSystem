using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetSystem.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string IDNumber { get; set; }
       
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

    }
}

    
