using System;
using System.Collections.Generic;
using ATMSimulator.App.Models;

namespace ATMSimulator.App
{
    public class BankAtm
    {
        public int Funds { get; set; }
        public IList<Account> Accounts { get; set; }

        public BankAtm()
        {
            Accounts = new List<Account>();
        }

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
    }
}