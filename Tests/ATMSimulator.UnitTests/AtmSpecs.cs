using ATMSimulator.App;
using Machine.Specifications;

namespace ATMSimulator.UnitTests
{
    [Subject(typeof(BankAtm))]
    public class when_SetFunds_is_called
    {
        private const int FUNDS = 1000;
        private static BankAtm _subject;

        private Establish context = () =>
                                        {
                                            _subject = new BankAtm();
                                        };

        private Because of = () => _subject.SetFunds(FUNDS);

        private It should_set_the_funds = () => _subject.GetFunds().ShouldEqual(FUNDS);
    }

    [Subject(typeof(BankAtm))]
    public class when_GetFunds_is_called
    {
        private const int FUNDS = 1000;
        private static int _result;
        private static BankAtm _subject;

        private Establish context = () =>
        {
            _subject = new BankAtm();
            _subject.SetFunds(FUNDS);
        };

        private Because of = () => { _result = _subject.GetFunds(); };

        private It should_get_the_funds = () => _result.ShouldEqual(FUNDS);
    }
}