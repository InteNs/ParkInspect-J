using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace ParkInspect.ViewModel
{
    public class BarGraphViewModel : MainViewModel, IGraphViewModel
    {
        private readonly List<CommissionViewModel> _commissions;
        private readonly List<InspectionViewModel> _inspections;

        public PlotModel KpiModel { get; set; }

        public BarGraphViewModel(IEnumerable<InspectionViewModel> inspections, IEnumerable<CommissionViewModel> commissions, IEnumerable<CustomerViewModel> customers, IEnumerable<EmployeeViewModel> employees, DateTime? startTime, DateTime? endTime,
            QuestionItemViewModel question, CommissionViewModel covm, CustomerViewModel selectedCustomer, string person)
        {
            _commissions = commissions.ToList();
            _inspections = inspections.ToList();
            var customers1 = customers.ToList();
            var employees1 = employees.ToList();

            if (startTime != null && endTime != null)
            {
                _inspections.RemoveAll(ins => ins.StartTime < startTime || ins.StartTime > endTime);
               

            }
            if (covm != null)
            {
                foreach(CommissionViewModel comvm in _commissions.Where(co => co.Id != covm.Id))
                {
                    _inspections.RemoveAll(i => i.CommissionViewModel.Id == comvm.Id);
                }
            }

            if (question != null)
            {
                _inspections.RemoveAll(i => question.QuestionList.Inspection.Id != i.Id);
            }

            if (selectedCustomer != null)
            {
                foreach(CommissionViewModel comvm in _commissions.Where(co => co.Customer.Id != selectedCustomer.Id))
                {
                    _inspections.RemoveAll(i => i.CommissionViewModel.Id == comvm.Id);
                }
            }


            PlotModel model = new PlotModel();
            dynamic series = new BarSeries();

            series.LabelPlacement = LabelPlacement.Inside;
            series.LabelFormatString = "{0}";

            var axis = new CategoryAxis();

            if(person.Equals("inspecteur"))
            {
                employees1.RemoveAll(evm => _inspections.Where(ivm => ivm.CommissionViewModel.Employee.Id == evm.Id).Count() == 0);
                series.ItemsSource = new List<BarItem>(employees1.Select(emp =>
                   new BarItem(_inspections.Count(ins =>
                       ins.CommissionViewModel.Employee.Id == (emp.Id)
                   ))
               ));
                axis.Position = AxisPosition.Left;
                axis.ItemsSource = employees1.Select(e => e.Name);
            
        }

            if (person.Equals("klant"))
            {
                customers1.RemoveAll(cvm => _inspections.Where(ivm => ivm.CommissionViewModel.Customer.Id == cvm.Id).Count() == 0);
                series.ItemsSource = new List<BarItem>(customers1.Select(cust =>
                    new BarItem(_inspections.Count(ins =>
                        ins.CommissionViewModel.Customer.Id == (cust.Id)
                    ))
                ));
                axis.Position = AxisPosition.Left;
                axis.ItemsSource = customers1.Select(c => c.Name);
            }
            model.Series.Add(series);
            model.Axes.Add(axis);
            KpiModel = model;
        }


        public BarGraphViewModel(IEnumerable<CommissionViewModel> commissions, IEnumerable<EmployeeViewModel> employees,
            DateTime? startTime, DateTime? endTime, string status,
            CustomerViewModel cvm)
        {
            _commissions = commissions.ToList();
            var employees1 = employees.ToList();

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
            employees1.RemoveAll(evm => _commissions.Where(c => c.Employee.Id == evm.Id).Count() == 0);
            series.ItemsSource = new List<BarItem>(employees1.Select(emp =>
                new BarItem(_commissions.Count(com =>
                    emp.Name.Equals(com.Employee.Name)
                ))
            ));

            var axis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = employees1.Select(e => e.Name)
            };
            model.Series.Add(series);

            model.Axes.Add(axis);
            KpiModel = model;
        }

        public BarGraphViewModel(IEnumerable<CommissionViewModel> commissions, IEnumerable<CustomerViewModel> customers,
            DateTime? startTime, DateTime? endTime, String status,
            CustomerViewModel selectedCustomer)
        {
            _commissions = commissions.ToList();
            var customers1 = customers.ToList();

            if (startTime != null && endTime != null)
            {
                _commissions.RemoveAll(co => (co.DateCreated > endTime || co.DateCompleted < startTime));
            }

            if (!string.IsNullOrEmpty(status))
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
            customers1.RemoveAll(cvm => _commissions.Where(c => c.Customer.Id == cvm.Id).Count() == 0);
            series.ItemsSource = new List<BarItem>(customers1.Select(cust =>
                new BarItem(_commissions.Count(com =>
                    cust.Name.Equals(com.Customer.Name)
                ))
            ));
            foreach (var customer in customers1)
            {
                series.ItemsSource.Add(new BarItem
                {
                    Value =
                        _commissions.Count(c => customer.Name.Equals(c.Customer.Name))
                });
            }
            var axis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = customers1.Select(c => c.Name)
            };
            model.Series.Add(series);
            model.Axes.Add(axis);
            KpiModel = model;
        }
    }
}
