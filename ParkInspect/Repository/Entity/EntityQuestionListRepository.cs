using System;
using System.Collections.ObjectModel;
using System.Linq;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;
using QuestionType = ParkInspect.Enumeration.QuestionType;

namespace ParkInspect.Repository.Entity
{
    public class EntityQuestionListRepository : IQuestionListRepository
    {
        private readonly ObservableCollection<QuestionListViewModel> _questionLists;
        private readonly ObservableCollection<QuestionItemViewModel> _questionItems;
        private readonly ParkInspectEntities _context;

        public EntityQuestionListRepository(ParkInspectEntities context)
        {
            _context = context;
            _questionLists = new ObservableCollection<QuestionListViewModel>();
            _questionItems = new ObservableCollection<QuestionItemViewModel>();
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
            //Best veel nesting, maar ik weet niet zo hoe dit het beste opgelost kan worden

            questionlist.ForEach(ql =>
            {
                var inspection = ql.InspectionId.HasValue ? new InspectionViewModel()
                {
                    Id = ql.Inspection.Id,
                    CommissionViewModel = new CommissionViewModel {Id = ql.Inspection.Commission.Id}
                } : null;
                _questionLists.Add(new QuestionListViewModel
                {
                    Description = ql.Description,
                    Id = ql.Id,
                    Inspection = inspection,
                    QuestionItems = new ObservableCollection<QuestionItemViewModel>(ql.QuestionItem.Select(qi => new QuestionItemViewModel
                    {
                        Answer = qi.Answer.Value,
                        Question = new QuestionViewModel
                        {
                            Description = qi.Question.Description,
                            Id = qi.Question.Id,
                            IsActive = qi.Question.IsActive,
                            QuestionType = TypeForString(qi.Question.QuestionType.Name),
                            Version = qi.Question.Version
                        } // end Question
                    })) // end QuestionItems
                }); // end QuestionsLists
            }); // end foreach

            return _questionLists;
        }

        private QuestionType TypeForString(string s)
        {
            return s.Equals("Count")
                ? QuestionType.Count
                : (s.Equals("Boolean") ? QuestionType.Boolean : QuestionType.Open);
        }

        public bool Add(QuestionListViewModel item)
        {
            var questionList = new QuestionList() { Description = item.Description, InspectionId = item.Inspection.Id};
            _context.QuestionList.Add(questionList);
            _context.SaveChanges();
            item.Id = questionList.Id;
            _questionLists.Add(item);
            return true;
        }

        public bool Delete(QuestionListViewModel item)
        {
            QuestionList questionlist = new QuestionList();
            foreach(QuestionList q in _context.QuestionList)
            {
                if (q.Id != item.Id) continue;
                questionlist = q;
                break;
            }
            _context.QuestionList.Remove(questionlist);
            _questionLists.Remove(item);
            _context.SaveChanges();
            return true;
        }

        public bool Update(QuestionListViewModel item)
        {
            // TODO deze function implementeren of weggooien
            throw new NotImplementedException();
        }

        public ObservableCollection<QuestionItemViewModel> GetAllQuestionItems()
        {
            _questionItems.Clear();
            _questionLists.SelectMany(l => l.QuestionItems).ToList().ForEach(i => _questionItems.Add(i));
            return _questionItems;
        }

        public bool AddItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            // TODO deze function implementeren of weggooien
            throw new NotImplementedException();
        }

        public bool RemoveItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            // TODO deze function implementeren of weggooien
            throw new NotImplementedException();
        }
    }
}
