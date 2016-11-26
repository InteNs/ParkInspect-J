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
    class AuthService : IAuthService
    {
        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
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
