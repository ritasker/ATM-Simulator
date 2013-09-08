namespace ATMSimulator.App.Services.Interfaces
{
    using System;

    public interface IAtmDisplay
    {
        void ScreenSaver();
        int AskForAccountNumber();
        int AskForPin();
        void AuthenticationFailed();
        ConsoleKey MainMenuSelection();
        void AvailableFunds(int funds);
        ConsoleKey WithdrawalSelection();
        void WithdrawnAmount(int amount);
        int WithdrawalAmount();
        void InsufficientFunds();
        void InvalidSelection();
    }
}