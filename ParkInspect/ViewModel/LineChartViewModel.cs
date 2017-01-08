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
        private readonly List<EmployeeViewModel> _employees;
        private readonly List<InspectionViewModel> _inspections;
        private List<DateTime> _timeRange;
        private DateTime startTime;
        private DateTime endTime;

        public PlotModel KPIModel { get; set; }

        public LineChartViewModel(IEnumerable<CommissionViewModel> commissions, IEnumerable<InspectionViewModel> inspections, DateTime? startTime, DateTime? endTime, CommissionViewModel comvm,
            CustomerViewModel cuvm, QuestionItemViewModel quest, string interval)
        {
            _commissions = commissions.ToList();
            _inspections = inspections.ToList();

            PlotModel model = new PlotModel();
            dynamic series1 = new LineSeries();
            dynamic series2 = new LineSeries();


            _timeRange = new List<DateTime>();

            if (comvm != null)
            {
                foreach (CommissionViewModel covm in _commissions.Where(co => co.Id != comvm.Id))
                {
                    _inspections.RemoveAll(i => i.cvm.Id == comvm.Id);
                }
            }

            if (cuvm != null)
            {

                foreach (CommissionViewModel cvm in _commissions.Where(co => co.Customer.Id != cuvm.Id))
                {
                    _inspections.RemoveAll(i => i.cvm.Id == cvm.Id);
                }
            }

            if (quest != null)
            {
                _inspections.RemoveAll(i => quest.questionList.inspection.Id != i.Id);
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
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_inspections.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _inspections.Count(ins => ins.StartTime == dt)));
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
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_inspections.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _inspections.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddDays(7))));
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
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_inspections.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _inspections.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddMonths(1))));
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
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_inspections.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _inspections.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddYears(1))));
                        }
                    }
                }

            }
            if (startTime == null && endTime == null)
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                foreach (InspectionViewModel ivm in _inspections)
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
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_inspections.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _inspections.Count(ins => ins.StartTime == dt)));
                        }
                    }
                }
                if (interval.Equals("week"))
                {
                    int delta = DayOfWeek.Monday - start.DayOfWeek;
                    start = start.AddDays(delta);
                    delta = DayOfWeek.Monday - end.DayOfWeek;
                    end = end.AddDays(delta+7);
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Weeks,
                        StringFormat = "ww"
                    });
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    for (DateTime dt = start; dt <= end.AddDays(6); dt = dt.AddDays(7))
                    {
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_inspections.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _inspections.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddDays(7))));
                        }
                    }
                }
                if (interval.Equals("maand"))
                {
                    start = new DateTime(start.Year, start.Month, 1);
                    end = new DateTime(end.Year, end.AddMonths(1).Month, 1);
                    if(end.Month == new DateTime(2000, 1, 1).Month)
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
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_inspections.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _inspections.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddMonths(1))));
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
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_inspections.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _inspections.Count(ins => ins.StartTime >= dt && ins.StartTime < dt.AddYears(1))));
                        }
                    }
                }
            }


            model.Series.Add(series1);
            KPIModel = model;
        }

        public LineChartViewModel(IEnumerable<CommissionViewModel> commissions, DateTime? startTime, DateTime? endTime,
            CustomerViewModel cuvm, string interval)
        {
            _commissions = commissions.ToList();
            PlotModel model = new PlotModel();
            dynamic series1 = new LineSeries();
            dynamic series2 = new LineSeries();


            _timeRange = new List<DateTime>();

            if (cuvm != null)
            {

                _commissions.RemoveAll(co => co.Customer.Id != cuvm.Id);
            }

            if (startTime != null && endTime != null)
            {
                DateTime start = (DateTime) startTime;
                DateTime end = (DateTime) endTime;

                if (interval.Equals("week"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Weeks,
                        StringFormat = "ww"
                    });
                    model.Axes.Add(new LinearAxis {Position = AxisPosition.Left});
                    for (DateTime dt = start; dt <= end.AddDays(6); dt = dt.AddDays(7))
                    {
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_commissions.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddDays(7))));
                            series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddDays(7))));
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
                    model.Axes.Add(new LinearAxis {Position = AxisPosition.Left});
                    for (DateTime dt = start; dt <= end.AddMonths(1); dt = dt.AddMonths(1))
                    {
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_commissions.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddMonths(1))));
                            series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddMonths(1))));
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
                    model.Axes.Add(new LinearAxis {Position = AxisPosition.Left});
                    for (DateTime dt = start; dt <= end.AddYears(1); dt = dt.AddYears(1))
                    {
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_commissions.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddYears(1))));
                            series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddYears(1))));
                        }
                    }
                }
            }




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

                //line for aangemaakt per week
                if (interval.Equals("week"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Weeks,
                        StringFormat = "ww"
                    });
                    model.Axes.Add(new LinearAxis {Position = AxisPosition.Left});
                    for (DateTime dt = start; dt <= end.AddDays(6); dt = dt.AddDays(7))
                    {
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_commissions.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddDays(7))));
                            series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddDays(7))));
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
                    model.Axes.Add(new LinearAxis {Position = AxisPosition.Left});
                    for (DateTime dt = start; dt <= end.AddMonths(1); dt = dt.AddMonths(1))
                    {
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_commissions.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddMonths(1))));
                            series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddMonths(1))));
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
                    model.Axes.Add(new LinearAxis {Position = AxisPosition.Left});
                    for (DateTime dt = start; dt <= end.AddYears(1); dt = dt.AddYears(1))
                    {
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        if (_commissions.Count > 0)
                        {
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCreated >= dt && c.DateCreated < dt.AddYears(1))));
                            series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _commissions.Count(c => c.DateCompleted >= dt && c.DateCompleted < dt.AddYears(1))));
                        }
                    }
                }
            }


            series1.Title = "Aangemaakt";
            series2.Title = "Afgerond";
            model.Series.Add(series1);
            model.Series.Add(series2);
            KPIModel = model;

        }

        public LineChartViewModel(IEnumerable<EmployeeViewModel> employees, DateTime? startTime, DateTime? endTime,
            string functionFilter,
            string regionFilter, string interval)
        {
            _employees = employees.ToList();

            PlotModel model = new PlotModel();
            dynamic series1 = new LineSeries();
            dynamic series2 = new LineSeries();


            _timeRange = new List<DateTime>();

            if (!string.IsNullOrEmpty(regionFilter))
            {
                _employees.RemoveAll(evm => !evm.Region.Equals(regionFilter));
            }

            if (!string.IsNullOrEmpty(functionFilter))
            {
                _employees.RemoveAll(evm => !evm.Function.Equals(functionFilter));
            }

            if (startTime != null && endTime != null)
            {
                DateTime start = (DateTime) startTime;
                DateTime end = (DateTime) endTime;


                //line for maand
                if (interval.Equals("maand"))
                {
                    model.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        IntervalType = DateTimeIntervalType.Months,
                        StringFormat = "MMM"
                    });
                    model.Axes.Add(new LinearAxis {Position = AxisPosition.Left});
                    for (DateTime dt = start; dt <= end.AddMonths(1); dt = dt.AddMonths(1))
                    {
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                       
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _employees.Count(e => e.EmploymentDate >= dt && e.EmploymentDate < dt.AddMonths(1))));

                            series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _employees.Count(e => e.DismissalDate >= dt && e.DismissalDate < dt.AddMonths(1))));
                        
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
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _employees.Count(e => e.EmploymentDate >= dt && e.EmploymentDate < dt.AddYears(1))));
                       
                                series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                    _employees.Count(e => e.DismissalDate >= dt && e.DismissalDate < dt.AddYears(1))));
                            
                        }
}
                    
                
            }


            if (startTime == null && endTime == null)
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;
                foreach (EmployeeViewModel evm in _employees)
                {
                    if (evm.EmploymentDate < start)
                    {
                        start = evm.EmploymentDate;
                    }
                    if (evm.DismissalDate > end && evm.DismissalDate != null)
                    {
                        end = (DateTime) evm.DismissalDate;
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
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                       
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _employees.Count(e => e.EmploymentDate >= dt && e.EmploymentDate < dt.AddMonths(1))));
                       
                                series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                    _employees.Count(e => e.DismissalDate >= dt && e.DismissalDate < dt.AddMonths(1))));
                        
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
                        _timeRange.Add(dt);
                    }
                    foreach (DateTime dt in _timeRange)
                    {
                        
                            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _employees.Count(e => e.EmploymentDate >= dt && e.EmploymentDate < dt.AddYears(1))));
                       
                            series2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt),
                                _employees.Count(e => e.DismissalDate >= dt && e.DismissalDate < dt.AddYears(1))));
                        
                    }
                }
            }

            series1.Title = "Aangenomen";
            series2.Title = "Ontslagen";
            model.Series.Add(series1);
            model.Series.Add(series2);
            KPIModel = model;
        }


    }
}

