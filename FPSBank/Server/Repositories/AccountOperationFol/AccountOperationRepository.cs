using FPSBank.Server.Data;
using FPSBank.Server.Repositories.BankAccountFol;
using FPSBank.Shared.Models.Account;

namespace FPSBank.Server.Repositories.AccountOperationFol
{
    public class AccountOperationRepository : IAccountOperationRepository
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ApplicationDbContext _context;

        public AccountOperationRepository(IBankAccountRepository bankAccountRepository, ApplicationDbContext context)
        {
            _bankAccountRepository = bankAccountRepository;
            _context = context;
        }

        public async Task<AccountOperation> GetOperationById(int accountId, int operationId)
        {
            var account = await _bankAccountRepository.GetById(accountId);
            return account.AccountOperations.Find(x => x.Id == operationId);
        }

        
    }
}
