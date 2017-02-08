using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class QuestionListsviewModel : MainViewModel
    {
        private QuestionListViewModel _selectedQuestionList;
        private readonly IQuestionListRepository _repository;
        public ObservableCollection<QuestionListViewModel> QuestionLists { get; set; }
        public RelayCommand EditQuestionCommand { get; set; }
        public RelayCommand DisableQuestionCommand { get; set; }
        public RelayCommand EditQuestionListCommand { get; set; }
        public ICommand NewQuestionCommand { get; set; }
        public QuestionListViewModel SelectedQuestionList
        {
            get { return _selectedQuestionList; }
            set
            {
                _selectedQuestionList = value;
                EditQuestionCommand.RaiseCanExecuteChanged();
                DisableQuestionCommand.RaiseCanExecuteChanged();
                EditQuestionListCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public QuestionListsviewModel(IQuestionListRepository repo, IRouterService router) : base(router)
        {
            _repository = repo;
            QuestionLists = repo.GetAll();
            DisableQuestionCommand = new RelayCommand(DisableQuestionList, CanEditquestionList);
            EditQuestionCommand = new RelayCommand(() => RouterService.SetView("question-list"), CanEditquestionList);
            EditQuestionListCommand = new RelayCommand(() => RouterService.SetView("questionList-edit"), CanEditquestionList);
            NewQuestionCommand = new RelayCommand(CreateQuestionList);
        }

        private bool CanEditquestionList() => SelectedQuestionList != null; 

        private void DisableQuestionList()
        {
            _repository.Delete(SelectedQuestionList);
            QuestionLists.Remove(SelectedQuestionList);
        }
        private void CreateQuestionList()
        {
            var newList = new QuestionListViewModel(_repository, RouterService);
            newList.Description = "nieuwe vragenlijst nr: " + newList.Id;
            _repository.Add(newList);
        }
    }
}
