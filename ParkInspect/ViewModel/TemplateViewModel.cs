using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ParkInspect.ViewModel
{
    public class TemplateViewModel : MainViewModel
    {
        public string Description { get; set; }
        public int Id { get; set; }

        public ObservableCollection<QuestionItemViewModel> QuestionItems { get; set; }

        public TemplateViewModel(IEnumerable<QuestionItemViewModel> questions)
        {
            QuestionItems = new ObservableCollection<QuestionItemViewModel>(questions);
        }
    }
}