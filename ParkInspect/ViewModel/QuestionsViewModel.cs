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
        private QuestionViewModel _SelectedQuestion;
        IQuestionRepository _repository;
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public QuestionViewModel SelectedQuestion
        {
            get { return _SelectedQuestion; }
            set
            {
                _SelectedQuestion = value;
                EditQuestionCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }


        public RelayCommand EditQuestionCommand { get; set; }
        public ICommand DuplicateQuestionCommand { get; set; }
        public ICommand DisableQuestionCommand { get; set; }

        public QuestionsViewModel(IQuestionRepository repo, IRouterService router) : base(router)
        {
            _repository = repo;
            Questions = repo.GetAll();

            DuplicateQuestionCommand = new RelayCommand(() => DuplicateQuestion(), isSelected);
            DisableQuestionCommand = new RelayCommand(() => DisableQuestion(), isSelected);
            EditQuestionCommand = new RelayCommand(() => RouterService.SetView("question-edit"), isSelected);
        }


        private void DisableQuestion()
        {
            SelectedQuestion.Disable();
            _repository.Delete(SelectedQuestion);
            Questions.Remove(SelectedQuestion);
        }

        

        private void DuplicateQuestion()
        {
            var newQuestion = SelectedQuestion.Duplicate();
            int i = 0;
            foreach (QuestionViewModel q in Questions)
            {
                if (i < q.Id)
                {
                    i = q.Id;
                }
            }
            i++;
            newQuestion.Id = i;
            if (newQuestion == null) return;
            Questions.Add(newQuestion);
        }
        
        private bool isSelected()
        {
            return SelectedQuestion != null;
        }
        
    }
}
