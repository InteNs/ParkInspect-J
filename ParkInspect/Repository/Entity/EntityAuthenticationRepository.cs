﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Data;
using ParkInspect.Helper;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Entity
{
    public class EntityAuthenticationRepository : IAuthenticationRepository
    {
        public AuthenticationViewModel Login(string username="", string password="")
        {
            AuthenticationViewModel loggedInUser;
            using (var ctx = new ParkInspectEntities())
            {
                Employee user =
                    ctx.Employee.FirstOrDefault(q => q.Person.Email == username && q.Password == password);

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

        public AuthenticationViewModel Logout(AuthenticationViewModel user)
        {
            user.EmployeeId = 0;
            user.Function = "";
            user.Username = "";
            return user;
        }

        public bool IsLoggedIn(AuthenticationViewModel user)
        {
            return (user.Username != "" && user.EmployeeId != 0);
        }
    }
}
