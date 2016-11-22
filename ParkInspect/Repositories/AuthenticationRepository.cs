using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;
using System.IO;
using System.IO.Packaging;
using System.Net;

namespace ParkInspect.Repositories
{
    class AuthenticationRepository:IAuthenticationRepository
    {
        private string loginFile;

        public AuthenticationRepository()
        {
            loginFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),@"ParkInspect\Login.data");
            
        }

        public void FillUserFile()
        {
            if (!File.Exists(loginFile))
                File.Create(loginFile);

            StreamWriter file = new System.IO.StreamWriter(loginFile);
            file.WriteLine("admin;password;1;1");
            file.WriteLine("henk;kees;2;2");
            file.Close();

        }

        public AuthenticationViewModel Login(string username, string password)
        {
            string line = "";
            StreamReader file = new StreamReader(loginFile);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                if(data[0] == username && data[1] == password)
                {
                    file.Close();
                    return new AuthenticationViewModel() {EmployeeId=Convert.ToInt32(data[3]),UserId = Convert.ToInt32(data[2]), Username = data[0]};
                }
            }

            file.Close();

            return null;
        }

        public AuthenticationViewModel Logout(AuthenticationViewModel user)
        {
            user = null;
            return user;
        }

        public bool IsLoggedIn(AuthenticationViewModel user)
        {
            return (user != null);
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
