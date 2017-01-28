using System;

namespace ParkInspect.ViewModel
{
    public class AuthenticationViewModel : MainViewModel
    {
        public  string Username { get; set; }
        public  string Function { get; set; }
        public int EmployeeId { get; set; }
        public Guid EmployeeGuid { get; set; }
    }
}
