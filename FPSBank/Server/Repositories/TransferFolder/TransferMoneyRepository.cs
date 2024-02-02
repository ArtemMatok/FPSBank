using FPSBank.Server.Data;
using FPSBank.Server.Repositories.BankAccountFol;
using FPSBank.Shared.Models.Account;

namespace FPSBank.Server.Repositories.TransferFolder
{
    public class TransferMoneyRepository : ITransferMoneyRepository
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ApplicationDbContext _context;
        public TransferMoneyRepository(IBankAccountRepository bankAccountRepository, ApplicationDbContext context)
        {
            _bankAccountRepository = bankAccountRepository;
            _context = context;
        }


        public async Task<TransferMoney> GetTransferMoneById(int accountId, int transferMoneyId)
        {
            var account = await _bankAccountRepository.GetById(accountId);
            return account.TransfersMoney.Find(x => x.Id == transferMoneyId);
        }
    }
}
