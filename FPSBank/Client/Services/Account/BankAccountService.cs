using FPSBank.Shared.Models.Account;
using FPSBank.Shared.Models.Cards.Interface;
using FPSBank.Shared.Others;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Runtime.InteropServices;

namespace FPSBank.Client.Services.Account
{
    public class BankAccountService : IBankAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navManager;

        public BankAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AccountOperation> AddOparation(int id, PreOperation preOperation)
        {
            var operation = await _httpClient.PutAsJsonAsync($"api/BankAccount/UpdateOparation/{id}", preOperation);
            var res = await operation.Content.ReadFromJsonAsync<AccountOperation>();
            return res;
        }

        public async Task CreateAccount(BankAccount model)
        {
            await _httpClient.PostAsJsonAsync("/api/BankAccount/Create", model);
            
        }

        public async Task ExchangeMoney(int id, PreExchangeMoney preExchangeMoney)
        {
            await _httpClient.PutAsJsonAsync($"api/BankAccount/ExchangeMoney/{id}", preExchangeMoney);
        }

        public async Task<BankAccount> GetAccountByEmail(string email)
        {
            return await _httpClient.GetFromJsonAsync<BankAccount>($"api/BankAccount/GetAccountByEmail/{email}");
        }

        public async Task<BankAccount> GetAccountById(int id)
        {
            return await _httpClient.GetFromJsonAsync<BankAccount>($"api/BankAccount/GetAccountById/{id}");

        }

        public async Task<string> Transaction(int accountId, PreTransaction preTransaction)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/BankAccount/TransactionMainCard/{accountId}", preTransaction);
            if(result.StatusCode== System.Net.HttpStatusCode.OK)
            {
                
                return "Success";
            }
            else if(result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return "Card is not correct";
            }
            else
            {
                return "You have not enough money for operation";
            }
        }

        public async Task UpdateBalance(int id,BankAccount model)
        {
            await _httpClient.PutAsJsonAsync($"api/BankAccount/UpdateBalance/{id}", model);
        }

        public async Task UpdateCredit(int id, BankAccount model)
        {
            await _httpClient.PutAsJsonAsync($"api/BankAccount/UpdateCredit/{id}", model);
        }

        public async Task UpdateOparation(int id, PreOperation preOperation)
        {
             await _httpClient.PutAsJsonAsync($"api/BankAccount/UpdateOparation/{id}",preOperation);
        }

        public async Task UpdateRepayCredit(int id, BankAccount model)
        {
            await _httpClient.PutAsJsonAsync($"api/BankAccount/UpdateRepayCredit/{id}", model);
        }
    }
}
