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

        private void Dismissal_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var dataContext = DataContext as EmployeesViewModel;
            if (dataContext.SelectedEmployee != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
            
        }

        private void Dismissal_Executed(object sender, ExecutedRoutedEventArgs e)
        {
             var dataContext = DataContext as EmployeesViewModel;
             dataContext.DismissEmployee();
        }

    }
}
