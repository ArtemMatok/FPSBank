using FPSBank.Shared.Models.Cards.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSBank.Shared.Models.Account
{
    public class AccountOperation
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NameOperation { get; set; }
        public string StatusOperation { get; set; }
        public string CardNumber { get; set; }
       
        public decimal Sum { get; set; }
    }
}
