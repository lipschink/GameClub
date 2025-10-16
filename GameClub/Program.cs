using GameClub.Models;
using GameClub.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameClub.Services.GameCenter center = new GameClub.Services.GameCenter(
               new TariffHourInGame(100, 200, 300),
               new AmountForDiscount(400, 800, 1000)
           );

            center.AddAccount("Lipsq", 1000);

            center.BuyFiveHours("Lipsq");

            center.GetHistoryAcc("Lipsq");

            center.ShowHistory("Lipsq");
        }
    }
}
