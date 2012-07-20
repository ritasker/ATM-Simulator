using System.Collections.Generic;
using ATMSimulator.App.Models;
using System.Linq;

namespace ATMSimulator.App
{
    public class BankAtm
    {
        public int Funds { get; set; }
        public IList<Account> Accounts = new List<Account>();

        public void SetFunds(int value)
        {
            Funds = value;
        }

        public int GetFunds()
        {
            return Funds;
        }

        public void AddAccount(long accountNumber, int pin, int balance, int overdraftLimit)
        {
            Accounts.Add(new Account { AccountNumber = accountNumber, Pin = pin, Balance = balance, OverDraftLimit = overdraftLimit});
        }

        public bool Authenticate(long accountNumber, int pin)
        {
            var account = Accounts.SingleOrDefault(x => x.AccountNumber == accountNumber && x.Pin == pin);
            return account != null;
        }
    }
}