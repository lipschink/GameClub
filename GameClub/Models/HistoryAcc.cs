using System.Collections.Generic;
using System.Linq;

namespace GameClub.Models
{
    internal class HistoryAcc
    {
        private readonly List<string> history;
        private readonly List<decimal> total;

        public HistoryAcc()
        {
            history = new List<string>();
            total = new List<decimal>();
        }
        public void AddHistory(string line)
        {
            history.Add(line);
        }
        public List<string> GetHistory()
        {
            return history;
        }
        public void AddHistoryTotalSum(decimal n)
        {
            total.Add(n);
        }
        public decimal GetTotalSpent()
        {
            return total.Sum();
        }
    }
}
