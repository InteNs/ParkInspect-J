namespace ParkInspect.ViewModel
{
    public class InspectionViewModel
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public CommissionViewModel cvm { get; set; }


        public InspectionViewModel()
        {
            IsChecked = false;
        }
    }
}
