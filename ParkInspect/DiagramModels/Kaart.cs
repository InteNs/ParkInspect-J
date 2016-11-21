using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.DiagramModels
{
    public class Kaart : IDiagram
    {
        public string Name { get; set; }
        public List<string> Properties { get; set; }

        public Kaart()
        {
            Name = "Kaart";
            Properties = new List<string> {"Locatie"};
        }
    }
}
