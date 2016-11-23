using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.ViewModel
{
    public class TemplatesViewModel : MainViewModel
    {
        public ObservableCollection<TemplateViewModel> Templates { get; set; }


    }
}
