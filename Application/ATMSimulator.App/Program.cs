namespace ATMSimulator.App
{
    using ATMSimulator.App.Services;

    class Program
    {
        static void Main(string[] args)
        {
            AtmMachine atmMachine = new AtmMachine(new AtmDisplay(), new AccountService());
            atmMachine.Start();
        }
    }
}
