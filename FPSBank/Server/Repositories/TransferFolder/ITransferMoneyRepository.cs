using FPSBank.Shared.Models.Account;

namespace FPSBank.Server.Repositories.TransferFolder
{
    public interface ITransferMoneyRepository
    {
        Task<TransferMoney> GetTransferMoneById(int accountId, int transferMoneyId);
    }
}
