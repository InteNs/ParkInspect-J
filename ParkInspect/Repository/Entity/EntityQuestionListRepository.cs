using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using ParkInspect.ViewModel;
using static System.Data.Entity.EntityState;
using QuestionType = ParkInspect.Enumeration.QuestionType;

namespace ParkInspect.Repository.Entity
{
    public class EntityQuestionListRepository : IQuestionListRepository
    {
        private readonly ObservableCollection<QuestionListViewModel> _questionLists;
        private readonly ObservableCollection<QuestionItemViewModel> _questionItems;
        private readonly ParkInspectEntities _context;
        private readonly IRouterService _router;

        public EntityQuestionListRepository(ParkInspectEntities context, IRouterService router)
        {
            _context = context;
            _router = router;
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
                InspectionViewModel inspection;
                if (ql.InspectionId.HasValue)
                    inspection = new InspectionViewModel()
                    {
                        Id = ql.Inspection.Id,
                        CommissionViewModel = new CommissionViewModel {Id = ql.Inspection.Commission.Id}
                    };
                else inspection = null;
                _questionLists.Add(new QuestionListViewModel(this, _router)
                {
                    Description = ql.Description,
                    Id = ql.Id,
                    Inspection = inspection,
                    QuestionItems =
                        new ObservableCollection<QuestionItemViewModel>(
                            ql.QuestionItem.Select(qi => new QuestionItemViewModel
                            {
                                Answer = qi.Answer?.Value,
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
            var questionList = new QuestionList() {Description = item.Description};
            if (item.Inspection != null)
            {
                questionList.Inspection = _context.Inspection.FirstOrDefault(i => i.Id == item.Inspection.Id);
            }
            _context.QuestionList.Add(questionList);
            _context.SaveChanges();
            item.Id = questionList.Id;
            _questionLists.Add(item);
            return true;
        }

        public bool Delete(QuestionListViewModel item)
        {
            QuestionList questionlist = new QuestionList();
            foreach (QuestionList q in _context.QuestionList)
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
            var questionList = _context.QuestionList.Include("QuestionItem").FirstOrDefault(qi => qi.Id == item.Id);
            if (questionList == null) return false;
            questionList.Description = item.Description;
            questionList.InspectionId = item.Inspection?.Id;
            _context.Entry(questionList).State = Modified;
            _context.SaveChanges();
            return true;
        }

        public ObservableCollection<QuestionItemViewModel> GetAllQuestionItems()
        {
            _questionItems.Clear();
            _questionLists.SelectMany(l => l.QuestionItems).ToList().ForEach(i => _questionItems.Add(i));
            return _questionItems;
        }

        public bool AddItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            var questionList = _context.QuestionList.Include("QuestionItem").FirstOrDefault(qi => qi.Id == list.Id);
            if (questionList == null) return false;
            var questionItem = new QuestionItem
            {
                QuestionId = item.QuestionId,
                QuestionVersion = item.QuestionVersion,
                Guid = Guid.NewGuid(),
                QuestionList = questionList
            };
            _context.QuestionItem.Add(questionItem);
            _context.SaveChanges();
            list.QuestionItems.Add(item);
            return true;
        }

        public bool RemoveItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            var questionList = _context.QuestionList.Include("QuestionItem").FirstOrDefault(qi => qi.Id == list.Id);
            var questionItem =
                _context.QuestionItem.FirstOrDefault(
                    qi => qi.QuestionListId == questionList.Id && qi.QuestionId == item.QuestionId);
            if (questionList == null || questionItem == null) return false;
            _context.QuestionItem.Remove(questionItem);
            _context.SaveChanges();
            list.QuestionItems.Remove(item);
            return true;
        }

        public bool CopyTemplate(QuestionListViewModel template, InspectionViewModel inspection)
        {
            var dbTemplate = _context.QuestionList.Include("QuestionItem").Include("QuestionItem.Question").FirstOrDefault(ql => ql.Id == template.Id);
            var dbInspection = _context.Inspection.FirstOrDefault(i => i.Id == inspection.Id);
            if (dbTemplate == null || dbInspection == null) return false;
            var questionItems = dbTemplate.QuestionItem.Select(qi => new QuestionItem {Question = qi.Question}).ToList();
            var list = new QuestionList {Description = template.Description, Inspection = dbInspection, QuestionItem = questionItems};
            _context.QuestionList.Add(list);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateQuestionItem(QuestionListViewModel list, QuestionItemViewModel item)
        {
            var questionItem = _context.QuestionItem.FirstOrDefault(qi => qi.QuestionListId == list.Id && qi.QuestionId == item.QuestionId);
            if (questionItem == null) return false;
            if (!string.IsNullOrEmpty(item.Answer))
            {
                questionItem.Answer = new Answer { Guid = Guid.NewGuid(), Value = item.Answer };
            }
            _context.Entry(questionItem).State = Modified;
            _context.SaveChanges();
            return true;
        }
    }
}