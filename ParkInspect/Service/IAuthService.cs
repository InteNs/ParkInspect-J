using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ParkInspect.Enumeration;
using ParkInspect.ViewModel;

namespace ParkInspect.Service
{
    public interface IAuthService
    {
        ICommand LogInCommand { get; set; }
        ICommand LogOutCommand { get; set; }
        string UserName { get; set; }
        void Login(PasswordBox password);
        void Logout();
        bool IsLoggedIn(AuthenticationViewModel _user);
        string CurrentFunction(AuthenticationViewModel _user);
        EmployeeViewModel CurrentEmployee(AuthenticationViewModel _user);
        AuthenticationViewModel getLoggedInUser();

    }
}
