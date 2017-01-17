using GalaSoft.MvvmLight.Command;
using ParkInspect.Enumeration;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class AddQuestionViewModel : MainViewModel
    {
        private readonly IQuestionRepository _questionRepository;
        public ObservableCollection<QuestionType> questionType { get; set; }
        public QuestionViewModel Question { get; set; }
        public QuestionsViewModel Questions { get; set; }
        public ICommand AddQuestionCommand { get; set; }
        public AddQuestionViewModel(IQuestionRepository repo, IRouterService router, QuestionsViewModel qvm) : base(router)
        {
            Question = new QuestionViewModel();
            questionType = new ObservableCollection<QuestionType>();
            questionType.Add(QuestionType.Boolean);
            questionType.Add(QuestionType.Count);
            questionType.Add(QuestionType.Open);
            _questionRepository = repo;
            Questions = qvm;
            AddQuestionCommand = new RelayCommand(AddQuestion, CanAddQuestion);
        }

        private bool CanAddQuestion()
        {
            //TODO: check if all fields are filled in
            return true;
        }

        private bool ValidateInput()
        {
            //TODO: Check if all fields have the right content
            return true;
        }

        private void AddQuestion()
        {
            if (ValidateInput())
            {
                int i = 0;
                Question.Version = 1;
                foreach (QuestionViewModel q in Questions.Questions)
                {
                    if (i < q.Id)
                    {
                        i = q.Id;
                    }
                }
                i++;
                Question.Id = i;
                if (_questionRepository.Add(Question))
                {
                    RouterService.SetPreviousView();
                }
            }
            else
            {
                ShowValidationError();
            }
        }
        private void ShowValidationError()
        {
            //TODO: Validation error
        }
    }
}
