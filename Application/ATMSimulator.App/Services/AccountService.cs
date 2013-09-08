namespace ATMSimulator.App.Services
{
    using System.Collections.Generic;
    using ATMSimulator.App.Models;
    using ATMSimulator.App.Services.Interfaces;
    using System.Linq;

    public class AccountService : IAccountService
    {
        public IList<Account> Accounts { get; set; }

        public AccountService()
        {
            Accounts = new List<Account>
                           {
                               new Account{ AccountNumber = 123456789, Balance = 1500, OverDraftLimit = 250, User = new User{ Pin = 1234 }},
                               new Account{ AccountNumber = 987654321, Balance = 100, OverDraftLimit = 0, User = new User{ Pin = 2468 }}
                           };
        }

        public bool Authenticate(int accountNumber, int pin)
        {
            Account account = Accounts.SingleOrDefault(x => x.AccountNumber == accountNumber);
            return account != null && account.User.Pin == pin;
        }

        public int GetAvailableFunds(int accountNumber)
        {
            Account account = Accounts.SingleOrDefault(x => x.AccountNumber == accountNumber);
            return account.Balance + account.OverDraftLimit;
        }

        public void RemoveFunds(int accountNumber, int amount)
        {
            Account account = Accounts.SingleOrDefault(x => x.AccountNumber == accountNumber);
            account.Balance -= amount;
        }
    }
}