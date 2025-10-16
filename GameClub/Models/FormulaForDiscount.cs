namespace GameClub.Models
{
    internal static class FormulaForDiscount
    {
        private const decimal FivePercent = 5m;
        private const decimal TenPercent = 10m;
        private const decimal FifteenPercent = 15m;

        public static decimal FiveDiscount(decimal n) => n * ((100 - FivePercent) / 100);
        public static decimal TenDiscount(decimal n) => n * ((100 - TenPercent) / 100);
        public static decimal FifteenDiscount(decimal n) => n * ((100 - FifteenPercent) / 100);
    }
}
