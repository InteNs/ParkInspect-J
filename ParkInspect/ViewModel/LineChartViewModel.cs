﻿using System;
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
        private List<DateTime> _timeRange;
        private DateTime startTime;
        private DateTime endTime;

        public PlotModel KPIModel { get; set; }

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
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
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
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
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
                    model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
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

        public LineChartViewModel(IEnumerable<EmployeeViewModel> employees, DateTime? startTime, DateTime? endTime, string functionFilter,
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


        }
    }

    
}

