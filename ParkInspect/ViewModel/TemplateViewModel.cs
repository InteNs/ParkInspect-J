using System.Collections.Generic;

namespace ParkInspect.ViewModel
{
    public class TemplateViewModel : MainViewModel
    {
        public string Description { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}