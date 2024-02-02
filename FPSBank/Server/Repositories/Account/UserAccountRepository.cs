using FPSBank.Server.Authentication;
using FPSBank.Server.Data;
using FPSBank.Shared.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FPSBank.Server.Repositories.Account
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public UserAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserAccount> GetUserAccountByUserName(string userName)
        {
            return await _context.UserAccounts.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        

        public async Task<UserAccount> Register(RegisterRequest registerRequest)
        {
            var userAccount = new UserAccount();
            userAccount.FullName = registerRequest.FullName;
            userAccount.UserName = registerRequest.Email;
            userAccount.Password = registerRequest.Password;
            userAccount.Role = "User";
            _context.UserAccounts.Add(userAccount);
            await _context.SaveChangesAsync();  
            return userAccount;
        }
    }
}
