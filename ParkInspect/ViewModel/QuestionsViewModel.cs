using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.Service;
using ParkInspect.Repository.Interface;

namespace ParkInspect.ViewModel
{
    public class QuestionsViewModel : MainViewModel
    {
        private QuestionViewModel _selectedQuestion;
        private readonly IQuestionRepository _repository;
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
        public ICommand DisableQuestionCommand { get; set; }

        public QuestionsViewModel(IQuestionRepository repo, IRouterService router) : base(router)
        {
            _repository = repo;
            Questions = repo.GetLatest();

            DisableQuestionCommand = new RelayCommand(DisableQuestion, IsSelected);
            EditQuestionCommand = new RelayCommand(() => RouterService.SetView("question-edit"), IsSelected);
        }

        //constructor for unittests
        public QuestionsViewModel()
        {
            Questions = new ObservableCollection<QuestionViewModel>();
        }

        private void DisableQuestion()
        {
            _repository.Delete(SelectedQuestion);
            Questions.Remove(SelectedQuestion);
        }

        public bool IsSelected() => SelectedQuestion != null;
    }
}
