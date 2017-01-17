using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Enumeration;
using ParkInspect.Helper;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParkInspect.ViewModel
{
    public class EditQuestionViewModel : MainViewModel
    {
        public ObservableCollection<QuestionType> questionType { get; set; }
        public QuestionViewModel Question { get; set; }
        public RelayCommand EditQuestionCommand { get; set; }
        private readonly IQuestionRepository _questionsRepository;
        public EditQuestionViewModel(IQuestionRepository repo, IRouterService router, QuestionsViewModel qvm) : base(router)
        {
            questionType = new ObservableCollection<QuestionType>();
            questionType.Add(QuestionType.Boolean);
            questionType.Add(QuestionType.Count);
            questionType.Add(QuestionType.Open);
            _questionsRepository = repo;
            Question = qvm.SelectedQuestion;
            EditQuestionCommand = new RelayCommand(Editquestion, CanEditquestion);
        }
        private void Editquestion()
        {
            if (this.ValidateInput())
            {
                if (_questionsRepository.Update(Question))
                {
                    RouterService.SetPreviousView();
                }
            }
            else
            {
                new MetroDialogService().ShowMessage("Error", ShowValidationError());
            }
        }

        private bool ValidateInput()
        {
            //check if all fields are filled in
            if (Question.Description == null)
            {
                return false;
            }

            return true;
        }
        private bool CanEditquestion()
        {
            return true;
        }
        private string ShowValidationError()
        {
            return "Error, de velden zijn niet juist ingevuld.";
        }
    }
}
