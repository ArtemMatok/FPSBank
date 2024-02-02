using FPSBank.Server.Repositories.AccountOperationFol;
using FPSBank.Shared.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPSBank.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IAccountOperationRepository _accountOperationRepository;

        public OperationController(IAccountOperationRepository accountOperationRepository)
        {
            _accountOperationRepository = accountOperationRepository;
        }

        [HttpGet("GetAccountOperationById/{accountId}/{operationId}")]
        public async Task<AccountOperation> GetAccountOperationById(int accountId, int operationId)
        {
            return await _accountOperationRepository.GetOperationById(accountId, operationId);  
        }
    }
}
