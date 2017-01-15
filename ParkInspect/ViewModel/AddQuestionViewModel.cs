using GalaSoft.MvvmLight.Command;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class AddQuestionViewModel : MainViewModel
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionViewModel Question { get; set; }
        public ICommand AddQuestionCommand { get; set; }
        public AddQuestionViewModel(IQuestionRepository repo, IRouterService router) : base(router)
        {
            _questionRepository = repo;
            Question = new QuestionViewModel();

            AddQuestionCommand = new RelayCommand(AddEmployee, CanAddEmployee);
        }

        private bool CanAddEmployee()
        {
            //TODO: check if all fields are filled in
            return true;
        }

        private bool ValidateInput()
        {
            //TODO: Check if all fields have the right content
            return true;
        }

        private void AddEmployee()
        {
            if (ValidateInput())
            {
                if (_questionRepository.Add(Question))
                {
                    Question.Version = 1;
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
