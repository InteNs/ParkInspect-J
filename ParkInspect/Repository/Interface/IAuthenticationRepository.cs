using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface IAuthenticationRepository
    {
        AuthenticationViewModel Login(string username, string password);
        AuthenticationViewModel Logout(AuthenticationViewModel user);
        bool IsLoggedIn(AuthenticationViewModel user);
    }
}
