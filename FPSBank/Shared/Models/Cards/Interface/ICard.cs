using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSBank.Shared.Models.Cards.Interface
{
    public interface ICard
    {
        public decimal Sum { get; set; }
        public string NumberCard { get; set; }
    }
}
