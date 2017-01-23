using System.Windows;

namespace ParkInspect.View
{
    /// <summary>
    /// Interaction logic for DashboardManagerView.xaml
    /// </summary>
    public partial class DashboardManagerView
    {
        public DashboardManagerView()
        {
            InitializeComponent();
        }

        private void OpenWebView(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://parkinspect-j.azurewebsites.net/");
        }
    }
}
