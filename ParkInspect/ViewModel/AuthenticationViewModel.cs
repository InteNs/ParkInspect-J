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
        private IAuthenticationRepository _repo;

        public AuthenticationViewModel(IAuthenticationRepository repo)
        {
            _repo = repo;
        }
    }
}
