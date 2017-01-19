using System.Collections.ObjectModel;

namespace ParkInspect.ViewModel
{
    public class TemplatesViewModel : MainViewModel
    {
        public ObservableCollection<TemplateViewModel> Templates { get; set; }
    }
}
