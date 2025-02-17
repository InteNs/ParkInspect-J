﻿using System.Collections.Generic;

namespace ParkInspect.DiagramModels
{
    public class MapChart : IDiagram
    {
        public string Name { get; set; }
        public Dictionary<string, List<Filter>> Options { get; set; }

        public MapChart()
        {
            Name = "Kaart";
            Options = new Dictionary<string, List<Filter>>
            {
                ["Aantal opdrachten per locatie"] = new List<Filter>
                {
                    Filter.Tijdsperiode, Filter.Klant, Filter.Manager, Filter.Status
                },
                ["Aantal inspecties per locatie"] = new List<Filter>
                {
                    Filter.Tijdsperiode, Filter.Inspecteur, Filter.Vraag
                },
                ["Aantal inspecteurs per locatie"] = new List<Filter>(),
                ["Aantal klanten per locatie"] = new List<Filter>()
            };
        }
    }
}
