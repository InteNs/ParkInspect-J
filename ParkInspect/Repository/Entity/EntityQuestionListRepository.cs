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
            if (s.Equals("Count"))
            {
                return QuestionType.Count;
            }
            else if (s.Equals("Boolean"))
            {
                return QuestionType.Boolean;
            }
            else
            {
                return QuestionType.Open;
            }
        }

        public bool Add(QuestionListViewModel item)
        {
            var questionList = new QuestionList() { Description = item.Description };
            _context.QuestionList.Add(questionList);
            _questionLists.Add(item);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(QuestionListViewModel item)
        {
            QuestionList questionlist = new QuestionList();
            foreach(QuestionList q in _context.QuestionList)
            {
                if(q.Id == item.Id)
                {
                    questionlist = q;
                    break;
                }
            }
            if (questionlist != null)
            {
                _context.QuestionList.Remove(questionlist);
                _questionLists.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(QuestionListViewModel item)
        {
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
            throw new NotImplementedException();
        }

        public bool RemoveItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
