using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.DiagramModels
{
    public class Cirkeldiagram : IDiagram
    {
        public string Name { get; set; }
        public List<string> Properties { get; set; }

        public Cirkeldiagram()
        {
            Name = "Cirkeldiagram";
            Properties = new List<string> {"Werknemers", "Opdrachten", "Antwoord op vraag"};
        }
    }
}
