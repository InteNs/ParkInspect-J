using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using ParkInspect.Repository.Interface;

namespace ParkInspect.ViewModel
{
    public class BarGraphViewModel : MainViewModel, IGraphViewModel
    {
        private readonly List<EmployeeViewModel> _employees;
        private readonly List<QuestionItemViewModel> _questionItems;
        private readonly List<CommissionViewModel> _commissions;
        private readonly List<CustomerViewModel> _customers;

        public PlotModel KPIModel { get; set; }

        public BarGraphViewModel(IEmployeeRepository ier, DateTime? startTime, DateTime? endTime,
            QuestionItemViewModel question, CommissionViewModel covm, CustomerViewModel selectedCustomer)
        {
            _employees = ier.GetAll().ToList();
            _questionItems = new List<QuestionItemViewModel>();

            if (startTime != null && endTime != null)
            {
                //remove nog meer dingesen. yay
            }
            if (covm != null)
            {
                //
            }
            if (question != null)
            {
                _questionItems.RemoveAll(qi => qi.QuestionDescription.Equals(question.QuestionDescription));
            }
            if (selectedCustomer != null)
            {
                //
            }


            PlotModel model = new PlotModel();
            dynamic series = new BarSeries();
            // foreach ()
            //  {
            //BarItem bi = new BarItem();
            // if (bi.Value != 0)
            // {
            //    series.Add(bi);
            // }
            //  }
            model.Series.Add(series);
            KPIModel = model;
        }


        public BarGraphViewModel(IEnumerable<CommissionViewModel> commissions, IEnumerable<EmployeeViewModel> employees,
            DateTime? startTime, DateTime? endTime, string status,
            EmployeeViewModel evm)
        {
            _commissions = commissions.ToList();
            _employees = employees.ToList();

            if (startTime != null && endTime != null)
            {
                _commissions.RemoveAll(co => (co.DateCreated > endTime || co.DateCompleted < startTime));
            }

            if (!string.IsNullOrEmpty(status))
            {
                _commissions.RemoveAll(com => !com.Status.Equals(status));
                Debug.WriteLine(status);
            }
            if (evm != null)
            {
                _commissions.RemoveAll(co => co.Employee != evm);
            }
            var model = new PlotModel();
            dynamic series = new BarSeries();

            series.LabelPlacement = LabelPlacement.Inside;
            series.LabelFormatString = "{0}";
            series.ItemsSource =
                new List<BarItem>(_employees.Select(e =>
                        new BarItem(_commissions.Count(c =>
                                    e.Equals(c.Employee)
                        ))
                ));

            var axis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = _employees.Select(e => e.Name)
            };
            model.Series.Add(series);

            model.Axes.Add(axis);
            KPIModel = model;
        }

        public BarGraphViewModel(IEnumerable<CommissionViewModel> commissions, IEnumerable<CustomerViewModel> customers,
            DateTime? startTime, DateTime? endTime, String status,
            CustomerViewModel selectedCustomer)
        {
            _commissions = commissions.ToList();
            _customers = customers.ToList();

            if (startTime != null && endTime != null)
            {
                _commissions.RemoveAll(co => (co.DateCreated > endTime || co.DateCompleted < startTime));
            }

            if (!String.IsNullOrEmpty(status))
            {
                _commissions.RemoveAll(com => !com.Status.Equals(status));
            }
            if (selectedCustomer != null)
            {
                _commissions.RemoveAll(co => co.Customer != selectedCustomer);
            }
            PlotModel model = new PlotModel();
            dynamic series = new BarSeries();
            
            series.LabelPlacement = LabelPlacement.Inside;
            series.LabelFormatString = "{0}";
            series.ItemsSource = new List<BarItem>(_customers.Select(cust =>
                new BarItem(_commissions.Count(com =>
                    cust.Name.Equals(com.Customer.Name)
                ))
            ));
            foreach (var customer in _customers)
            {
                series.ItemsSource.Add(new BarItem
                {
                    Value =
                        (_commissions.Count(c => customer.Name.Equals(c.Customer.Name)))
                });
            }
            var axis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = _customers.Select(c => c.Name)
            };
            model.Series.Add(series);
            model.Axes.Add(axis);
            KPIModel = model;
        }
    }
}
