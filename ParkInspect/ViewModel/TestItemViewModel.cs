using GalaSoft.MvvmLight;

namespace ParkInspect.ViewModel
{
    public class TestItemViewModel:ViewModelBase
    {
        public string Naam { get; set; }

        public TestItemViewModel(string naam)
        {
            Naam = naam;
        }
    }
}
