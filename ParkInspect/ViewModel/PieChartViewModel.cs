using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.DiagramModels;
using OxyPlot;
using OxyPlot.Series;
using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
   public class PieChartViewModel : MainViewModel
   {

       private List<EmployeeViewModel> _employeesList;
       private List<CommissionViewModel> _commissionsList;
       private List<QuestionViewModel> _questionsList;
        public PieChartViewModel(IEmployeeRepository ier, string RegionFilter)
        {
            _employeesList = ier.GetAll().ToList();
            if (!String.IsNullOrEmpty(RegionFilter))
            {
                _employeesList.RemoveAll(evm => !evm.Region.Equals(RegionFilter));
            }
            PlotModel model = new PlotModel();
            dynamic series = new PieSeries();
            foreach (string function in ier.GetFunctions())
            {
                PieSlice ps = new PieSlice(function, _employeesList.Count(evm => evm.Function.Equals(function)));
                if (ps.Value != 0)
                {
                    series.Slices.Add(ps);
                }
            }
            model.Series.Add(series);
            pieChart = model;
        }

        public PieChartViewModel(ICommissionRepository icr, DateTime? startTime, DateTime? endTime, CustomerViewModel cvm)
        {
            _commissionsList = icr.GetAll().ToList();
            if (startTime != null && endTime != null)
            {
                _commissionsList.RemoveAll(co => (co.DateCreated > endTime || co.DateCompleted < startTime));
            }
            if (cvm != null)
            {
                _commissionsList.RemoveAll(co => co.CustomerId != cvm.Id);
            }
            PlotModel model = new PlotModel();
            dynamic series = new PieSeries();
            string[] statuses = new string[4] { "Nieuw", "Ingedeeld", "Bezig", "Klaar"};
            foreach (string status in statuses)
            {
                PieSlice ps = new PieSlice(status, _commissionsList.Count(co => co.Status.Equals(status)));
                if (ps.Value != 0)
                {
                    series.Slices.Add(ps);
                }
            }
            model.Series.Add(series);
            pieChart = model;
        }
        public PieChartViewModel(IQuestionRepository iqr, CommissionViewModel cvm, String RegionFilter, DateTime? startTime, DateTime? endTime, QuestionViewModel question)
        {
            _questionsList = iqr.GetAll().ToList();

            if (cvm != null)
            {
                _commissionsList.RemoveAll(co => co.CustomerId != cvm.Id);
            }
            if (!String.IsNullOrEmpty(RegionFilter))
            {
                _employeesList.RemoveAll(evm => !evm.Region.Equals(RegionFilter));
            }
            
            
            PlotModel model = new PlotModel();
            dynamic series = new PieSeries();
            string[] statuses = new string[4] { "Nieuw", "Ingedeeld", "Bezig", "Klaar" };
            foreach (string status in statuses)
            {
                PieSlice ps = new PieSlice(status, _commissionsList.Count(co => co.Status.Equals(status)));
                if (ps.Value != 0)
                {
                    series.Slices.Add(ps);
                }
            }
            model.Series.Add(series);
            pieChart = model;
        }


        public PlotModel pieChart { get; set; }
    }
}
