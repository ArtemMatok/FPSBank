using FPSBank.Server.Authentication;
using FPSBank.Shared.Models.User;

namespace FPSBank.Server.Repositories.Account
{
    public interface IUserAccountRepository
    {
        public Task<UserAccount> GetUserAccountByUserName(string userName);  

        Task<UserAccount> Register(RegisterRequest registerRequest);

    }
}
