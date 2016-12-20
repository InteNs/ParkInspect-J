using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.Repositories;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ParkInspect.ViewModel
{
    public class QuestionListsviewModel : MainViewModel
    {
        private IQuestionListRepository _questionListRepository;
        public ObservableCollection<QuestionListViewModel> QuestionLists { get; set; }
        public QuestionListViewModel selectedQuestionList { get; set; }
        public ObservableCollection<QuestionItemViewModel> allQuestions;

        public QuestionListsviewModel(IQuestionListRepository repo)
        {
            _repository = repo;
            QuestionLists = new ObservableCollection<QuestionListViewModel>(_repository.GetAll());
            selectedQuestionList = QuestionLists[0];
            allQuestions = new ObservableCollection<QuestionItemViewModel>();
            foreach(QuestionItemViewModel q in selectedQuestionList.QuestionItems)
            {
                allQuestions.Add(q);
            }
        }
    }
}
