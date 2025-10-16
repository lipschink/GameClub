namespace GameClub.Models
{
    internal class Balance
    {
        public decimal BalanceAcc { get; set; }
        public Balance(decimal amount)
        {
            BalanceAcc = amount;
        }
    }
}
