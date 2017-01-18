using System.Collections.Generic;

namespace ParkInspect.DiagramModels
{
    public interface IDiagram
    {
        string Name { get; set; }
        Dictionary<string, List<Filter>> Options { get; set; }
    }

    public enum Filter
    {
        Klant,
        Locatie,
        Tijdsperiode,
        Opdracht,
        Vraag,
        Functie,
        Inspecteur,
        Manager,
        Status
    }
}
