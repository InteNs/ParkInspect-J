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
        public Dictionary<string, List<string>> Options { get; set; }

        public Cirkeldiagram()
        {
            Name = "Cirkeldiagram";
            Options = new Dictionary<string, List<string>>
            {
                ["Verdeling van de functies van de werknemers"] = new List<string>
                {
                    "locatie"
                },
                ["Verdeling van de status van de opdrachten"] = new List<string>
                {
                    "tijdsperiode", "klant"
                },
                ["Verdeling van de verschillende antwoorden dat is gegeven op een specifieke vraag"] = new List<string>
                {
                    "opdracht",
                    "locatie",
                    "tijdsperiode",
                    "vraag"
                }
            };
        }
    }
}
