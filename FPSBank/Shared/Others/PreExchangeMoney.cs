using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSBank.Shared.Others
{
    public class PreExchangeMoney
    {
        public PreExchangeMoney(decimal grnSum, decimal dollarSum)
        {
            this.grnSum = grnSum;
            this.dollarSum = dollarSum;
        }

        public decimal grnSum { get; set; }
        public decimal dollarSum { get; set; }
    }
}
