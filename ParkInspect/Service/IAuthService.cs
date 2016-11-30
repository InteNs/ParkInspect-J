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

        void Login(PasswordBox password);
        void Logout();
        Function CurrentFunction();
        EmployeeViewModel CurrentEmployee();

    }
}
