using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using ParkInspect.Enumeration;
using ParkInspect.Repositories;
using ParkInspect.ViewModel;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repository.Interface;
using ParkInspect.Helper;

namespace ParkInspect.Service
{
    class AuthService : IAuthService
    {
        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public string UserName { get; set; }
        private IAuthenticationRepository _repo;
        private IEmployeeRepository _employeeRepository;
        public  AuthenticationViewModel User { get; set; }
        private IRouterService _router;

        public AuthService(IAuthenticationRepository repo, IRouterService router, IEmployeeRepository employeeRepository)
        {
            _repo = repo;
            _router = router;
            _employeeRepository = employeeRepository;
            LogInCommand = new RelayCommand<PasswordBox>(Login);
            LogOutCommand = new RelayCommand(Logout);
        }

        public void Login(PasswordBox password)
        {
            User = _repo.Login(UserName, password.Password);
            var dialog = new MetroDialogService();
            if (User != null)
            {
                var dashboardName = "";

                switch (User.Function.ToLower())
                {
                    case "inspecteur":
                        dashboardName = "dashboard-inspecteur";
                        break;
                    case "manager":
                        dashboardName = "dashboard-manager";
                        break;
                    default:
                        dialog.ShowMessage("Probleem opgetreden",
                            "Uw functie heeft geen werkomgeving! Neem contact op met de systeembeheerder.");
                        break;
                }

                if (dashboardName != string.Empty)
                {
                    _router.SetView(dashboardName);
                    _router.CurrentDashboard = dashboardName;
                }

                _router.ClearPreviousStack();
                return;
            }
            dialog.ShowMessage("Foute inloggegevens",
                "De inloggegevens zijn verkeerd ingevoerd.");
        }

        public void Logout()
        {
            _router.SetView("authentication");
            _router.ClearPreviousStack();
            _repo.Logout(User);
            
        }

        public bool IsLoggedIn(AuthenticationViewModel _user)
        {
            if (_user == null)
                return false;
            return _repo.IsLoggedIn(_user);
        }


        public string CurrentFunction(AuthenticationViewModel _user)
        {
            if (_user == null)
                return "";
           return _user.Function;
        }

        public EmployeeViewModel CurrentEmployee(AuthenticationViewModel _user)
        {
            if (_user == null)
                return null;
            var employee = _employeeRepository.GetAll().Where(q => q.Id == _user.EmployeeId).FirstOrDefault();
            return employee;
        }

        public AuthenticationViewModel getLoggedInUser()
        {
            if (!IsLoggedIn(User)) return null;
            return User;
        }
    }
}
