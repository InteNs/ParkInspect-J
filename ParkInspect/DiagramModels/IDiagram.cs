using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect
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
