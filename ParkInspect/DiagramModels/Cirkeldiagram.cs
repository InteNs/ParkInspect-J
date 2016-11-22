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
        public Dictionary<string, List<Filter>> Options { get; set; }

        public Cirkeldiagram()
        {
            Name = "Cirkeldiagram";
            Options = new Dictionary<string, List<Filter>>
            {
                ["Verdeling van de functies van de werknemers"] = new List<Filter>
                {
                    Filter.Locatie
                },
                ["Verdeling van de status van de opdrachten"] = new List<Filter>
                {
                    Filter.Tijdsperiode, Filter.Klant
                },
                ["Verdeling van de verschillende antwoorden dat is gegeven op een specifieke vraag"] = new List<Filter>
                {
                    Filter.Opdracht,
                    Filter.Locatie,
                    Filter.Tijdsperiode,
                    Filter.Vraag
                }
            };
        }
    }
}
