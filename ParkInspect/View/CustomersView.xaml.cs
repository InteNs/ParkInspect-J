using System.Windows.Controls;
using System.Windows.Input;
using ParkInspect.ViewModel;

namespace ParkInspect.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var datacontext = ((CustomersViewModel)DataContext);
            datacontext.RouterService.SetView("customers-edit");
        }
    }
}
