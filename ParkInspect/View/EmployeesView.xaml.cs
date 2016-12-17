using System.Windows.Controls;
using System.Windows.Input;
using ParkInspect.ViewModel;

namespace ParkInspect.View
{
    /// <summary>
    /// Interaction logic for EmployeesWindow.xaml
    /// </summary>

    public partial class EmployeesView : UserControl
    {
        public EmployeesView()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var datacontext = ((EmployeesViewModel)DataContext);
            datacontext.RouterService.SetView("employees-edit");
        }
    }
}
