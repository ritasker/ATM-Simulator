namespace ATMSimulator.App.Services.Interfaces
{
    public interface IAccountService
    {
        bool Authenticate(int accountNumber, int pin);
        int GetAvailableFunds(int accountNumber);
        void RemoveFunds(int accountNumber, int amount);
    }
}