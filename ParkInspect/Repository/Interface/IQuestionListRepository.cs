using System.Collections.ObjectModel;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface IQuestionListRepository : IBaseRepository<QuestionListViewModel>
    {
        ObservableCollection<QuestionItemViewModel> GetAllQuestionItems();
        bool AddItem(QuestionListViewModel list, QuestionItemViewModel item);
        bool RemoveItem(QuestionListViewModel list, QuestionItemViewModel item);
        bool CopyTemplate(QuestionListViewModel template, InspectionViewModel inspection);
        bool UpdateQuestionItem(QuestionListViewModel list, QuestionItemViewModel item);
    }
}
