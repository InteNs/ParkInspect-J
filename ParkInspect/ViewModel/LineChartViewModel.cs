using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.Diagnostics;

namespace ParkInspect.ViewModel
{
  public class LineChartViewModel : MainViewModel, IGraphViewModel
    {

        private readonly List<CommissionViewModel> _commissions;
        private List<DateTime> _timeRange;
        private DateTime startTime;
        private DateTime endTime;

        public PlotModel KPIModel { get; set; }

        public LineChartViewModel(IEnumerable<CommissionViewModel> commissions, DateTime? startTime, DateTime? endTime, CustomerViewModel cuvm)
        {
            _commissions = commissions.ToList();

            if (startTime != null && endTime != null)
            {
                _commissions.RemoveAll(co => (co.DateCreated > endTime || co.DateCompleted < startTime));
            }

            if (cuvm != null)
            {
                Debug.WriteLine(cuvm.Id);
                _commissions.RemoveAll(co => co.Customer.Id != cuvm.Id);
            }

            PlotModel model = new PlotModel();

            model.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, IntervalType = DateTimeIntervalType.Weeks, StringFormat = "ww"});
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left});

            dynamic series1 = new LineSeries();
            dynamic series2 = new LineSeries();

            _timeRange = new List<DateTime>();
            //line for aangemaakt per week
            if (startTime == null && endTime == null)
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;
                foreach (CommissionViewModel cvm in _commissions)
                {
                    if (cvm.DateCreated < start)
                    {
                        start = cvm.DateCreated;
                    }
                    if (cvm.DateCreated > end)
                    {
                        end = cvm.DateCreated;
                    }
                }
                for (DateTime dt = start; dt <= end.AddDays(6); dt = dt.AddDays(7))
                {
                   _timeRange.Add(dt); 
                }
            }
            
            foreach (DateTime dt in _timeRange)
            {
                series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt), _commissions.Count(c => c.DateCreated>=dt && c.DateCreated < dt.AddDays(7))));
            }

            model.Series.Add(series1);
            model.Series.Add(series2);
            KPIModel = model;

        }
    }
}
