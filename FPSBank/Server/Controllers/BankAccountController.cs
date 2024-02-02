using FPSBank.Server.Repositories.BankAccountFol;
using FPSBank.Server.Repositories.CardRepositoryFol;
using FPSBank.Shared.Models.Account;
using FPSBank.Shared.Models.Cards.Interface;
using FPSBank.Shared.Others;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace FPSBank.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ICardRepository _cardRepository;
        public BankAccountController(IBankAccountRepository bankAccountRepository, ICardRepository cardRepository)
        {
            _bankAccountRepository = bankAccountRepository;
            _cardRepository = cardRepository;
        }

        [HttpPost("Create")]
        public ActionResult<BankAccount> Create([FromBody] BankAccount bankAccount)
        {
            if(bankAccount == null)
            {
                return BadRequest("Model is null");
            }
            var account =  _bankAccountRepository.Create(bankAccount);
            return Ok(account);
        }

        [HttpPut("UpdateBalance/{id}")]
        public async Task<ActionResult<BankAccount>> UpdateBalance(int id, [FromBody]BankAccount bankAccount)
        {
            if(bankAccount == null) { return BadRequest("Model is null"); }
            var account = await _bankAccountRepository.GetById(id);
            if(account == null) { return BadRequest("Account is null"); }
       
            account.MainCard.Sum = bankAccount.MainCard.Sum;
            _bankAccountRepository.Update(account);
            return Ok(account); 
        }

        [HttpPut("UpdateCredit/{id}")]
        public async Task<ActionResult<BankAccount>> UpdateCredit(int id, BankAccount bankAccount)
        {
            var account = await _bankAccountRepository.GetById(id);
            if(account == null) { return BadRequest(); }
            account.CreditCard.Sum = bankAccount.CreditCard.Sum;
            account.MainCard.Sum = bankAccount.MainCard.Sum;
            _bankAccountRepository.Update(account);
            return Ok(account);
        }



        [HttpGet("GetAccountById/{id}")]
        public async Task<BankAccount> GetAccountById(int id)
        {
            return await _bankAccountRepository.GetById(id);
        }

        [HttpGet("GetAccountByEmail/{email}")]
        public async Task<BankAccount> GetAccountByEmail(string email)
        {
            return await _bankAccountRepository.GetByEmail(email);  
        }


        [HttpPut("UpdateOparation/{id}")]
        public async Task<ActionResult<AccountOperation>> UpdateOpration(int id,PreOperation preOperation)
        {
            var account = await GetAccountById(id);
            if(account == null) { return BadRequest("Account is null"); }
            var operation = new AccountOperation();
            operation.Sum = preOperation.Sum;
            operation.CardNumber = preOperation.CardNumber;
            operation.NameOperation = preOperation.NameOperation;
            operation.FullName = account.FullName;
            if(operation.NameOperation == "Add to Balance")
            {
                operation.StatusOperation = "Done";
            }
            else if(operation.NameOperation == "Transaction")
            {
                if (operation.Sum > preOperation.CardSum)
                {
                    operation.StatusOperation = "Cancel";
                }
                else
                {
                    operation.StatusOperation = "Done";
                }
            }
            
            

            account.AccountOperations.Add(operation);
            _bankAccountRepository.Update(account);
            return Ok(operation);
        }




        [HttpPut("TransactionMainCard/{accountId}")]
        public async Task<IActionResult> TransactionMainCard(int accountId,PreTransaction preTransaction)
        {
            var accountSender = await _bankAccountRepository.GetById(accountId);
            if(accountSender == null)
            {
                return BadRequest("AccountSender is null");
            }
            #region Sender
            if (accountSender.MainCard.Sum>=preTransaction.Sum)
            {
                #region Operation
                var accountOperation = new AccountOperation();
                accountOperation.CardNumber = accountSender.MainCard.NumberCard;
                accountOperation.Sum = preTransaction.Sum;
                accountOperation.StatusOperation = "Success";
                accountOperation.NameOperation = "Transfer money";
                accountOperation.FullName = accountSender.FullName;
                accountSender.AccountOperations.Add(accountOperation);
                #endregion
               

                var accountReceiver = await _bankAccountRepository.GetAccountByMainCardNumber(preTransaction.CardNumber);
                if(accountReceiver is null)
                {
                    return BadRequest();
                }
                accountReceiver.MainCard.Sum += preTransaction.Sum;


                #region Transfer
                var transferMoney = new TransferMoney();
                transferMoney.NameOperation = "Transfer Money";
                transferMoney.Sum = preTransaction.Sum;
                transferMoney.CardNumber = accountSender.MainCard.NumberCard;
                transferMoney.FullName = accountSender.FullName;
                transferMoney.StatusOperation = "Succeess";
                accountReceiver.TransfersMoney.Add(transferMoney);
                #endregion


                accountSender.MainCard.Sum -= preTransaction.Sum;
               
                _bankAccountRepository.Update(accountSender);
                _bankAccountRepository.Update(accountReceiver);
                #region Receiver



                #endregion

                return Ok("Success");
            }
            else
            {
                return NotFound();
            }
            #endregion

            
        }



        [HttpPut("UpdateRepayCredit/{id}")]
        public async Task<ActionResult<BankAccount>> UpdateRepayCredit(int id, BankAccount model)
        {
            var account = await _bankAccountRepository.GetById(id);
            if(account is null) { return BadRequest(); }
            account.MainCard.Sum = model.MainCard.Sum;
            account.CreditCard.Sum = model.CreditCard.Sum;
            _bankAccountRepository.Update(account);
            return Ok(account);
        }


        [HttpPut("ExchangeMoney/{id}")]
        public async Task<ActionResult<BankAccount>> ExchangeMoney(int id, PreExchangeMoney preExchangeMoney)
        {
            var account = await _bankAccountRepository.GetById(id);
            account.MainCard.Sum += preExchangeMoney.grnSum;
            account.DollarCard.Sum -= preExchangeMoney.dollarSum;
            _bankAccountRepository.Update(account);
            return Ok(account);
        }


    }
}
