using OxyPlot;

namespace ParkInspect.ViewModel
{
    public interface IGraphViewModel
    {
        PlotModel KPIModel { get; set; }
    }
}
