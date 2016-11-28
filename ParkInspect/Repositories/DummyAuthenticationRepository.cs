﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;
using System.Security.Cryptography;

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
                File.Create(loginFile).Close();
            
            using (StreamWriter file = new StreamWriter(loginFile, true))
            {
                file.WriteLine("admin;"+HashString("password")+";1;1");
                file.WriteLine("henk;" + HashString("kees") + ";2;2");
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
