using System.Collections.ObjectModel;
using System.Linq;
using ParkInspect.Enumeration;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public class DummyQuestionRepository : IQuestionRepository
    {
        private ObservableCollection<QuestionViewModel> _questions;
        private ObservableCollection<QuestionViewModel> _currentQuestions;

        public ObservableCollection<QuestionViewModel> GetAll()
        {
            RefreshQuestions();
            return _questions;
        }

        public ObservableCollection<QuestionViewModel> GetLatest(QuestionListViewModel list)
        {
            RefreshCurrentQuestions();
            return _currentQuestions;
        }

        public bool Add(QuestionViewModel item)
        {
            _questions.Add(item);
            return true;
        }

        public bool Delete(QuestionViewModel item)
        {
            return _questions.Remove(item);
        }

        public bool Update(QuestionViewModel item)
        {
            var index = _questions.IndexOf(item);
            _questions.Remove(item);
            _questions.Insert(index, item);
            return true;
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
        public DummyQuestionRepository()
        {
            _questions = new ObservableCollection<QuestionViewModel>();
            _questions.Add(new QuestionViewModel
            {
                Id = 1,
                Version = 4,
                Description = "Is de parkeerplaats vol?",
                QuestionType = QuestionType.Open
            });
            _questions.Add(new QuestionViewModel
            {
                Id = 2,
                Version = 1,
                Description = "Hoeveel auto's staan op de parkeerplaats?",
                QuestionType = QuestionType.Count
            });
            _questions.Add(new QuestionViewModel
            {
                Id = 3,
                Version = 2,
                Description = "Welk merk auto is het meest aanwezig?",
                QuestionType = QuestionType.Open
            });
        }

        private void RefreshQuestions()
        {
            if (_questions == null) _questions = new ObservableCollection<QuestionViewModel>();
            _questions.Clear();

            _questions.Add(new QuestionViewModel
            {
                Id = 1,
                Version = 4,
                Description = "Is de parkeerplaats vol?",
                QuestionType = QuestionType.Open
            });
            _questions.Add(new QuestionViewModel
            {
                Id = 2,
                Version = 1,
                Description = "Hoeveel auto's staan op de parkeerplaats?",
                QuestionType = QuestionType.Count
            });
            _questions.Add(new QuestionViewModel
            {
                Id = 3,
                Version = 2,
                Description = "Welk merk auto is het meest aanwezig?",
                QuestionType = QuestionType.Open
            });
        }
    }
}
