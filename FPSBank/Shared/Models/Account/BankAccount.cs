using FPSBank.Shared.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSBank.Shared.Models.Account
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public MainCard MainCard { get; set; } = new MainCard();
        public DollarCard DollarCard { get; set; } = new DollarCard();
        public CreditCard CreditCard { get; set; } = new CreditCard();
        public List<AccountOperation>? AccountOperations { get; set; } = new List<AccountOperation>();
        public List<TransferMoney> TransfersMoney { get; set; } = new List<TransferMoney>();
    }
}
