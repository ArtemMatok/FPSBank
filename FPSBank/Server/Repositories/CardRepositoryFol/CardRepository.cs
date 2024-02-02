using FPSBank.Server.Data;
using FPSBank.Server.Repositories.BankAccountFol;
using FPSBank.Shared.Models.Cards;
using FPSBank.Shared.Models.Cards.Interface;
using Microsoft.EntityFrameworkCore;

namespace FPSBank.Server.Repositories.CardRepositoryFol
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context, IBankAccountRepository bankAccountRepository)
        {
            _context = context;
          
        }

        public async Task<MainCard> GetMainCardByNumber(string cardNumber)
        {
            var mainCard =  await _context.BankAccounts.Where(x => x.MainCard.NumberCard == cardNumber).Select(x=>x.MainCard).FirstOrDefaultAsync();
            return mainCard;
            
        }
    }
}
