using System.Windows.Controls;
using System.Windows.Input;
using ParkInspect.ViewModel;

namespace ParkInspect.View
{
    /// <summary>
    /// Interaction logic for TimeLineView.xaml
    /// </summary>
    public partial class TimeLineView
    {
        public TimeLineView()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Waarom code-behind?

            var grid = sender as DataGrid;

            var timelineItem = (TimeLineItemViewModel) grid.SelectedValue;
            ((TimeLineViewModel) DataContext).SelectedTimeLineItem = timelineItem;
            new EmployeeInspectionsWindow().Show();
        }
    }
}
