using System.Windows.Controls;
using System.Windows.Input;
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
        bool IsLoggedIn(AuthenticationViewModel user);
        string CurrentFunction(AuthenticationViewModel user);
        EmployeeViewModel CurrentEmployee(AuthenticationViewModel user);
        AuthenticationViewModel GetLoggedInUser();

    }
}
