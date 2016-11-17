using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.DummyModel
{
    public class Employee
    {
        public int Id { get; set; }
        public DateTime Employment_Date { get; set; }
        public DateTime Dismissal_Date { get; set; }
        public Region Region { get; set; }
        public Function Function { get; set; }
        public Person Person { get; set; }
    }
}
