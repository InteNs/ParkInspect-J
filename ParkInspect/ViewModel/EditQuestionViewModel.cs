using GalaSoft.MvvmLight.Command;
using ParkInspect.Enumeration;
using ParkInspect.Helper;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using System.Collections.ObjectModel;

namespace ParkInspect.ViewModel
{
    public class EditQuestionViewModel : MainViewModel
    {
        private readonly IQuestionRepository _questionsRepository;

        public ObservableCollection<QuestionType> QuestionType { get; set; }
        public QuestionViewModel Question { get; set; }
        public RelayCommand EditQuestionCommand { get; set; }
        public EditQuestionViewModel(IQuestionRepository repo, IRouterService router, QuestionsViewModel questions) : base(router)
        {
            QuestionType = new ObservableCollection<QuestionType>
            {
                Enumeration.QuestionType.Boolean,
                Enumeration.QuestionType.Count,
                Enumeration.QuestionType.Open
            };
            _questionsRepository = repo;
            Question = questions.SelectedQuestion;
            EditQuestionCommand = new RelayCommand(Editquestion);
        }
        private void Editquestion()
        {
            if (ValidateInput())
            {
                if (_questionsRepository.Update(Question))
                {
                    RouterService.SetPreviousView();
                }
            }
            else
            {
                new MetroDialogService().ShowMessage("Error", "Error, de velden zijn niet juist ingevuld.");
            }
        }

        //check if all fields are filled in
        private bool ValidateInput() =>  Question.Description != null;
    }
}
