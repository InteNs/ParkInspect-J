using ParkInspect.DiagramModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect
{
    public class DiagramFactory
    {
        public IEnumerable<IDiagram> DiagramNames => _diagrams.Values;

        private readonly Dictionary<string, IDiagram> _diagrams;

        public DiagramFactory()
        {
            _diagrams = new Dictionary<string, IDiagram>
            {
                ["Grafiek"] = new Grafiek(),
                ["Kaart"] = new Kaart(),
                ["Cirkeldiagram"] = new Cirkeldiagram(),
                ["Staafdiagram"] = new Staafdiagram()
            };

        }

        public IDiagram GetDiagram(string name)
        {
            return _diagrams[name];
        }
    }
}
