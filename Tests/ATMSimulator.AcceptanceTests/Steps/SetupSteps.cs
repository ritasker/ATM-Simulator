using System;
using TechTalk.SpecFlow;

namespace ATMSimulator.AcceptanceTests.Steps
{
    [Binding]
    public class SetupSteps : StepDefinitions
    {
        [Given(@"the ATM has £(.*) in it")]
        public void GivenTheATMHasMoneyInIt(string funds)
        {
            _bankAtm.SetFunds(Convert.ToInt16(funds));
        }

        [Given(@"the following bank accounts have been setup:")]
        public void GivenTheFollowingBankAccountsHaveBeenSetup(Table table)
        {
            foreach (var row in table.Rows)
            {
                long acctNum = Convert.ToInt32(row["Account Number"]);
                int pin = Convert.ToInt32(row["PIN"]);
                int balance = Convert.ToInt32(row["Balance"]);
                int oDLimit = Convert.ToInt32(row["Overdraft Limit"]);

                _bankAtm.AddAccount(acctNum, pin, balance, oDLimit);
            }
        }

    }
}