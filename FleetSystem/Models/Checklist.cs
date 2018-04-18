using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FleetSystem.Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CheckListYN { get;set; }
        public virtual ChecklistYesNo ChecklistYesNo { get; set; }
        public string Comments { get; set; }
    }
}