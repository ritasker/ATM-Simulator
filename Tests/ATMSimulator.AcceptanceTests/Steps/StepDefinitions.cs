using ATMSimulator.App;
using TechTalk.SpecFlow;

namespace ATMSimulator.AcceptanceTests.Steps
{
    [Binding]
    public class StepDefinitions
    {
        [BeforeScenario]
        public void Setup()
        {
            var atm = new BankAtm();
        }


        [Given(@"the ATM has money in it")]
        public void GivenTheATMHasMoneyInIt()
        {
            ScenarioContext.Current.Pending();
        }

    }
}