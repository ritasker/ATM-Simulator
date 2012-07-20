using System;

namespace ATMSimulator.App
{
    class Program
    {
        private static BankAtm _bankAtm;
        private static int _accountNumber;
        private static int _pin;
        private static bool _authenticated;

        static void Main(string[] args)
        {
            _bankAtm = new BankAtm();
            _bankAtm.SetFunds(1000);
            _bankAtm.AddAccount(0123456789, 1337, 400, 250);

            while(true)
            {
                LoginScreen();

                _authenticated = _bankAtm.Authenticate(_accountNumber, _pin);

                if (_authenticated)
                {
                    while (_authenticated)
                    {
                        Console.Clear();
                        MenuScreen();
                        ParseOption(Console.ReadLine());
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Login Failed!");    
                }
            }
        }

        private static void ParseOption(string option)
        {
            Console.Clear();

            switch (option)
            {
                case "1":
                    DispalyBalance();
                    break;
                case "2": break;
                case "3":
                    _authenticated = false;
                    break;
                default: Console.WriteLine("Invalid Option:");
                        MenuScreen();
                        ParseOption(Console.ReadLine());
                    break;
            }
        }

        private static void DispalyBalance()
        {
            var accountInfo = _bankAtm.GetBalance(_accountNumber);

            Console.WriteLine("Account Balance:\t\t{0:C}", accountInfo["balance"]);
            Console.WriteLine("Available Funds:\t\t{0:C}", accountInfo["available"]);
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private static void MenuScreen()
        {
            Console.WriteLine("Select Menu Option:");
            Console.WriteLine("\t1) Display Balence:");
            Console.WriteLine("\t2) Withdraw Money:");
            Console.WriteLine("\t3) Exit:");
        }

        private static void LoginScreen()
        {
            Console.Write("Enter Account number:");
            _accountNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter PIN:");
            _pin = Convert.ToInt32(Console.ReadLine());
        }
    }
}
