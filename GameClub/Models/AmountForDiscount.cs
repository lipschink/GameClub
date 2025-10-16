using GameClub.Models;

namespace GameClub.Models
{
    internal class AmountForDiscount
    {
        private readonly decimal sumForFive;
        private readonly decimal sumForTen;
        private readonly decimal sumForFifteen;

        public AmountForDiscount(decimal fivePercent, decimal tenPercent, decimal fifteenPercent)
        {
            sumForFive = fivePercent;
            sumForTen = tenPercent;
            sumForFifteen = fifteenPercent;
        }
        public decimal DiscountForUser(decimal total, decimal amount)
        {
            if (total < sumForFive)
            {
                return amount;
            }
            if (total >= sumForFive && total < sumForTen)
            {
                return FormulaForDiscount.FiveDiscount(amount);
            }
            if (total >= sumForTen && total < sumForFifteen)
            {
                return FormulaForDiscount.TenDiscount(amount);
            }
            if (total >= sumForFifteen)
            {
                return FormulaForDiscount.FifteenDiscount(amount);
            }

            return amount;
        }
    }
}
