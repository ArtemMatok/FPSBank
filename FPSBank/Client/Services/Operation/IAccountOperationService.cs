using FPSBank.Shared.Models.Account;

namespace FPSBank.Client.Services.Operation
{
    public interface IAccountOperationService
    {
        Task<AccountOperation> GetOperationById(int accountId,int operationId);
    }
}
