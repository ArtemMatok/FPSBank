using FPSBank.Shared.Models.Account;
using FPSBank.Shared.Models.Cards;
using FPSBank.Shared.Models.Cards.Interface;

namespace FPSBank.Server.Repositories.CardRepositoryFol
{
    public interface ICardRepository
    {
        Task<MainCard> GetMainCardByNumber(string cardNumber); 

        
    }
}
