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
        public ICommand DisableQuestionCommand { get; set; }

        public QuestionsViewModel(IQuestionRepository repo, IRouterService router) : base(router)
        {
            Questions = repo.GetAll();

            DuplicateQuestionCommand = new RelayCommand(() => DuplicateQuestion(), isSelected);
            DisableQuestionCommand = new RelayCommand(DisableQuestion);
        }


        private void UpdateQuestion(QuestionViewModel q)
        {
            var newQuestion = q.Update();
            if (newQuestion == null) return;
            Questions.Add(newQuestion);
            Questions.Remove(q);
        }

        private void DisableQuestion()
        {
            SelectedQuestion.Disable();
            Questions.Remove(SelectedQuestion);
        }

        

        private void DuplicateQuestion()
        {
            var newQuestion = SelectedQuestion.Duplicate();
            if (newQuestion == null) return;
            Questions.Add(newQuestion);
        }
        private bool isSelected()
        {
            foreach (QuestionViewModel q in Questions)
            {
                if(q.Id == SelectedQuestion.Id)
                {
                    if(SelectedQuestion.Version < q.Version)
                    {
                        return false;
                    }
                }
            }
            return SelectedQuestion != null;
        }
    }
}
