using TechTalk.SpecFlow;

namespace ATMSimulator.AcceptanceTests.Steps
{
    [Binding]
    public class AtmLoginSteps : StepDefinitions
    {
        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter my account number '0123456789'")]
        public void WhenIEnterMyAccountNumber0123456789()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"my pin '1337'")]
        public void WhenMyPin1337()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see the menu screen")]
        public void ThenIShouldSeeTheMenuScreen()
        {
            ScenarioContext.Current.Pending();
        }

    }
}