using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Helper;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class QuestionListViewModel : MainViewModel
    {
        private int _id;
        private string _description;
        private int _questionNr;
        private QuestionItemViewModel _currentQuestion;
        private readonly IQuestionListRepository _questionListRepository;

        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged(); }
        }

        public ICommand NextQuestionCommand { get; set; }
        public ICommand PreviousQuestionCommand { get; set; }
        public ICommand AnswerTrueCommand { get; set; }
        public ICommand AnswerFalseCommand { get; set; }
        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }
        public InspectionViewModel Inspection { get; set; }

        public QuestionItemViewModel CurrentQuestion
        {
            get { return _currentQuestion; }
            set { _currentQuestion = value; RaisePropertyChanged(); }
        }

        public QuestionListViewModel(IEnumerable<QuestionItemViewModel> questions, IQuestionListRepository questionListRepository, IRouterService router) : base(router)
        {
            _questionListRepository = questionListRepository;
            _questionNr = 0;
            QuestionItems = new ObservableCollection<QuestionItemViewModel>(questions);
            if (CurrentQuestion != null)
            {
                CurrentQuestion = QuestionItems.First();
            }
            NextQuestionCommand = new RelayCommand(NextQuestion);
            PreviousQuestionCommand = new RelayCommand(PreviousQuestion);
            AnswerFalseCommand = new RelayCommand(AnswerFalse);
            AnswerTrueCommand = new RelayCommand(AnswerTrue);
        }
        public QuestionListViewModel(IQuestionListRepository questionListRepository, IRouterService router) : base(router)
        {
            _questionListRepository = questionListRepository;
            QuestionItems = new ObservableCollection<QuestionItemViewModel>();
            MessengerInstance.Register<ObservableCollection<QuestionItemViewModel>>(this, SetQuestions);
        }

        public void SetQuestions(ObservableCollection<QuestionItemViewModel> items)
        {
            QuestionItems = items;
            _questionNr = 0;
            if(items.Count > 0)
            {
                CurrentQuestion = QuestionItems[_questionNr];
                NextQuestionCommand = new RelayCommand(NextQuestion);
                PreviousQuestionCommand = new RelayCommand(PreviousQuestion);
                AnswerFalseCommand = new RelayCommand(AnswerFalse);
                AnswerTrueCommand = new RelayCommand(AnswerTrue);
            }
            RaisePropertyChanged("");
        }

        public void NextQuestion()
        {
            _questionListRepository.UpdateQuestionItem(this, CurrentQuestion);
            if (_questionNr + 1 < QuestionItems.Count())
            {
                CurrentQuestion = QuestionItems[_questionNr + 1];
                _questionNr++;
            }
            else
            {
                new MetroDialogService().ShowMessage("De vragenlijst is afgerond", "U keert nu terug naar het overzicht.");
                RouterService.SetPreviousView();
            }
        }

        public void PreviousQuestion()
        {
            if (_questionNr <= 0) return;
            CurrentQuestion = QuestionItems[_questionNr - 1];
            _questionNr--;
        }

        public void AnswerTrue()
        {
            _currentQuestion.Answer = "Ja";
            NextQuestion();
        }

        public void AnswerFalse()
        {
            _currentQuestion.Answer = "Nee";
            NextQuestion();
        }
    }
}
