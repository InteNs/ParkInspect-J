using System;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using ParkInspect.Enumeration;
using ParkInspect.ViewModel;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repository.Interface;

namespace ParkInspect.Service
{
    class AuthService : IAuthService
    {
        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public string UserName { get; set; }
        private IAuthenticationRepository _repo;
        public  AuthenticationViewModel User { get; set; }
        private IRouterService _router;

        public AuthService(IAuthenticationRepository repo, IRouterService router)
        {
            _repo = repo;
            _router = router;
            User = new AuthenticationViewModel();
            LogInCommand = new RelayCommand<PasswordBox>(Login);
            repo.FillUserFile();
        }

        public void Login(PasswordBox password)
        {
            string[] user = _repo.Login(UserName, password.Password);
            if (user != null)
            {
                User.UserId = Convert.ToInt32(user[2]);
                User.EmployeeId = Convert.ToInt32(user[3]);
                User.Username = user[0];
                _router.SetView("dashboard-manager");

                return;
            }
            MessageBox.Show("Foute inloggegevens!");
        }

        public void Logout()
        {
            _repo.Logout(User);
        }


        public Function CurrentFunction()
        {
            throw new NotImplementedException();
        }

        public EmployeeViewModel CurrentEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
