﻿using System;
using System.Collections.Generic;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;

namespace ParkInspect.ViewModel
{
    public class PieChartViewModel : MainViewModel, IGraphViewModel
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
            DateTime? startTime, DateTime? endTime, CustomerViewModel customer)
        {
            _commissions = commissions.ToList();
            if (startTime != null && endTime != null)
            {
                _commissions.RemoveAll(co => (co.DateCreated > endTime || co.DateCompleted < startTime));
            }
            if (customer != null)
            {
                _commissions.RemoveAll(co => co.Customer != customer);
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

        public PieChartViewModel(IEnumerable<QuestionItemViewModel> questionItems, IEnumerable<CommissionViewModel> commissions, CommissionViewModel cvm,
            string regionFilter, DateTime? startTime, DateTime? endTime, QuestionItemViewModel question)
        {
            _questionItems = questionItems.ToList();
            _commissions = commissions.ToList();

            if (cvm != null)
            {
               foreach(CommissionViewModel comvm in _commissions.Where(c => c.Id == cvm.Id))
                {
                    _questionItems.RemoveAll(qi => qi.questionList.inspection.cvm.Id != comvm.Id);
                }
            }
            if (!string.IsNullOrEmpty(regionFilter))
            {
                foreach (CommissionViewModel comvm in _commissions.Where(c => c.Region != regionFilter))
                {
                    _questionItems.RemoveAll(qi => qi.questionList.inspection.cvm.Id == comvm.Id);
                }
            }
            if (startTime != null && endTime != null)
            {
                _questionItems.RemoveAll(qi => qi.questionList.inspection.date < startTime || qi.questionList.inspection.date > endTime);
            
            }
            if (question != null)
            {
                _questionItems.RemoveAll(qi => qi.Question.Id != (question.Question.Id));
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
