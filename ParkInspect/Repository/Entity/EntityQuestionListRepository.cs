using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;
using QuestionType = ParkInspect.Enumeration.QuestionType;

namespace ParkInspect.Repository.Entity
{
    public class EntityQuestionListRepository : IQuestionListRepository
    {
        private readonly ObservableCollection<QuestionListViewModel> _questionLists;
        private readonly ParkInspectEntities _context;

        public EntityQuestionListRepository(ParkInspectEntities context)
        {
            _context = context;
            _questionLists = new ObservableCollection<QuestionListViewModel>();
        }

        public ObservableCollection<QuestionListViewModel> GetAll()
        {
            var questionlist = _context.QuestionList
                .Include("Inspection")
                .Include("Inspection.Commission")
                .Include("QuestionItem")
                .Include("QuestionItem.Answer")
                .Include("QuestionItem.Question")
                .Include("QuestionItem.Question.QuestionType")
                .ToList();

            questionlist.ForEach(ql =>
            {
                var inspection = ql.InspectionId.HasValue ? new InspectionViewModel()
                {
                    Id = ql.Inspection.Id,
                    cvm = new CommissionViewModel {Id = ql.Inspection.Commission.Id}
                } : null;
                _questionLists.Add(new QuestionListViewModel
                {
                    Description = ql.Description,
                    Id = ql.Id,
                    inspection = inspection,
                    QuestionItems = new ObservableCollection<QuestionItemViewModel>(ql.QuestionItem.Select(qi => new QuestionItemViewModel
                    {
                        Answer = qi.Answer.Value,
                        Question = new QuestionViewModel
                        {
                            Description = qi.Question.Description,
                            Id = qi.Question.Id,
                            isActive = qi.Question.IsActive,
                            QuestionType = TypeForString(qi.Question.QuestionType.Name),
                            Version = qi.Question.Version
                        }
                    }))
                });
            });

            return _questionLists;
        }

        private QuestionType TypeForString(string s)
        {
            var qEnum = 0;
            Enum.TryParse(s, true, out qEnum);
            return (QuestionType)qEnum;

        }

        public bool Add(QuestionListViewModel item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(QuestionListViewModel item)
        {
            throw new NotImplementedException();
        }

        public bool Update(QuestionListViewModel item)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<QuestionItemViewModel> GetAllQuestionItems()
        {
            throw new NotImplementedException();
        }

        public bool AddItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
