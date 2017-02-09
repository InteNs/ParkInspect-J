using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using ParkInspect.ViewModel;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repository.Interface;
using ParkInspect.Helper;

namespace ParkInspect.Service
{
    public class AuthService : IAuthService
    {
        private IAuthenticationRepository _repo;
        private IEmployeeRepository _employeeRepository;
        private IRouterService _router;

        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public string UserName { get; set; }
        public  AuthenticationViewModel User { get; set; }

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
            ViewModelLocator.Cleanup();
        }

        public bool IsLoggedIn(AuthenticationViewModel user) =>  user != null && _repo.IsLoggedIn(user);

        public string CurrentFunction(AuthenticationViewModel user) =>  user == null ? "" : user.Function;

        public EmployeeViewModel CurrentEmployee(AuthenticationViewModel user)
        {
            if (user == null)
                return null;
            var employee = _employeeRepository.GetAll().FirstOrDefault(q => q.Id == user.EmployeeId);
            return employee;
        }

        public AuthenticationViewModel GetLoggedInUser() => !IsLoggedIn(User) ? null : User;
    }
}
