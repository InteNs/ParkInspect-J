using System;

namespace ParkInspect.ViewModel
{
    public class InspectionViewModel
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public CommissionViewModel CommissionViewModel { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DateCancelled { get; set; }

        public InspectionViewModel()
        {
            IsChecked = false;
        }
    }
}
