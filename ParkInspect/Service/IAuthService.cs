using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParkInspect.Enumeration;
using ParkInspect.ViewModel;

namespace ParkInspect.Service
{
    public interface IAuthService
    {
        ICommand LogInCommand { get; set; }
        ICommand LogOutCommand { get; set; }

        bool Login(string username, string password);
        void Logout();
        Function CurrentFunction();
        EmployeeViewModel CurrentEmployee();

    }
}
