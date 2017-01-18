using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;
using QuestionType = ParkInspect.Enumeration.QuestionType;

namespace ParkInspect.Repository.Entity
{
    public class EntityQuestionRepository : IQuestionRepository
    {
        private ObservableCollection<QuestionViewModel> _questions;
        private ObservableCollection<QuestionViewModel> _currentQuestions;
        private readonly ParkInspectEntities _context;

        public EntityQuestionRepository(ParkInspectEntities context)
        {
            _context = context;
            GetAll();
        }

        public ObservableCollection<QuestionViewModel> GetAll()
        {
            if (_questions == null) _questions = new ObservableCollection<QuestionViewModel>();
            _questions.Clear();

            var questions = _context.Question.Include("QuestionType");
            foreach (var q in questions)
            {
                QuestionType result;
                Enum.TryParse(q.QuestionType.Name, true,out result );

                if (!q.IsActive) continue;
                _questions.Add(new QuestionViewModel()
                {
                    Id = q.Id,
                    Version = q.Version,
                    Description = q.Description,
                    QuestionType = result
                });
            }
            RefreshCurrentQuestions();
            return _questions;
        }

        public bool Add(QuestionViewModel item)
        {
            var list = _context.QuestionType.ToList();
            Data.QuestionType questionType = null;
            foreach (var qt in list)
            {
                QuestionType qEnum;
                Enum.TryParse(qt.Name, true, out qEnum);
                if (!item.QuestionType.Equals(qEnum)) continue;
                questionType = qt;
                break;
            }
            if (questionType == null) return false;
            var question = new Question() { QuestionTypeId = questionType.Id,Description = item.Description,Version = 1,IsActive = true};
            _context.Question.Add(question);
            _questions.Add(item);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(QuestionViewModel item)
        {
            var question = _context.Question.Include("QuestionType").FirstOrDefault(q => q.Id == item.Id&&q.Version == item.Version);
            if (question != null)
            {
                question.IsActive = false;
                _context.Entry(question).State = EntityState.Modified;
                _context.SaveChanges();
                _questions.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(QuestionViewModel item)
        {
            var question = _context.Question.Include("QuestionType").FirstOrDefault(q => q.Id == item.Id && q.Version == item.Version);
            if (question != null)
            {
                var questionCopy = new Question { Description = question.Description, Version = question.Version + 1, Guid = Guid.NewGuid(), Id = question.Id, IsActive = question.IsActive, QuestionTypeId = question.QuestionTypeId, QuestionTypeGuid = question.QuestionTypeGuid };

                question.IsActive = false;
                _context.Question.Add(questionCopy);
                _context.SaveChanges();
                item.Version++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public ObservableCollection<QuestionViewModel> GetLatest()
        {
            RefreshCurrentQuestions();
            return _currentQuestions;
        }

        private void RefreshCurrentQuestions()
        {
            if (_currentQuestions == null) _currentQuestions = new ObservableCollection<QuestionViewModel>();
            _currentQuestions.Clear();

            foreach (var questionViewModel in _questions.Where(q => !(from qq in _questions
                                                                      where qq.Id == q.Id && qq.Version > q.Version
                                                                      select qq).Any()))
            {
                _currentQuestions.Add(questionViewModel);
            }
        }
    }
}
