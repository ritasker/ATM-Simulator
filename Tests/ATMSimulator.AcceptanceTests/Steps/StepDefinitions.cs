using ATMSimulator.App;
using TechTalk.SpecFlow;

namespace ATMSimulator.AcceptanceTests.Steps
{
    [Binding]
    public class StepDefinitions
    {
        protected static BankAtm _bankAtm;

        [BeforeFeature]
        public static void Setup()
        {
            _bankAtm = new BankAtm();
        }
    }
}