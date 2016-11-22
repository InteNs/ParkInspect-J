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
        public Dictionary<string, List<string>> Options { get; set; }
        public Staafdiagram()
        {
            Name = "Staafdiagram";
            List<string> list1 = new List<string>
            {
                "tijdsperiode", "antwoord", "opdracht", "klant"
            };
            List<string> list2 = new List<string>
            {
                "tijdsperiode", "status", "klant"
            };
            Options = new Dictionary<string, List<string>>
            {
                ["Aantal inspecties per inspecteur"] = list1,
                ["Aantal inspecties per klant"] = list1,
                ["Aantal opdrachten per manager"] = list2,
                ["Aantal opdrachten per klant"] = list2
            };
        }
    }
}
