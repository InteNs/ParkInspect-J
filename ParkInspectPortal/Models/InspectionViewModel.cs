using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkInspectPortal.Models
{
    public class InspectionViewModel
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime? DateTimeEnd { get; set; }
    }
}