using FPSBank.Server.Data;
using FPSBank.Shared.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace FPSBank.Server.Repositories.BankAccountFol
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public BankAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(BankAccount model)
        {
            _context.BankAccounts.Add(model);
            return Save();
        }

        public async Task<BankAccount> GetAccountByMainCardNumber(string cardNumber)
        {
            return await _context.BankAccounts.Where(x => x.MainCard.NumberCard == cardNumber).Include(x=>x.TransfersMoney).Include(x=>x.MainCard).Include(x => x.DollarCard).Include(x => x.CreditCard).FirstOrDefaultAsync();
        }

        public async Task<BankAccount> GetByEmail(string email)
        {
            return await _context.BankAccounts.Include(x => x.MainCard).Include(x => x.TransfersMoney).Include(x => x.AccountOperations).Include(x => x.DollarCard).Include(x => x.CreditCard).FirstOrDefaultAsync(x => x.Email == email);

        }

        public async Task<BankAccount> GetById(int id)
        {
            return await _context.BankAccounts.Include(x => x.DollarCard).Include(x=>x.TransfersMoney).Include(x=>x.MainCard).Include(x => x.AccountOperations).Include(x => x.CreditCard).FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(BankAccount model)
        {
            _context.BankAccounts.Update(model);
            _context.SaveChanges();
            return true;
        }
    }
}
