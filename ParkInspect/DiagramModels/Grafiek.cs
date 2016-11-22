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
        public Dictionary<string, List<string>> Options { get; set; }

        public Grafiek()
        {
            Name = "Grafiek";
            List<string> list1 = new List<string>
            {
                "tijdsperiode",
                "opdracht",
                "klant",
                "antwoord"
            };
            List<string> list2 = new List<string>
            {
                "tijdsperiode",
                "klant"
            };
            List<string> list3 = new List<string>
            {
                "tijdsperiode",
                "functie",
                "locatie"
            };
            Options = new Dictionary<string, List<string>>
            {
                ["Aantal inspecties die zijn uitgevoerd per dag"] = list1,
                ["Aantal inspecties die zijn uitgevoerd per week"] = list1,
                ["Aantal inspecties die zijn uitgevoerd per maand"] = list1,
                ["Aantal inspecties die zijn uitgevoerd per jaar"] =  list1,
                ["Aantal opdrachten die zijn aangemaakt/afgerond per week"] = list2,
                ["Aantal opdrachten die zijn aangemaakt/afgerond per maand"] = list2,
                ["Aantal opdrachten die zijn aangemaakt/afgerond per jaar"] = list2,
                ["Aantal werknemers die zijn aangenomen/ontslagen per maand"] = list3,
                ["Aantal werknemers die zijn aangenomen/ontslagen per jaar"] = list3
            };
        }
    }
}
