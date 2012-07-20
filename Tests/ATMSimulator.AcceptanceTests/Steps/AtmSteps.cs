using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ATMSimulator.AcceptanceTests.Steps
{
    [Binding]
    public class AtmSteps : StepDefinitions
    {
        List<bool> _authenticationResult = new List<bool>();

        [When(@"I enter the following account number and PIN:")]
        public void WhenIEnterTheFollowingAccountNumberAndPIN(Table table)
        {
            foreach (var row in table.Rows)
            {
                long accountNumber = Convert.ToInt32(row["Account Number"]);
                int pin = Convert.ToInt16(row["PIN"]);

                _authenticationResult.Add(_bankAtm.Authenticate(accountNumber, pin));
            }
        }

        [When(@"I request to see my balance for my account '(.*)'")]
        public void WhenIRequestToSeeMyBalance(string accountNumber)
        {
            long acctNum = Convert.ToInt32(accountNumber);
            _bankAtm.GetBalance(acctNum);
        }

        [Then(@"I should be allowed into the system")]
        public void ThenIShouldBeAllowedIntoTheSystem()
        {
            Assert.That(_authenticationResult, Is.All.True);
        }

    }
}