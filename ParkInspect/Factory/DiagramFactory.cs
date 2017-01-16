﻿using System.Collections.Generic;
using ParkInspect.DiagramModels;

namespace ParkInspect.Factory
{
    public class DiagramFactory
    {
        public IEnumerable<IDiagram> DiagramNames => _diagrams.Values;

        private readonly Dictionary<string, IDiagram> _diagrams;

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
