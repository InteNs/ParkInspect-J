using System.Collections.ObjectModel;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface IQuestionRepository : IBaseRepository<QuestionViewModel>
    {
        ObservableCollection<QuestionViewModel> GetLatest(QuestionListViewModel list);
    }
}
