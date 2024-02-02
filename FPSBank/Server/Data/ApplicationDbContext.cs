using FPSBank.Server.Authentication;
using FPSBank.Shared.Models.Account;
using FPSBank.Shared.Models.Cards;
using Microsoft.EntityFrameworkCore;

namespace FPSBank.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
       

       
    }
}
