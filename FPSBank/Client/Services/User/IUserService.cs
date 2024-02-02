using FPSBank.Shared.Models.User;

namespace FPSBank.Client.Services.User
{
    public interface IUserService
    {
        Task<bool> Login(LoginRequest loginRequest);
        Task Register(RegisterRequest registerRequest);
    }
}
