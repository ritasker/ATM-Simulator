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
    }
}