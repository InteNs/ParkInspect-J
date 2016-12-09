﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using ParkInspect.Enumeration;
using ParkInspect.Repositories;
using ParkInspect.ViewModel;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repository.Interface;

namespace ParkInspect.Service
{
    class AuthService : IAuthService
    {
        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public string UserName { get; set; }
        private EmployeeViewModel employee;
        private IAuthenticationRepository _repo;
        private IEmployeeRepository _employeeRepository;
        public  AuthenticationViewModel User { get; set; }
        private IRouterService _router;

        public AuthService(IAuthenticationRepository repo, IRouterService router, IEmployeeRepository employeeRepository)
        {
            _repo = repo;
            _router = router;
            _employeeRepository = employeeRepository;
            User = new AuthenticationViewModel();
            LogInCommand = new RelayCommand<PasswordBox>(Login);
            LogOutCommand = new RelayCommand(Logout);
            repo.FillUserFile();
        }

        public void Login(PasswordBox password)
        {
            string[] user = _repo.Login(UserName, password.Password);
            if (user != null)
            {
                User.UserId = Convert.ToInt32(user[2]);
                User.EmployeeId = Convert.ToInt32(user[3]);
                User.Username = user[0];

                employee = _employeeRepository.GetAll().Where(e => e.Id == User.EmployeeId).FirstOrDefault();

                switch (CurrentFunction().ToLower())
                {
                    case "inspecteur":
                        _router.SetView("dashboard-inspecteur");
                        break;
                    case "manager":
                        _router.SetView("dashboard-manager");
                        break;
                    default:
                        MessageBox.Show("Uw functie heeft geen werkomgeving! Neem contact op met de systeembeheerder.","Probleem opgetreden",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        break;
                }
                _router.ClearPreviousStack();
                return;
            }
            MessageBox.Show("Foute inloggegevens!");
        }

        public void Logout()
        {
            _router.SetView("authentication");
            _router.ClearPreviousStack();
            _repo.Logout(User);
            
        }

        public bool IsLoggedIn()
        {
            return _repo.IsLoggedIn(User);
        }


        public string CurrentFunction()
        {
            return employee.Function;
        }

        public EmployeeViewModel CurrentEmployee()
        {
            return employee;
        }
    }
}
