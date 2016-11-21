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
        List<string> Properties { get; set; }

    }
}
