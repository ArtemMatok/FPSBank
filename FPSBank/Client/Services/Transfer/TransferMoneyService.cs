using FPSBank.Shared.Models.Account;
using System.Net.Http.Json;

namespace FPSBank.Client.Services.Transfer
{
    public class TransferMoneyService : ITransferMoneyService
    {
        private readonly HttpClient _httpClient;

        public TransferMoneyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TransferMoney> GetTransferMoneyById(int accountId, int transferMoneyId)
        {
            return await _httpClient.GetFromJsonAsync<TransferMoney>($"api/TransferMoney/GetTransferMoney/{accountId}/{transferMoneyId}");
        }
    }
}
