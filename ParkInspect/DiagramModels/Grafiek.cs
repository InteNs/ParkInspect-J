using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.DiagramModels
{
    public class Grafiek : IDiagram
    {
        public string Name { get; set; }
        public List<string> Properties { get; set; }

        public Grafiek()
        {
            Name = "Grafiek";
            Properties = new List<string>();
        }
    }
}
