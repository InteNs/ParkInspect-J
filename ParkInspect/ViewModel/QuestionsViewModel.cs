using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.Service;
using ParkInspect.Repository.Interface;

namespace ParkInspect.ViewModel
{
    public class QuestionsViewModel : MainViewModel
    {
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public QuestionViewModel SelectedQuestion { get; set; }
        public ICommand UpdateQuestionCommand { get; set; }
        public ICommand DuplicateQuestionCommand { get; set; }
        public ICommand CreateQuestionCommand { get; set; }
        public ICommand DisableQuestionCommand { get; set; }
        public ICommand ReloadQuestionCommand { get; set; }

        public QuestionsViewModel(IQuestionRepository repo, IRouterService router) : base(router)
        {
            Questions = repo.GetAll();
        }


        private bool CanSaveQuestion(QuestionViewModel q)
        {
            return q?.Description?.Replace(" ", "").Length > 0;
        }

        private void CreateQuestion()
        {
            //var newQuestion = new QuestionViewModel(Context);
            //Questions.Add(newQuestion);
        }
    }
}
