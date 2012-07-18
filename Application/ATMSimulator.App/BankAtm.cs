namespace ATMSimulator.App
{
    public class BankAtm
    {
        private int Funds { get; set; }

        public void SetFunds(int value)
        {
            Funds = value;
        }

        public int GetFunds()
        {
            return Funds;
        }
    }
}