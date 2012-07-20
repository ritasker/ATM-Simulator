using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ATMSimulator.AcceptanceTests.Steps
{
    [Binding]
    public class AtmLoginSteps : StepDefinitions
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

        [Then(@"I should be allowed into the system")]
        public void ThenIShouldBeAllowedIntoTheSystem()
        {
            Assert.That(_authenticationResult, Is.All.True);
        }

    }
}