using GalaSoft.MvvmLight.Command;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using System.Collections.ObjectModel;

namespace ParkInspect.ViewModel
{
    public class QuestionListItemsViewModel : MainViewModel
    {
        private QuestionListViewModel _questionList;
        private QuestionViewModel _selectedQuestion;
        private QuestionItemViewModel _selectedQuestionItem;
        private readonly IQuestionListRepository _questionListRepository;
        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }
        public QuestionItemViewModel SelectedQuestionItem
        {
            get { return _selectedQuestionItem; }
            set
            {
                _selectedQuestionItem = value;
                DeleteQuestionCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public RelayCommand AddQuestionCommand { get; set; }
        public RelayCommand DeleteQuestionCommand { get; set; }
        public QuestionViewModel QuestionToAdd
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                AddQuestionCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public QuestionListItemsViewModel(IQuestionRepository questionRepo, IQuestionListRepository questionListRepo, IRouterService router, QuestionListsviewModel questionLists) : base(router)
        {
            _questionListRepository = questionListRepo;
            _questionList = questionLists.SelectedQuestionList;
            QuestionItems = questionLists.SelectedQuestionList.QuestionItems;
            Questions = new ObservableCollection<QuestionViewModel>(questionRepo.GetLatest());
            AddQuestionCommand = new RelayCommand(AddQuestion, CanAddQuestion);
            DeleteQuestionCommand = new RelayCommand(DeleteQuestion, CanDeleteQuestion);
            if (Questions.Count > 0)
            {
                QuestionToAdd = Questions[0];
            }
        }

        private bool CanAddQuestion() => QuestionToAdd != null;

        private bool CanDeleteQuestion() => SelectedQuestionItem != null;

        private void AddQuestion()
        {
            var questionItem = new QuestionItemViewModel
            {
                Question = QuestionToAdd,
                QuestionList = _questionList
            };
            _questionListRepository.AddItem(_questionList, questionItem);
        }

        private void DeleteQuestion()
        {
            _questionListRepository.RemoveItem(_questionList, SelectedQuestionItem);
            SelectedQuestionItem = null;
        }
    }
}
