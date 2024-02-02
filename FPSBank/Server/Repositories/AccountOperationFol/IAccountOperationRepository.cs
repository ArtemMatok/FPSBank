using FPSBank.Shared.Models.Account;

namespace FPSBank.Server.Repositories.AccountOperationFol
{
    public interface IAccountOperationRepository
    {
        Task<AccountOperation> GetOperationById(int id, int operationId);
    }
}
