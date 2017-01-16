using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Dummy
{
    public class DummyAuthenticationRepository : IAuthenticationRepository
    {
        public AuthenticationViewModel Login(string username="", string password="")
        {
            AuthenticationViewModel loggedInUser;

            using (var ctx = new ParkInspectEntities())
            {
                Employee user =
                    ctx.Employee.Where(q => q.Person.Email == username && q.Password == password).FirstOrDefault();

                if (user == null)
                    return null;

                loggedInUser = new AuthenticationViewModel()
                {
                    Username = user.Person.Email,
                    EmployeeId = user.Id,
                    Function = user.Function.Name
                };
            }

            return loggedInUser;

        }

        public void Logout(AuthenticationViewModel user)
        {
            user = null;
        }

        public bool IsLoggedIn(AuthenticationViewModel user)
        {
            return (user.Username != "" && user.EmployeeId != 0);
        }

        private bool HasInternet()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
