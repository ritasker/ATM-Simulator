using ATMSimulator.App;
using TechTalk.SpecFlow;

namespace ATMSimulator.AcceptanceTests.Steps
{
    [Binding]
    public class StepDefinitions
    {
        protected BankAtm _bankAtm;

        [BeforeScenario]
        public void Setup()
        {
            _bankAtm = new BankAtm();
        }
    }
}