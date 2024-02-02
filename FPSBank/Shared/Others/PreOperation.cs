using FPSBank.Shared.Models.Cards.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSBank.Shared.Others
{
    public  class PreOperation
    {
        //ICard card,decimal sum,string nameOperation
        public PreOperation(string cardNumber, decimal cardSum, decimal sum, string nameOperation)
        {
            CardNumber = cardNumber;
            CardSum = cardSum;
            Sum = sum;
            NameOperation = nameOperation;  
        }

       
        public string CardNumber { get; set; }
        public decimal CardSum { get; set; }
        public decimal Sum { get; set; }
        public string NameOperation { get; set; }
    }
}
