using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Service;

namespace ParkInspect.View
{
    /// <summary>
    /// Interaction logic for ReportOverview.xaml
    /// </summary>
    public partial class ReportOverview : UserControl
    {
        public ReportOverview()
        {
            InitializeComponent();
            System.Diagnostics.Process.Start("http://parkinspect-j.azurewebsites.net/");
        }
    }
}
