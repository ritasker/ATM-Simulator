namespace ATMSimulator.App.Models
{
    public class Account
    {
        public long AccountNumber { get; set; }
        public int Pin { get; set; }
        public int Balance { get; set; }
        public int OverDraftLimit { get; set; }
    }
}