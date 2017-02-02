using ParkInspect.Enumeration;

namespace ParkInspect.ViewModel
{
    public class QuestionItemViewModel : MainViewModel
    {
        private string _answer;

        public QuestionViewModel Question { get; set; }
        public QuestionListViewModel QuestionList { get; set; }
        public int QuestionId => Question.Id;
        public int QuestionVersion => Question.Version;
        public string QuestionDescription => Question.Description;
        public QuestionType QuestionType => Question.QuestionType;

        public string Answer
        {
            get { return _answer; }
            set { _answer = value; RaisePropertyChanged(); }
        }

        //Leeg?
        public QuestionItemViewModel()
        {

        }
    }
}
