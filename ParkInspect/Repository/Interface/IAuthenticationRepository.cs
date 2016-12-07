using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface IAuthenticationRepository
    {
        void FillUserFile();
        string[] Login(string username, string password);
        void Logout(AuthenticationViewModel user);
        bool IsLoggedIn(AuthenticationViewModel user);
    }
}
