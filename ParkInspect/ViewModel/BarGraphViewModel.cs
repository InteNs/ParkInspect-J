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
        private readonly List<InspectionViewModel> _inspections;


        public PlotModel KPIModel { get; set; }

        
        

        public BarGraphViewModel(IEnumerable<InspectionViewModel> inspections, IEnumerable<CommissionViewModel> commissions, IEnumerable<CustomerViewModel> customers, IEnumerable<EmployeeViewModel> employees, DateTime? startTime, DateTime? endTime,
            QuestionItemViewModel question, CommissionViewModel covm, CustomerViewModel selectedCustomer, string person)
        {
            _commissions = commissions.ToList();
            _inspections = inspections.ToList();
            _customers = customers.ToList();
            _employees = employees.ToList();

            if (startTime != null && endTime != null)
            {
                _inspections.RemoveAll(ins => ins.StartTime < startTime || ins.StartTime > endTime);
               

            }
            if (covm != null)
            {
                foreach(CommissionViewModel comvm in _commissions.Where(co => co.Id != covm.Id))
                {
                    _inspections.RemoveAll(i => i.cvm.Id == comvm.Id);
                }
            }

            if (question != null)
            {
                _inspections.RemoveAll(i => question.questionList.inspection.Id != i.Id);
            }

            if (selectedCustomer != null)
            {
                foreach(CommissionViewModel comvm in _commissions.Where(co => co.Customer.Id != selectedCustomer.Id))
                {
                    _inspections.RemoveAll(i => i.cvm.Id == comvm.Id);
                }
            }


            PlotModel model = new PlotModel();
            dynamic series = new BarSeries();

            series.LabelPlacement = LabelPlacement.Inside;
            series.LabelFormatString = "{0}";

            var axis = new CategoryAxis();

            if(person.Equals("inspecteur"))
            {
                series.ItemsSource = new List<BarItem>(_employees.Select(emp =>
                   new BarItem(_inspections.Count(ins =>
                       ins.cvm.Employee.Id == (emp.Id)
                   ))
               ));
                axis.Position = AxisPosition.Left;
                axis.ItemsSource = _employees.Select(e => e.Name);
            
        }

            if (person.Equals("klant"))
            {
                series.ItemsSource = new List<BarItem>(_customers.Select(cust =>
                    new BarItem(_inspections.Count(ins =>
                        ins.cvm.Customer.Id == (cust.Id)
                    ))
                ));
                //foreach (var customer in _customers)
                //{
                //    series.ItemsSource.Add(new BarItem
                //    {
                //        Value =
                //            (_inspections.Count(i => customer.Id == (i.cvm.Customer.Id)))
                //    });
                //}

                axis.Position = AxisPosition.Left;
                axis.ItemsSource = _customers.Select(c => c.Name);
            }
            model.Series.Add(series);
            model.Axes.Add(axis);
            KPIModel = model;
        }


        public BarGraphViewModel(IEnumerable<CommissionViewModel> commissions, IEnumerable<EmployeeViewModel> employees,
            DateTime? startTime, DateTime? endTime, string status,
            CustomerViewModel cvm)
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
            if (cvm != null)
            {
                _commissions.RemoveAll(co => co.Customer.Id != cvm.Id);
            }
            var model = new PlotModel();
            dynamic series = new BarSeries();

            series.LabelPlacement = LabelPlacement.Inside;
            series.LabelFormatString = "{0}";
            series.ItemsSource = new List<BarItem>(_employees.Select(emp =>
                new BarItem(_commissions.Count(com =>
                    emp.Name.Equals(com.Employee.Name)
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
