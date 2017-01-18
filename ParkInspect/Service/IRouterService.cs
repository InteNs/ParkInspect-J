using System.Windows.Controls;
using System.Windows.Input;

namespace ParkInspect.Service
{
    public interface IRouterService
    {
        bool IsLoggedIn { get; set; }
        string CurrentDashboard { get; set; }
        UserControl CurrentView { get; set; }
        ICommand RouteCommand { get; set; }
        ICommand RouteBackCommand { get; set; }
        void SetView(string viewName);
        void SetPreviousView();
        void ClearPreviousStack();
    }
}
