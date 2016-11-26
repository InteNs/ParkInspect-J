using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repositories;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class AuthenticationViewModel : MainViewModel
    {
        public  string Username { get; set; }
        public  int UserId { get; set; }
        public int EmployeeId { get; set; }

        private IAuthenticationRepository _repo;
        public ICommand DoLoginCommand { get; set; }

        public AuthenticationViewModel(IAuthenticationRepository repo, IRouterService router) : base(router)
        {
            _repo = repo;
            DoLoginCommand = new RelayCommand<PasswordBox>(DoLogin);
            repo.FillUserFile();
        }

        private void DoLogin(PasswordBox password)
        {
            string[] user = _repo.Login(Username, password.Password);
            if (user != null)
            {
                UserId = Convert.ToInt32(user[2]);
                EmployeeId = Convert.ToInt32(user[3]);
                Username = user[0];
                RouterService.SetView("dashboard-manager");
                
                return;
            }
            MessageBox.Show("Foute inloggegevens!");


        }
    }
}
