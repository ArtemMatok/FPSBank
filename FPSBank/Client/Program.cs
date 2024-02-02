using Blazored.SessionStorage;
using FPSBank.Client;
using FPSBank.Client.Authentication;
using FPSBank.Client.Services.Account;
using FPSBank.Client.Services.Operation;
using FPSBank.Client.Services.Transfer;

using FPSBank.Client.Services.User;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<IAccountOperationService, AccountOperationService>();
builder.Services.AddScoped<ITransferMoneyService, TransferMoneyService>();  

builder.Services.AddBlazorBootstrap();
await builder.Build().RunAsync();
