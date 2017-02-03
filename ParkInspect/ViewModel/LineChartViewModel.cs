using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace ParkInspect.ViewModel
{
    public class LineChartViewModel : MainViewModel, IGraphViewModel
    {
        public PlotModel KpiModel { get; set; }

        public LineChartViewModel(IEnumerable<CommissionViewModel> commissions, IEnumerable<InspectionViewModel> inspections, DateTime? startTime, DateTime? endTime, CommissionViewModel comvm,
            CustomerViewModel cuvm, QuestionItemViewModel quest, string interval)
        {
            var commissions1 = commissions.ToList();
            var inspections1 = inspections.ToList();

            PlotModel model = new PlotModel();
            dynamic series1 = new LineSeries();

            var timeRange = new List<DateTime>();

            if (comvm != null)
            {
                //... wat is deze
                foreach (CommissionViewModel covm in commissions1.Where(co => co.Id != comvm.Id))
                {
                    inspections1.RemoveAll(i => i.CommissionViewModel.Id == comvm.Id);
                }
            }

            if (cuvm != null)
            {

                foreach (CommissionViewModel cvm in commissions1.Where(co => co.Customer.Id != cuvm.Id))
                {
                    inspections1.RemoveAll(i => i.CommissionViewModel.Id == cvm.Id);
                }
            }

            if (quest != null)
            {
                inspections1.RemoveAll(i => quest.QuestionList.Inspection.Id != i.Id);
            }

            if (startTime != null && endTime != null)
            {
                DateTime start = (DateTime)startTime;
                DateTime end = (DateTime)endTime;

                if (interval.Equals("dag"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Days,
                        StringFormat = "MM/dd/yyyy"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddDays(1); dt = dt.AddDays(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (inspections1.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                inspections1.Count(ins => ins.StartTime == dt)));
                        }
                    }
                }
                if (interval.Equals("week"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Weeks,
                        StringFormat = "ww"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddDays(6); dt = dt.AddDays(7))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (inspections1.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                inspections1.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddDays(7))));
                        }
                    }
                }
                if (interval.Equals("maand"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Months,
                        StringFormat = "MMM"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddMonths(1); dt = dt.AddMonths(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (inspections1.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                inspections1.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddMonths(1))));
                        }
                    }
                }
                if (interval.Equals("jaar"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Years,
                        StringFormat = "yyyy"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddYears(1); dt = dt.AddYears(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (inspections1.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                inspections1.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddYears(1))));
                        }
                    }
                }

            }
            if (startTime == null && endTime == null)
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                foreach (InspectionViewModel ivm in inspections1)
                {
                    if (ivm.StartTime < start)
                    {
                        start = ivm.StartTime;
                    }
                    if (ivm.StartTime > end)
                    {
                        end = ivm.StartTime;
                    }
                }

                if (interval.Equals("dag"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Days,
                        StringFormat = "MM/dd/yyyy"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddDays(1); dt = dt.AddDays(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (inspections1.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                inspections1.Count(ins => ins.StartTime == dt)));
                        }
                    }
                }
                if (interval.Equals("week"))
                {
                    int delta = DayOfWeek.Monday - start.DayOfWeek;
                    start = start.AddDays(delta);
                    delta = DayOfWeek.Monday - end.DayOfWeek;
                    end = end.AddDays(delta + 7);
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Weeks,
                        StringFormat = "ww"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddDays(6); dt = dt.AddDays(7))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (inspections1.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                inspections1.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddDays(7))));
                        }
                    }
                }
                if (interval.Equals("maand"))
                {
                    start = new DateTime(start.Year, start.Month, 1);
                    end = new DateTime(end.Year, end.AddMonths(1).Month, 1);
                    if (end.Month == new DateTime(2000, 1, 1).Month)
                    {
                        end = end.AddYears(1);
                    }
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Months,
                        StringFormat = "MMM"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddMonths(1); dt = dt.AddMonths(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (inspections1.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                inspections1.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddMonths(1))));
                        }
                    }
                }

                if (interval.Equals("jaar"))
                {
                    start = new DateTime(start.Year, 1, 1);
                    end = new DateTime(end.AddYears(1).Year, 1, 1);
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Years,
                        StringFormat = "yyyy"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddYears(1); dt = dt.AddYears(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (inspections1.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                inspections1.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddYears(1))));
                        }
                    }
                }
            }

            model.Series.Add(series1);
            KpiModel = model;
        }

        public LineChartViewModel(IEnumerable<CommissionViewModel> commissions, DateTime? startTime, DateTime? endTime,
            CustomerViewModel cuvm, string interval)
        {
            var commissions1 = commissions.ToList();
            PlotModel model = new PlotModel();
            dynamic series1 = new LineSeries();
            dynamic series2 = new LineSeries();

            var timeRange = new List<DateTime>();

            if (cuvm != null)
            {

                commissions1.RemoveAll(co => co.Customer.Id != cuvm.Id);
            }

            if (startTime != null && endTime != null)
            {
                DateTime start = (DateTime)startTime;
                DateTime end = (DateTime)endTime;

                if (interval.Equals("week"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Weeks,
                        StringFormat = "ww"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddDays(6); dt = dt.AddDays(7))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (commissions1.Count <= 0) continue;
                        series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddDays(7))));
                        series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddDays(7))));
                    }
                }
                if (interval.Equals("maand"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Months,
                        StringFormat = "MMM"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddMonths(1); dt = dt.AddMonths(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (commissions1.Count <= 0) continue;
                        series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddMonths(1))));
                        series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddMonths(1))));
                    }
                }

                if (interval.Equals("jaar"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Years,
                        StringFormat = "yyyy"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddYears(1); dt = dt.AddYears(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (commissions1.Count <= 0) continue;
                        series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddYears(1))));
                        series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddYears(1))));
                    }
                }
            }

            if (startTime == null && endTime == null)
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;
                foreach (CommissionViewModel cvm in commissions1)
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

                //line for aangemaakt per week
                if (interval.Equals("week"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Weeks,
                        StringFormat = "ww"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddDays(6); dt = dt.AddDays(7))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (commissions1.Count <= 0) continue;
                        series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddDays(7))));
                        series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddDays(7))));
                    }
                }
                if (interval.Equals("maand"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Months,
                        StringFormat = "MMM"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddMonths(1); dt = dt.AddMonths(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (commissions1.Count <= 0) continue;
                        series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddMonths(1))));
                        series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddMonths(1))));
                    }
                }
                if (interval.Equals("jaar"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Years,
                        StringFormat = "yyyy"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddYears(1); dt = dt.AddYears(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {
                        if (commissions1.Count <= 0) continue;
                        series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddYears(1))));
                        series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            commissions1.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddYears(1))));
                    }
                }
            }

            series1.Title = "Aangemaakt";
            series2.Title = "Afgerond";
            model.Series.Add(series1);
            model.Series.Add(series2);
            KpiModel = model;

        }

        public LineChartViewModel(IEnumerable<EmployeeViewModel> employees, DateTime? startTime, DateTime? endTime,
            string functionFilter,
            string regionFilter, string interval)
        {
            var employees1 = employees.Where(o => o.EmploymentDate >= DateTime.ParseExact("010119701200", "ddMMyyyyHHmm", CultureInfo.InvariantCulture)).ToList();

            PlotModel model = new PlotModel();
            dynamic series1 = new LineSeries();
            dynamic series2 = new LineSeries();


            var timeRange = new List<DateTime>();

            if (!string.IsNullOrEmpty(regionFilter))
            {
                employees1.RemoveAll(evm => !evm.Region.Equals(regionFilter));
            }

            if (!string.IsNullOrEmpty(functionFilter))
            {
                employees1.RemoveAll(evm => !evm.Function.Equals(functionFilter));
            }

            if (startTime != null && endTime != null)
            {
                DateTime start = (DateTime)startTime;
                DateTime end = (DateTime)endTime;


                //line for maand
                if (interval.Equals("maand"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Months,
                        StringFormat = "MMM"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddMonths(1); dt = dt.AddMonths(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {

                        series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            employees1.Count(e => e.EmploymentDate >= dt && e.EmploymentDate < dt.AddMonths(1))));

                        series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            employees1.Count(e => e.DismissalDate >= dt && e.DismissalDate < dt.AddMonths(1))));

                    }
                }
                //line voor jaar
                if (interval.Equals("jaar"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Years,
                        StringFormat = "yyyy"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddYears(1); dt = dt.AddYears(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {

                        series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            employees1.Count(e => e.EmploymentDate >= dt && e.EmploymentDate < dt.AddYears(1))));

                        series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            employees1.Count(e => e.DismissalDate >= dt && e.DismissalDate < dt.AddYears(1))));

                    }
                }
            }


            if (startTime == null && endTime == null)
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;
                foreach (EmployeeViewModel evm in employees1)
                {
                    if (evm.EmploymentDate < start)
                    {
                        start = evm.EmploymentDate;
                    }
                    if (evm.DismissalDate > end && evm.DismissalDate != null)
                    {
                        end = (DateTime)evm.DismissalDate;
                    }
                }

                //line for maand
                if (interval.Equals("maand"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Months,
                        StringFormat = "MMM"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddMonths(1); dt = dt.AddMonths(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {

                        series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            employees1.Count(e => e.EmploymentDate >= dt && e.EmploymentDate < dt.AddMonths(1))));

                        series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            employees1.Count(e => e.DismissalDate >= dt && e.DismissalDate < dt.AddMonths(1))));

                    }
                }
                if (interval.Equals("jaar"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Years,
                        StringFormat = "yyyy"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddYears(1); dt = dt.AddYears(1))
                    {
                        timeRange.Add(dt);
                    }
                    foreach (DateTime dt in timeRange)
                    {

                        series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            employees1.Count(e => e.EmploymentDate >= dt && e.EmploymentDate < dt.AddYears(1))));

                        series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                            employees1.Count(e => e.DismissalDate >= dt && e.DismissalDate < dt.AddYears(1))));
                    }
                }
            }

            series1.Title = "Aangenomen";
            series2.Title = "Ontslagen";
            model.Series.Add(series1);
            model.Series.Add(series2);
            KpiModel = model;
        }
    }
}

