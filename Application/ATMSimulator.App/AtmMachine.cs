namespace ATMSimulator.App
{
    using System;
    using ATMSimulator.App.Services;
    using ATMSimulator.App.Services.Interfaces;

    public class AtmMachine
    {
        private readonly IAtmDisplay _display;
        private readonly IAccountService _accountService;
        private int _accountNumber;

        public AtmMachine(IAtmDisplay display, IAccountService accountService)
        {
            _display = display;
            _accountService = accountService;
        }

        public void Start()
        {
            while (true)
            {
                _display.ScreenSaver();
                if (Authenticated())
                {
                    MainMenu();
                }
                else
                {
                    _display.AuthenticationFailed();
                }
            }
        }

        public bool Authenticated()
        {
            _accountNumber = _display.AskForAccountNumber();
            int pin = _display.AskForPin();

            return _accountService.Authenticate(_accountNumber, pin);
        }

        private void MainMenu()
        {
            bool exit = false;

            while (!exit)
            {
                ConsoleKey selection = _display.MainMenuSelection();

                switch (selection)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        CheckBalence();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        WithdrawCash();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        exit = true;
                        break;
                    default:
                        _display.InvalidSelection();
                        break;
                }
            }
        }

        private void WithdrawCash()
        {
            ConsoleKey selection = _display.WithdrawalSelection();

            switch (selection)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    MakeWithdrawal(10);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    MakeWithdrawal(20);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    MakeWithdrawal(30);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    MakeWithdrawal(50);
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    MakeWithdrawal(100);
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    int amount = _display.WithdrawalAmount();
                    MakeWithdrawal(amount);
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    break;
                default:
                    _display.InvalidSelection();
                    break;
            }
        }

        private void MakeWithdrawal(int amount)
        {
            int funds = _accountService.GetAvailableFunds(_accountNumber);
            if (funds >= amount)
            {
                _accountService.RemoveFunds(_accountNumber, amount);
                _display.WithdrawnAmount(amount);
            }
            else
            {
                _display.InsufficientFunds();
            }
        }

        private void CheckBalence()
        {
            int balence = _accountService.GetAvailableFunds(_accountNumber);
            _display.AvailableFunds(balence);
        }
    }
}