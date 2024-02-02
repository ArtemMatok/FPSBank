using FPSBank.Shared.Models.Account;

namespace FPSBank.Client.Services.Transfer
{
    public interface ITransferMoneyService
    {
        Task<TransferMoney> GetTransferMoneyById(int accountId, int transferMoneyId);
    }
}
