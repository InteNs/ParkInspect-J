using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
    public class AuthenticationViewModel
    {
        public  string Username { get; set; }
        public  int UserId { get; set; }
        public int EmployeeId { get; set; }

        private IAuthenticationRepository _repo;

        public AuthenticationViewModel(IAuthenticationRepository repo)
        {
            _repo = repo;
        }

        public AuthenticationViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
