using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Axes;
using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
    public class BarGraphViewModel : MainViewModel
    {
        private List<EmployeeViewModel> _employeesList;
        private List<QuestionItemViewModel> _questionItemsList;
        private List<CommissionViewModel> _commissionsList;
        private List<CustomerViewModel> _customersList;

        public PlotModel KPIModel { get; set; }

        public BarGraphViewModel(IEmployeeRepository ier, DateTime? startTime, DateTime? endTime, QuestionItemViewModel question, CommissionViewModel covm, CustomerViewModel cuvm)
        {
            _employeesList = ier.GetAll().ToList();
            _questionItemsList = new List<QuestionItemViewModel>();

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
                _questionItemsList.RemoveAll(qi => qi.QuestionDescription.Equals(question.QuestionDescription));
            }
            if (cuvm != null)
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

        

        public BarGraphViewModel(ICommissionRepository icr, DateTime? startTime, DateTime? endTime, String status,
           EmployeeViewModel evm)
        {
            _commissionsList = icr.GetAll().ToList();

            if (startTime != null && endTime != null)
            {
                _commissionsList.RemoveAll(co => (co.DateCreated > endTime || co.DateCompleted < startTime));
            }

            if (!String.IsNullOrEmpty(status))
            {
                _commissionsList.RemoveAll(com => !com.Status.Equals(status));
                Debug.WriteLine(status);
            }
            if (evm != null)
            {
                _commissionsList.RemoveAll(co => co.EmployeeId != evm.Id);
            }
            PlotModel model = new PlotModel();
            dynamic series = new BarSeries();
            series.ItemsSource = new List<BarItem>();
            series.LabelPlacement = LabelPlacement.Inside;
            series.LabelFormatString = "{0}";
            foreach (EmployeeViewModel emvm in icr.GetEmployees())
            {
                series.ItemsSource.Add(new BarItem
                {
                    Value =
                        (_commissionsList.Count(c => emvm.Id.Equals(c.EmployeeId)))
                });
            }
            string[] employeenames = new string[icr.GetEmployees().Count()];
            int i = 0;
            foreach (EmployeeViewModel emvm in icr.GetEmployees())
            {
                employeenames[i] = emvm.Name;
                i++;
            }
            CategoryAxis ca = new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = employeenames
            };
            model.Series.Add(series);
            
            model.Axes.Add(ca);
            KPIModel = model;
        }

        public BarGraphViewModel(ICommissionRepository icr, DateTime? startTime, DateTime? endTime, String status,
            CustomerViewModel cuvm)
        {
            _commissionsList = icr.GetAll().ToList();

            if (startTime != null && endTime != null)
            {
                _commissionsList.RemoveAll(co => (co.DateCreated > endTime || co.DateCompleted < startTime));
            }

            if (!String.IsNullOrEmpty(status))
            {
                _commissionsList.RemoveAll(com => !com.Status.Equals(status));
            }
            if (cuvm != null)
            {
                _commissionsList.RemoveAll(co => co.CustomerId != cuvm.Id);
            }
            PlotModel model = new PlotModel();
            dynamic series = new BarSeries();
            series.ItemsSource = new List<BarItem>();
            series.LabelPlacement = LabelPlacement.Inside;
            series.LabelFormatString = "{0}";
            foreach (CustomerViewModel cusvm in icr.GetCustomers())
            {
                series.ItemsSource.Add(new BarItem
                {
                    Value =
                        (_commissionsList.Count(c => cusvm.Name.Equals(c.CustomerName)))
                });
            }
            string[] customernames = new string[icr.GetCustomers().Count()];
            int i = 0;
            foreach (CustomerViewModel cusvm in icr.GetCustomers())
            {
                customernames[i] = cusvm.Name;
                i++;
            }
            CategoryAxis ca = new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = customernames
            };
            model.Series.Add(series);
            model.Axes.Add(ca);
            KPIModel = model;
        }
    }
}
