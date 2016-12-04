using System;
using System.Collections.Generic;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;

namespace ParkInspect.ViewModel
{
    public class PieChartViewModel : MainViewModel
    {
        private readonly List<EmployeeViewModel> _employees;
        private readonly List<CommissionViewModel> _commissions;
        private readonly List<QuestionListViewModel> _questionLists;
        private readonly List<QuestionItemViewModel> _questionItems;

        public PieChartViewModel(IEnumerable<EmployeeViewModel> employees, IEnumerable<string> functions,
            string regionFilter)
        {
            _employees = employees.ToList();
            if (!string.IsNullOrEmpty(regionFilter))
            {
                _employees.RemoveAll(evm => !evm.Region.Equals(regionFilter));
            }
            var model = new PlotModel();
            dynamic series = new PieSeries();
            foreach (var function in functions)
            {
                var pieSlice = new PieSlice(function, _employees.Count(evm => evm.Function.Equals(function)));
                if (pieSlice.Value > 0)
                {
                    series.Slices.Add(pieSlice);
                }
            }
            model.Series.Add(series);
            KPIModel = model;
        }

        public PieChartViewModel(IEnumerable<CommissionViewModel> commissions, IEnumerable<string> statuses,
            DateTime? startTime, DateTime? endTime, CustomerViewModel cvm)
        {
            _commissions = commissions.ToList();
            if (startTime != null && endTime != null)
            {
                _commissions.RemoveAll(co => (co.DateCreated > endTime || co.DateCompleted < startTime));
            }
            if (cvm != null)
            {
                _commissions.RemoveAll(co => co.CustomerId != cvm.Id);
            }
            var model = new PlotModel();
            dynamic series = new PieSeries();

            foreach (var status in statuses)
            {
                PieSlice ps = new PieSlice(status, _commissions.Count(co => co.Status.Equals(status)));
                if (ps.Value > 0)
                {
                    series.Slices.Add(ps);
                }
            }
            model.Series.Add(series);
            KPIModel = model;
        }

        public PieChartViewModel(IEnumerable<QuestionItemViewModel> questionItems, CommissionViewModel cvm,
            string regionFilter, DateTime? startTime, DateTime? endTime, QuestionItemViewModel question)
        {
            _questionItems = questionItems.ToList();

            if (cvm != null)
            {
                //remove wat dingesen ofzo
            }
            if (!string.IsNullOrEmpty(regionFilter))
            {
                //remove nog wat dingesen ofzo
            }
            if (startTime != null && endTime != null)
            {
                //remove nog meer dingesen. yay
            }
            if (question != null)
            {
                _questionItems.RemoveAll(qi => qi.QuestionDescription.Equals(question.QuestionDescription));
            }

            var model = new PlotModel();
            dynamic series = new PieSeries();

            foreach (var questionItem in _questionItems)
            {
                var pieSlice = new PieSlice(questionItem.Answer,
                    _questionItems.Count(qvm => qvm.Answer.Equals(questionItem.Answer)));
                if (pieSlice.Value > 0)
                {
                    series.Slices.Add(pieSlice);
                }
            }
            model.Series.Add(series);
            KPIModel = model;
        }


        public PlotModel KPIModel { get; set; }
    }
}
