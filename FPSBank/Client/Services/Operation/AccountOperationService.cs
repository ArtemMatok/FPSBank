using FPSBank.Shared.Models.Account;
using System.Net.Http.Json;

namespace FPSBank.Client.Services.Operation
{
    public class AccountOperationService : IAccountOperationService
    {
        private readonly HttpClient _httpClient;

        public AccountOperationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AccountOperation> GetOperationById(int accountId, int operationId)
        {
            return await _httpClient.GetFromJsonAsync<AccountOperation>($"api/Operation/GetAccountOperationById/{accountId}/{operationId}");
        }
    }
}
