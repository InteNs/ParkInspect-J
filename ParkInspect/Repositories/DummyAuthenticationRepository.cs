using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public class DummyAuthenticationRepository : IAuthenticationRepository
    {
        private string loginFile;

        public DummyAuthenticationRepository()
        {
            loginFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Login.data");

        }

        public void FillUserFile()
        {
            if (!File.Exists(loginFile))
                File.Create(loginFile);

            using (StreamWriter file = new StreamWriter(loginFile, true))
            {
                file.WriteLine("admin;password;1;1");
                file.WriteLine("henk;kees;2;2");
                file.Close();
            }

        }

        public string[] Login(string username, string password)
        {
            string line = "";
            StreamReader file = new StreamReader(loginFile);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                if (data[0] == username && data[1] == password)
                {
                    file.Close();
                    return data; //{ EmployeeId = Convert.ToInt32(data[3]), UserId = Convert.ToInt32(data[2]), Username = data[0] };
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
