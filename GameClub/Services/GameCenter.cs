using GameClub.Utils;
using GameClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameClub.Services
{
    internal class GameCenter
    {
        private readonly List<Account> accounts;
        private readonly TariffHourInGame tariffs;
        private readonly AmountForDiscount discountSystem;
        public GameCenter(TariffHourInGame tariffs, AmountForDiscount discountSystem)
        {
            accounts = new List<Account>();
            this.tariffs = tariffs;
            this.discountSystem = discountSystem;
        }

        public void AddAccount(string name, decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Ошибка! Баланс не может быть отрицательным!");
                return;
            }
            foreach (var account in accounts)
            {
                if (account.Name == name)
                {
                    Console.WriteLine("Пользователь с таким именем уже существует!");
                    return;
                }
            }
            string createId = Guid.NewGuid().ToString("N");

            Account newAccount = new Account(name, new Balance(amount), createId);

            accounts.Add(newAccount);
        }
        public void Deposit(string name, decimal amount)
        {
            foreach (var account in accounts)
            {
                if (account.Name == name)
                {
                    account.Balance.BalanceAcc += amount;
                    account.History.AddHistory(
                        $"Имя пользователя: {account.Name}\n" +
                        $"Уникальный ID: {account.Id}\n" +
                        $"Текущий баланс: {account.Balance.BalanceAcc}р\n" +
                        $"Тип операции: пополнение на сумму +{amount}р\n" +
                        $"Дата операции: {DateTime.Now}");
                }
            }
        }
        public void ShowHistory(string name)
        {
            foreach (var account in accounts)
            {
                if (account.Name == name)
                {
                    Console.WriteLine($"Имя: {account.Name} | Баланс: {account.Balance.BalanceAcc}р | ID: {account.Id}");
                }
            }
        }
        public void BuyOneHour(string name) => BuyHours(name, tariffs.oneHour, "1 час");
        public void BuyTwoHours(string name) => BuyHours(name, tariffs.twoHour, "2 часа");
        public void BuyFiveHours(string name) => BuyHours(name, tariffs.fiveHour, "5 часов");

        private void BuyHours(string name, decimal basePrice, string description)
        {
            var acc = accounts.FirstOrDefault(a => a.Name == name);
            if (acc == null) return;

            var discountedPrice = discountSystem.DiscountForUser(acc.History.GetTotalSpent(), basePrice);

            if (acc.Balance.BalanceAcc < discountedPrice)
            {
                Console.WriteLine($"Недостаточно средств. Нужно ещё {discountedPrice - acc.Balance.BalanceAcc}р");
                return;
            }

            acc.Balance.BalanceAcc -= discountedPrice;
            acc.History.AddHistory($"Тип операции: {description} | Цена: {discountedPrice}р | Баланс: {acc.Balance.BalanceAcc}р");
            acc.History.AddHistoryTotalSum(discountedPrice);
        }

        public void GetHistoryAcc(string name)
        {
            foreach (var account in accounts)
            {
                if (account.Name == name)
                {
                    foreach (var s in account.History.GetHistory())
                    {
                        Console.WriteLine(s);
                        Console.WriteLine("=============================================");
                    }
                }
            }
        }
        public void ExportHistory(string name)
        {
            var acc = accounts.FirstOrDefault(a => a.Name == name);
            if (acc != null) FileExporter.Export(acc.Name, acc.History.GetHistory());
        }
    }
}
