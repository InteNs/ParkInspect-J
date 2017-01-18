using OxyPlot;

namespace ParkInspect.ViewModel
{
    public interface IGraphViewModel
    {
        PlotModel KpiModel { get; set; }
    }
}
