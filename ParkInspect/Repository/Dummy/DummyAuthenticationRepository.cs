using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Dummy
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
                File.Create(loginFile).Close();
            
            using (StreamWriter file = new StreamWriter(loginFile, true))
            {
                file.WriteLine("admin;"+HashString("password")+";1;1;manager");
                file.WriteLine("henk;" + HashString("kees") + ";2;2;inspecteur");
                file.WriteLine("Dikke;" + HashString("teur") + ";3;3;directeur");
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
                if (data[0] == username && data[1] == HashString(password))
                {
                    file.Close();
                    return data;
                }
            }

            file.Close();

            return null;
        }

        public void Logout(AuthenticationViewModel user)
        {
            user.UserId = 0;
            user.EmployeeId = 0;
            user.Username = "";
        }

        public bool IsLoggedIn(AuthenticationViewModel user)
        {
            return (user.Username != "" && user.UserId != 0);
        }

        private string HashString(string content)
        {

            HashAlgorithm algorithm = SHA256.Create();
            
            StringBuilder sb = new StringBuilder();
            foreach (byte b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(content)))
                sb.Append(b.ToString("X2"));

            return sb.ToString();

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
