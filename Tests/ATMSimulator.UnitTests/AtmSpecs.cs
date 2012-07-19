using ATMSimulator.App;
using Machine.Specifications;

namespace ATMSimulator.UnitTests
{
    [Subject(typeof(BankAtm))]
    public class when_SetFunds_is_called
    {
        const int FUNDS = 1000;
        static BankAtm _subject;

        Establish context = () =>
                                {
                                    _subject = new BankAtm();
                                };

        Because of = () => _subject.SetFunds(FUNDS);

        It should_set_the_funds = () => _subject.GetFunds().ShouldEqual(FUNDS);
    }

    [Subject(typeof(BankAtm))]
    public class when_GetFunds_is_called
    {
        const int FUNDS = 1000;
        static int _result;
        static BankAtm _subject;

        Establish context = () =>
        {
            _subject = new BankAtm();
            _subject.SetFunds(FUNDS);
        };

        Because of = () => { _result = _subject.GetFunds(); };

        It should_get_the_funds = () => _result.ShouldEqual(FUNDS);
    }

    [Subject(typeof(BankAtm))]
    public class when_AddAccount_is_called
    {
        static BankAtm _subject;
        private const int ACCT_NUM = 0123456789;
        private const int PIN= 1337;
        private const int BALANCE= 100;
        private const int OVERDRAFT_LIMIT= 250;

        Establish context = () =>{ _subject = new BankAtm(); };

        Because of = () => _subject.AddAccount(ACCT_NUM, PIN, BALANCE, OVERDRAFT_LIMIT);

        It should_get_the_funds = () => _subject.Accounts.Count.ShouldEqual(1);
        
    }
}