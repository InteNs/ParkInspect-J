using System;

namespace ParkInspect.ViewModel
{
    public class InspectionViewModel
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public CommissionViewModel cvm { get; set; }
        public DateTime date { get; set; }

        public InspectionViewModel()
        {
            IsChecked = false;
        }
    }
}
