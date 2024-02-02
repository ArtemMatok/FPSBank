using FPSBank.Server.Repositories.TransferFolder;
using FPSBank.Shared.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace FPSBank.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferMoneyController : ControllerBase
    {
        private ITransferMoneyRepository _transferMoneyRepository;

        public TransferMoneyController(ITransferMoneyRepository transferMoneyRepository)
        {
            _transferMoneyRepository = transferMoneyRepository;
        }

        [HttpGet("GetTransferMoney/{accountId}/{transferMoneyId}")]
        public async Task<TransferMoney> GetTransferMoneyById(int accountId, int transferMoneyId)
        {
            return await _transferMoneyRepository.GetTransferMoneById(accountId, transferMoneyId);
        }
    }
}
