namespace ATMSimulator.Specs
{
    using ATMSimulator.App;
    using ATMSimulator.App.Services.Interfaces;
    using Machine.Specifications;
    using Moq;
    using It = Machine.Specifications.It;

    [Subject(typeof(AtmMachine))]
    public class Context_for_atm_machine
    {
        Establish context = () =>
                                {
                                    MockDisplay = new Mock<IAtmDisplay>();
                                    MockAcountService = new Mock<IAccountService>();

                                    Subject = new AtmMachine(MockDisplay.Object, MockAcountService.Object);
                                };

        protected static AtmMachine Subject;
        protected static Mock<IAtmDisplay> MockDisplay;
        protected static Mock<IAccountService> MockAcountService;
    }

    [Subject(typeof(AtmMachine), "Given valid account details")]
    public class when_asked_to_login : Context_for_atm_machine
    {
        private Establish context = () => { 
            MockDisplay
                .Setup(x=>x.AskForAccountNumber())
                .Returns(ACCOUNT_NUMBER)
                .Verifiable();

            MockDisplay
                .Setup(x=>x.AskForPin())
                .Returns(PIN)
                .Verifiable();

            MockAcountService
                .Setup(x=>x.Authenticate(ACCOUNT_NUMBER, PIN))
                .Returns(true)
                .Verifiable();
        };

        private Because of = () => _result = Subject.Authenticated();

        private It should_ask_for_the_users_account_number = () => MockDisplay.Verify(x => x.AskForAccountNumber(), Times.AtLeastOnce);
        private It should_ask_for_the_users_pin = () => MockDisplay.Verify(x => x.AskForPin(), Times.AtLeastOnce);
        private It should_authenticate_the_users_details = () => MockAcountService.Verify(x => x.Authenticate(ACCOUNT_NUMBER, PIN), Times.AtLeastOnce);
        private It should_return_true = () => _result.ShouldBeTrue();
       
        private static bool _result;
        private const int PIN = 1234;
        private const int ACCOUNT_NUMBER = 0123456789;
    }
}