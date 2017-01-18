using System.Collections.Generic;
using ParkInspect.DiagramModels;

namespace ParkInspect.Factory
{
    public class DiagramFactory
    {
        private readonly Dictionary<string, IDiagram> _diagrams;
        public IEnumerable<IDiagram> DiagramNames => _diagrams.Values;

        public DiagramFactory()
        {
            _diagrams = new Dictionary<string, IDiagram>
            {
                ["Lijndiagram"] = new LineChart(),
                ["Kaart"] = new MapChart(),
                ["Cirkeldiagram"] = new PieChart(),
                ["Staafdiagram"] = new Staafdiagram()
            };

        }

        public IDiagram GetDiagram(string name)
        {
            return _diagrams[name];
        }
    }
}
