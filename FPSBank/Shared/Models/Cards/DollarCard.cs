using FPSBank.Shared.Models.Cards.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPSBank.Shared.Models.Cards
{
    
    public  class DollarCard:ICard
    {
        public int Id { get; set; }
        public decimal Sum { get; set; } = 0;
        public string NumberCard { get; set; } = GenerateRandomDigits();


        private static string GenerateRandomDigits()
        {
            Random random = new Random();
            const int length = 16;
            char[] digits = new char[length];

            for (int i = 0; i < length; i++)
            {
                digits[i] = (char)('0' + random.Next(10));
            }

            return new string(digits);
        }
    }
}
