using System.Collections.Generic;
using ATMSimulator.App;
using Machine.Specifications;

namespace ATMSimulator.UnitTests
{
    [Subject(typeof(BankAtm))]
    public class Context_for_BankAtm_class
    {
        protected static BankAtm _bankAtm;

        Establish context = () =>
                                {
                                    _bankAtm = new BankAtm();
                                };
    }


    public class when_SetFunds_is_called : Context_for_BankAtm_class
    {
        const int FUNDS = 1000;

        Because of = () => _bankAtm.SetFunds(FUNDS);

        It should_set_the_funds = () => _bankAtm.Funds.ShouldEqual(FUNDS);
    }

    public class when_GetFunds_is_called : Context_for_BankAtm_class
    {
        const int FUNDS = 1000;
        static int _result;

        Establish context = () => _bankAtm.SetFunds(FUNDS);

        Because of = () => { _result = _bankAtm.GetFunds(); };

        It should_get_the_funds = () => _result.ShouldEqual(FUNDS);
    }

    public class when_AddAccount_is_called : Context_for_BankAtm_class
    {
        private const int ACCT_NUM = 0123456789;
        private const int PIN= 1337;
        private const int BALANCE= 100;
        private const int OVERDRAFT_LIMIT= 250;

        Because of = () => _bankAtm.AddAccount(ACCT_NUM, PIN, BALANCE, OVERDRAFT_LIMIT);

        It should_save_the_account = () => _bankAtm.Accounts.Count.ShouldEqual(1);
        
    }

    public class when_Authenticate_is_called_with_a_vailid_account : Context_for_BankAtm_class
    {
        private const int PIN = 1337;
        private static bool _result;
        private const int ACCT_NUM = 0123456789;

        Establish context = () => _bankAtm.AddAccount(ACCT_NUM, PIN, 0, 0);

        private Because of = () => _result = _bankAtm.Authenticate(ACCT_NUM, PIN);

        private It should_return_true = () => _result.ShouldBeTrue();
    }

    public class when_Authenticate_is_called_with_an_invailid_account : Context_for_BankAtm_class
    {
        private const int PIN = 1337;
        private static bool _result;
        private const int ACCT_NUM = 0123456789;

        Establish context = () => _bankAtm.AddAccount(ACCT_NUM, PIN, 0, 0);

        private Because of = () => _result = _bankAtm.Authenticate(ACCT_NUM, 2468);

        private It should_return_true = () => _result.ShouldBeFalse();
    }

    public class when_GetBalance_is_called : Context_for_BankAtm_class
    {
         private const int ACCT_NUM = 0123456789;
        private const int PIN= 1337;
        private const int BALANCE= 100;
        private const int OVERDRAFT_LIMIT= 250;
        private static Dictionary<string, int> _result;

        Establish context = () => _bankAtm.AddAccount(ACCT_NUM, PIN, BALANCE, OVERDRAFT_LIMIT);

        private Because of = () => { _result = _bankAtm.GetBalance(ACCT_NUM); };

        private It should_return_the_balance = () => _result["balance"].ShouldEqual(BALANCE);

        private It should_return_the_available_funds = () => _result["available"].ShouldEqual(BALANCE + OVERDRAFT_LIMIT);
    }
}