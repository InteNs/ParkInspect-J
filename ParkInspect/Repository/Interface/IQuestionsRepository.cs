using ParkInspect.ViewModel;
using System.Collections.ObjectModel;

namespace ParkInspect.Repository.Interface
{
    public interface IQuestionsRepository : IBaseRepository<QuestionItemViewModel>
    {
        ObservableCollection<string> GetFunctions();
    }
}
