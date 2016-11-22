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
        public Dictionary<string, List<string>> Options { get; set; }

        public Kaart()
        {
            Name = "Kaart";
            Options = new Dictionary<string, List<string>>
            {
                ["Aantal opdrachten per locatie"] = new List<string>
                {
                    "tijdsperiode", "klant", "manager", "status"
                },
                ["Aantal inspecties per locatie"] = new List<string>
                {
                    "tijdsperiode", "inspecteur", "antwoord"
                },
                ["Aantal inspecteurs per locatie"] = new List<string>(),
                ["Aantal klanten per locatie"] = new List<string>()
            };
        }
    }
}
