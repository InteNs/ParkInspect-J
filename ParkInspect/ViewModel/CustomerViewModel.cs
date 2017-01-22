namespace ParkInspect.ViewModel
{
    public class CustomerViewModel : PersonViewModel
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(); }
        }
    }
}
