using FPSBank.Shared.Models.Account;
using FPSBank.Shared.Models.Cards.Interface;
using FPSBank.Shared.Others;

namespace FPSBank.Client.Services.Account
{
    public interface IBankAccountService
    {
        Task CreateAccount(BankAccount model);
        Task UpdateBalance(int id,BankAccount model);
        Task UpdateCredit(int id,BankAccount model);
        Task UpdateRepayCredit(int id, BankAccount model);
        Task ExchangeMoney(int id, PreExchangeMoney preExchangeMoney);
        Task<BankAccount> GetAccountById(int id);
        Task<BankAccount> GetAccountByEmail(string email);
        Task UpdateOparation(int id, PreOperation preOperation);
        Task<AccountOperation> AddOparation(int id, PreOperation preOperation);
        Task<string> Transaction(int accountId, PreTransaction preTransaction);
       

    }
}
