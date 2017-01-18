namespace ParkInspect.ViewModel
{
    public class CustomerViewModel : PersonViewModel
    {
        private int _id;
        private string _function;

        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(); }
        }

        public string Function
        {
            get { return _function; }
            set
            {
                _function = value;
                if (string.IsNullOrWhiteSpace(_function))
                { AddError("Function", "Functie is verplicht"); }
                else
                { RemoveError("Function"); }
                RaisePropertyChanged();
            }
        }
    }
}
