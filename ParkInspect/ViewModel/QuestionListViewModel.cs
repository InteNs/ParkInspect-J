using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ParkInspect.ViewModel
{
    public class QuestionListViewModel : MainViewModel
    {
        private int _id;
        private string _description;
        private int _questionNr;
        private QuestionItemViewModel _currentQuestion;

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

        public QuestionItemViewModel CurrentQuestion
        {
            get { return _currentQuestion; }
            set { _currentQuestion = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }
        public InspectionViewModel Inspection { get; set; }

        public QuestionListViewModel(IEnumerable<QuestionItemViewModel> questions)
        {
            QuestionItems = new ObservableCollection<QuestionItemViewModel>(questions);
            _questionNr = 0;
            CurrentQuestion = QuestionItems[_questionNr];
            NextQuestionCommand = new RelayCommand(NextQuestion);
            PreviousQuestionCommand = new RelayCommand(PreviousQuestion);
            AnswerFalseCommand = new RelayCommand(AnswerFalse);
            AnswerTrueCommand = new RelayCommand(AnswerTrue);
        }
        public QuestionListViewModel()
        {
            QuestionItems = new ObservableCollection<QuestionItemViewModel>();
        }

        private void NextQuestion()
        {
            if (_questionNr + 1 >= QuestionItems.Count()) return;
            CurrentQuestion = QuestionItems[_questionNr + 1];
            _questionNr++;
        }

        private void PreviousQuestion()
        {
            if (_questionNr <= 0) return;
            CurrentQuestion = QuestionItems[_questionNr - 1];
            _questionNr--;
        }

        private void AnswerTrue()
        {
            _currentQuestion.Answer = "Ja";
            NextQuestion();
        }

        private void AnswerFalse()
        {
            _currentQuestion.Answer = "Nee";
            NextQuestion();
        }
    }
}
