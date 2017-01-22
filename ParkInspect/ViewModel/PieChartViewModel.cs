using System;
using System.Collections.Generic;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;

namespace ParkInspect.ViewModel
{
    public class PieChartViewModel : MainViewModel, IGraphViewModel
    {
        public PlotModel KpiModel { get; set; }

        public PieChartViewModel(IEnumerable<EmployeeViewModel> employees, IEnumerable<string> functions,
            string regionFilter)
        {
            var employees1 = employees.ToList();
            if (!string.IsNullOrEmpty(regionFilter))
            {
                employees1.RemoveAll(evm => !evm.Region.Equals(regionFilter));
            }
            var model = new PlotModel();
            dynamic series = new PieSeries();
            foreach (var function in functions)
            {
                var pieSlice = new PieSlice(function, employees1.Count(evm => evm.Function.Equals(function)));
                if (pieSlice.Value > 0)
                {
                    series.Slices.Add(pieSlice);
                }
            }
            model.Series.Add(series);
            KpiModel = model;
        }

        public PieChartViewModel(IEnumerable<CommissionViewModel> commissions, IEnumerable<string> statuses,
            DateTime? startTime, DateTime? endTime, CustomerViewModel customer)
        {
            var commissions1 = commissions.ToList();
            if (startTime != null && endTime != null)
            {
                commissions1.RemoveAll(co => (co.DateCreated > endTime || co.DateCompleted < startTime));
            }
            if (customer != null)
            {
                commissions1.RemoveAll(co => co.Customer != customer);
            }
            var model = new PlotModel();
            dynamic series = new PieSeries();

            foreach (var status in statuses)
            {
                PieSlice ps = new PieSlice(status, commissions1.Count(co => co.Status.Equals(status)));
                if (ps.Value > 0)
                {
                    series.Slices.Add(ps);
                }
            }
            model.Series.Add(series);
            KpiModel = model;
        }

        public PieChartViewModel(IEnumerable<QuestionItemViewModel> questionItems, IEnumerable<CommissionViewModel> commissions, CommissionViewModel cvm,
            string regionFilter, DateTime? startTime, DateTime? endTime, QuestionItemViewModel question)
        {
            var questionItems1 = questionItems.ToList();
            var commissions1 = commissions.ToList();

            if (cvm != null)
            {
               foreach(CommissionViewModel comvm in commissions1.Where(c => c.Id == cvm.Id))
                {
                    questionItems1.RemoveAll(qi => qi.QuestionList.Inspection.CommissionViewModel.Id != comvm.Id);
                }
            }
            if (!string.IsNullOrEmpty(regionFilter))
            {
                foreach (CommissionViewModel comvm in commissions1.Where(c => c.Region != regionFilter))
                {
                    questionItems1.RemoveAll(qi => qi.QuestionList.Inspection.CommissionViewModel.Id == comvm.Id);
                }
            }
            if (startTime != null && endTime != null)
            {
                questionItems1.RemoveAll(qi => qi.QuestionList.Inspection.StartTime < startTime || qi.QuestionList.Inspection.StartTime > endTime);
            
            }
            if (question != null)
            {
                questionItems1.RemoveAll(qi => qi.Question.Id != (question.Question.Id));
            }

            var model = new PlotModel();
            dynamic series = new PieSeries();

            foreach (var questionItem in questionItems1)
            {
                var pieSlice = new PieSlice(questionItem.Answer,
                    questionItems1.Count(qvm => qvm.Answer.Equals(questionItem.Answer)));
                if (pieSlice.Value > 0)
                {
                    series.Slices.Add(pieSlice);
                }
            }
            model.Series.Add(series);
            KpiModel = model;
        }
    }
}
