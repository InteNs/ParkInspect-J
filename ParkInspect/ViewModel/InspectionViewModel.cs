using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.ViewModel
{
    public class InspectionViewModel
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; }

        public InspectionViewModel(string name)
        {
            Name = name;
            IsChecked = false;
        }
    }
}
