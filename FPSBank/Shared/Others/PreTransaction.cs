
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSBank.Shared.Others
{
    public class PreTransaction
    {
        [Required]
        public decimal Sum { get; set; }
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Введіть тільки цифри")]
        public string CardNumber { get; set; }
    }
}
