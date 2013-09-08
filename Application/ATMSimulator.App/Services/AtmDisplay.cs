namespace ATMSimulator.App.Services
{
    using System;
    using System.Threading;
    using ATMSimulator.App.Services.Interfaces;

    public class AtmDisplay : IAtmDisplay
    {
        public void ScreenSaver()
        {
            Console.Clear();

            Console.WriteLine("Press any key to use the ATM.");
            Console.ReadKey();
        }

        public int AskForAccountNumber()
        {
            Console.Clear();

            Console.Write("Enter Account number:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public int AskForPin()
        {
            Console.Clear();

            Console.Write("Enter PIN:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void AuthenticationFailed()
        {
            Console.Clear();

            Console.Write("Authentication failed.");
            Thread.Sleep(3000);
        }

        public ConsoleKey MainMenuSelection()
        {
            Console.Clear();

            Console.WriteLine("Select Menu Option:");
            Console.WriteLine("\t1) Display Balence");
            Console.WriteLine("\t2) Withdraw Money");
            Console.WriteLine();
            Console.Write("\t0) Exit");

            return Console.ReadKey(true).Key;
        }

        public void AvailableFunds(int funds)
        {
            Console.Clear();

            Console.WriteLine(string.Format("Available Funds: {0}", funds));
            Thread.Sleep(3000);
        }

        public ConsoleKey WithdrawalSelection()
        {
            Console.Clear();

            Console.WriteLine("Select an amount:");
            Console.WriteLine("\t1) 10\t\t4) 50");
            Console.WriteLine("\t2) 20\t\t5) 100");
            Console.WriteLine("\t3) 30\t\t6) Other");
            Console.WriteLine();
            Console.Write("\t0) Back");

            return Console.ReadKey(true).Key;
        }

        public void WithdrawnAmount(int amount)
        {
            Console.Clear();

            Console.Write(string.Format("You have withdrawn £{0}", amount));
            Thread.Sleep(3000);
        }

        public int WithdrawalAmount()
        {
            Console.Clear();

            Console.Write("Please enter an amount to withdraw:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void InsufficientFunds()
        {
            Console.Clear();

            Console.Write("There are insufficient funds in the account to complete the transaction.");
            Thread.Sleep(3000);
        }

        public void InvalidSelection()
        {
            Console.Clear();

            Console.Write("Invalid selection!");
            Thread.Sleep(3000);
        }
    }
}