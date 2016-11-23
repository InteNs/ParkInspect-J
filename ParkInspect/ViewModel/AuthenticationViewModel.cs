using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
    public class AuthenticationViewModel
    {
        public  string Username { get; set; }
        public  int UserId { get; set; }
        public int EmployeeId { get; set; }

        private IAuthenticationRepository _repo;

        public ICommand DoLoginCommand;

        public AuthenticationViewModel(IAuthenticationRepository repo)
        {
            _repo = repo;
            DoLoginCommand = new RelayCommand<string>(DoLogin);
        }

        private void DoLogin(string password)
        {
            string[] user = _repo.Login(Username, password);
            if (user != null)
            {
                UserId = Convert.ToInt32(user[2]);
                EmployeeId = Convert.ToInt32(user[3]);
                Username = user[0];
                MessageBox.Show("Ingelogd!");
                return;
            }
            MessageBox.Show("Foute inloggegevens!");


        }
    }
}
