using FPSBank.Shared.Models.Account;

namespace FPSBank.Server.Repositories.BankAccountFol
{
    public interface IBankAccountRepository
    {
        bool Create(BankAccount model);
        bool Update(BankAccount model);
        bool Save();
        Task<BankAccount> GetById(int id);
        Task<BankAccount> GetByEmail(string email);
        Task<BankAccount> GetAccountByMainCardNumber(string cardNumber);
    }
}
