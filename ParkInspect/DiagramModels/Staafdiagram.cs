using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.DiagramModels
{
    public class Staafdiagram : IDiagram
    {
        public string Name { get; set; }
        public Dictionary<string, List<Filter>> Options { get; set; }
        public Staafdiagram()
        {
            Name = "Staafdiagram";
            List<Filter> list1 = new List<Filter>
            {
                Filter.Tijdsperiode, Filter.Vraag, Filter.Opdracht, Filter.Klant
            };
            List<Filter> list2 = new List<Filter>
            {
                Filter.Tijdsperiode, Filter.Status, Filter.Klant
            };
            Options = new Dictionary<string, List<Filter>>
            {
                ["Aantal inspecties per inspecteur"] = list1,
                ["Aantal inspecties per klant"] = list1,
                ["Aantal opdrachten per manager"] = list2,
                ["Aantal opdrachten per klant"] = list2
            };
        }
    }
}
