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
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class AuthenticationViewModel : MainViewModel
    {
        public  string Username { get; set; }
        public  int UserId { get; set; }
        public int EmployeeId { get; set; }
    }
}
