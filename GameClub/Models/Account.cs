using GameClub.Models;
using System;

namespace GameClub.Models
{
    internal class Account
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public Balance Balance { get; set; }
        public HistoryAcc History { get; set; }
        public Account(string name, Balance balance, string id)
        {
            Name = name;
            Balance = balance;
            Id = id;
            History = new HistoryAcc();

            History.AddHistory(
                $"Дата создания: {DateTime.Now}\n" +
                $"Имя пользователя: {name}\n" +
                $"Текущий баланс: {balance.BalanceAcc}р\n" +
                $"Уникальный ID: {id}");
        }
    }
}