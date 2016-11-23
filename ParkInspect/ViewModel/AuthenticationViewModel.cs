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

namespace ParkInspect.ViewModel
{
    public class AuthenticationViewModel
    {
        public  string Username { get; set; }
        public  int UserId { get; set; }
        public int EmployeeId { get; set; }

        private IAuthenticationRepository _repo;
        private readonly RouterViewModel _router;
        public ICommand DoLoginCommand { get; set; }

        public AuthenticationViewModel(IAuthenticationRepository repo, RouterViewModel router)
        {
            _repo = repo;
            _router = router;
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
                _router.SetView("MainInspect");
                
                return;
            }
            MessageBox.Show("Foute inloggegevens!");


        }
    }
}
