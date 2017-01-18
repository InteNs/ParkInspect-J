using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.Repositories;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ParkInspect.ViewModel
{
    public class QuestionListViewModel : MainViewModel
    {
        private int id;
        private string description;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged();
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged();
            }
        }

        public ICommand NextQuestionCommand { get; set; }
        public ICommand PreviousQuestionCommand { get; set; }
        public ICommand AnswerTrueCommand { get; set; }
        public ICommand AnswerFalseCommand { get; set; }
        private int questionNr;

        private QuestionItemViewModel currentQuestion;
        public QuestionItemViewModel CurrentQuestion
        {
            get
            {
                return currentQuestion;
            }
            set
            {
                currentQuestion = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }
        public InspectionViewModel inspection { get; set; }

        public QuestionListViewModel(IEnumerable<QuestionItemViewModel> questions)
        {
            QuestionItems = new ObservableCollection<QuestionItemViewModel>(questions);
            questionNr = 0;
            CurrentQuestion = QuestionItems[questionNr];
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
            if (questionNr + 1 < QuestionItems.Count())
            {
                CurrentQuestion = QuestionItems[questionNr + 1];
                questionNr++;
            }
        }

        private void PreviousQuestion()
        {
            if (questionNr > 0)
            {
                CurrentQuestion = QuestionItems[questionNr - 1];
                questionNr--;
            }
        }

        private void AnswerTrue()
        {
            currentQuestion.Answer = "Ja";
            NextQuestion();
        }

        private void AnswerFalse()
        {
            currentQuestion.Answer = "Nee";
            NextQuestion();
        }
    }
}
