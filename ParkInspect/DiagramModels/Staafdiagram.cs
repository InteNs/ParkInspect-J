using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect
{
    public class Staafdiagram : IDiagram
    {
        public string Name { get; set; }
        public List<string> Properties { get; set; }
        public Staafdiagram()
        {
            Name = "Staafdiagram";
            Properties = new List<string> {"Inspecteur", "Klant", "Manager"};
        }
    }
}
