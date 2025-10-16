namespace GameClub.Models
{
    internal class TariffHourInGame
    {
        public decimal oneHour { get; set; }
        public decimal twoHour { get; set; }
        public decimal fiveHour { get; set; }

        public TariffHourInGame(decimal one, decimal two, decimal five)
        {
            oneHour = one;
            twoHour = two;
            fiveHour = five;
        }
    }
}
