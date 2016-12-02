using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ParkInspect.Service
{
    public interface IRouterService
    {
        UserControl CurrentView { get; set; }
        ICommand RouteCommand { get; set; }
        ICommand RouteBackCommand { get; set; }
        void SetView(string viewName);
        void SetPreviousView();
        void ClearPreviousStack();
    }
}
