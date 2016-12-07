using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;

namespace ParkInspect.ViewModel
{
  public class LineChartViewModel : MainViewModel, IGraphViewModel
    {
        public PlotModel KPIModel { get; set; }
    }
}
