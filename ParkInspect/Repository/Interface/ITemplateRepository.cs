using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface ITemplateRepository :IBaseRepository<TemplateViewModel>
    {
        bool AddItem(TemplateViewModel list, QuestionItemViewModel item);
        bool RemoveItem(TemplateViewModel list, QuestionItemViewModel item);
    }
}
