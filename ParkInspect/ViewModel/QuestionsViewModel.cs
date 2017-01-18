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
        private QuestionViewModel _selectedQuestion;
        private IQuestionRepository _repository;
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public QuestionViewModel SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
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
            Questions = repo.GetLatest();

            DuplicateQuestionCommand = new RelayCommand(() => DuplicateQuestion(), IsSelected);
            DisableQuestionCommand = new RelayCommand(() => DisableQuestion(), IsSelected);
            EditQuestionCommand = new RelayCommand(() => RouterService.SetView("question-edit"), IsSelected);
        }

        private void DisableQuestion()
        {
            _repository.Delete(SelectedQuestion);
            Questions.Remove(SelectedQuestion);
        }
        
        private void DuplicateQuestion()
        {
            var newQuestion = SelectedQuestion.Duplicate();
            if (newQuestion == null) return;
            int i = Questions.Select(q => q.Id).Concat(new[] {0}).Max();
            i++;
            newQuestion.Id = i;
            Questions.Add(newQuestion);
        }
        
        private bool IsSelected() => SelectedQuestion != null;
    }
}
