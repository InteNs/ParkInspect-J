using System.Collections.Generic;

namespace ParkInspect.DiagramModels
{
    public class PieChart : IDiagram
    {
        public string Name { get; set; }
        public Dictionary<string, List<Filter>> Options { get; set; }

        public PieChart()
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
