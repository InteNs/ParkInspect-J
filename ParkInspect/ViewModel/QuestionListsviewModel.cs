using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;

namespace ParkInspect.ViewModel
{
    public class QuestionListsviewModel : MainViewModel
    {
        private IQuestionListRepository _questionListRepository;
        public ObservableCollection<QuestionListViewModel> QuestionLists { get; set; }

        public QuestionListsviewModel(IQuestionListRepository repo)
        {
            _questionListRepository = repo;
            QuestionLists = _questionListRepository.GetAll();
        }
    }
}
