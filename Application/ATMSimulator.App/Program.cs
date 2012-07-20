using System;

namespace ATMSimulator.App
{
    class Program
    {
        private static BankAtm _bankAtm;
        private static int _accountNumber;
        private static int _pin;

        static void Main(string[] args)
        {
            _bankAtm = new BankAtm();
            _bankAtm.SetFunds(1000);
            _bankAtm.AddAccount(0123456789, 1337, 400, 250);

            while(true)
            {
                LoginScreen();

                var authenticated = _bankAtm.Authenticate(_accountNumber, _pin);

                if(authenticated)
                {
                    MenuScreen();
                    ParseOption(Console.ReadLine());
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
            switch (option)
            {
                case "1": break;
                case "2": break;
                case "3": break;
                default: Console.WriteLine("Invalid Option:");
                    ParseOption(Console.ReadLine());
            }
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
