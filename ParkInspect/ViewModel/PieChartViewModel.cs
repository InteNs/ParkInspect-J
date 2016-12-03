using System;
using System.Collections.Generic;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using ParkInspect.Repositories;
using ParkInspect.Repository.Interface;

namespace ParkInspect.ViewModel
{
   public class PieChartViewModel : MainViewModel
   {

       private List<EmployeeViewModel> _employeesList;
       private List<CommissionViewModel> _commissionsList;
       private List<QuestionListViewModel> _questionListsList;
       private List<QuestionItemViewModel> _questionItemsList;
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
            KPIModel = model;
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
            KPIModel = model;
        }
        public PieChartViewModel(IQuestionListRepository iqr, CommissionViewModel cvm, String RegionFilter, DateTime? startTime, DateTime? endTime, QuestionItemViewModel question)
        {
            _questionListsList = iqr.GetAll().ToList();
            _questionItemsList = new List<QuestionItemViewModel>();
            foreach (QuestionListViewModel qlvm in _questionListsList)
            {
                foreach (QuestionItemViewModel qivm in qlvm.QuestionItems)
                {
                    _questionItemsList.Add(qivm);
                }
            }

            if (cvm != null)
            {
                //remove wat dingesen ofzo
            }
            if (!String.IsNullOrEmpty(RegionFilter))
            {
                //remove nog wat dingesen ofzo
            }
            if (startTime != null && endTime != null)
            {
                //remove nog meer dingesen. yay
            }
            if (question != null)
            {
                _questionItemsList.RemoveAll(qi => qi.QuestionDescription.Equals(question.QuestionDescription));
            }

            PlotModel model = new PlotModel();
            dynamic series = new PieSeries();
            
            foreach (QuestionItemViewModel qivm in _questionItemsList)
            {
                PieSlice ps = new PieSlice(qivm.Answer, _questionItemsList.Count(qvm => qvm.Answer.Equals(qivm.Answer)));
                if (ps.Value != 0)
                {
                    series.Slices.Add(ps);
                }
            }
            model.Series.Add(series);
            KPIModel = model;
        }


        public PlotModel KPIModel { get; set; }
    }
}
