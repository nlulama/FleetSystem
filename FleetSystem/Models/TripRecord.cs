using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FleetSystem.Models
{
    public class TripRecord
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
        public int Odometer { get; set; }
        public string StoppingPoint { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime Depart { get; set; }
        public int PassengersIn { get; set; }
        public int PassengersOut { get; set; }
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public string Remarks { get; set; }
    }
}