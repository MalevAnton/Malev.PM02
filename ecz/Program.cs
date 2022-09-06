using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;


namespace Exzamen
{
    public class Program
    {
        static void Main(string[] args)
        {
            TextWriterTraceListener tr2 = new TextWriterTraceListener(System.IO.File.CreateText(@"../../Output.txt"));
            Dictionary<double, double> money = new Dictionary<double, double>();
            for (int i = 0; i <= 1000000; i += 10000)
            {

                double percentBet = GetPercent(i);
                User user = new User();

                double bankBet = 8;
                user.investment = i;
                user.deposit = user.investment;
                double currentDeposit = user.investment;
                double monthIncome = 0;
                int month = 1;
                while (month <= 12)
                {
                    if (month % 3 == 0)
                        IncreaseBet(percentBet, 0.5);
                    if (percentBet > bankBet)
                    {
                        currentDeposit += currentDeposit * ((percentBet - (percentBet / 100 * 30)) / 100 / 12);
                    }
                    else
                        currentDeposit += currentDeposit * (percentBet / 100 / 12);

                    monthIncome = currentDeposit - user.deposit;
                    if (percentBet > bankBet && percentBet - bankBet >= 5)
                        currentDeposit -= GetTax(monthIncome);
                    month++;
                    Console.WriteLine("Баланс: {0} / {1}%", Math.Round(currentDeposit, 2), Math.Round(percentBet));
                    if (month == 13)
                    {
                        month = 0;
                        Debug.WriteLine("Начальный депозит:{0} Баланс: {1}. За год {2} /{3}", i, Math.Round(currentDeposit, 2), Math.Round(currentDeposit - user.deposit, 2), Math.Round(percentBet));
                        user.deposit = currentDeposit;

                        break;
                    }
                }
                money.Add(user.investment, currentDeposit);
            }

            double maxValue = SeachMaxValue(money);
            double maxKey = money.FirstOrDefault(x => x.Value == maxValue).Key;
            Debug.WriteLine($"Максимальный доход c депозита {maxKey} составил {maxValue}");
            Debug.Flush();
            Console.ReadLine();
        }
        static double IncreaseBet(double bet, double count) => bet += count;
        public static double GetTax(double deposit) => deposit *= 0.0;
        public static double SeachMaxValue(Dictionary<double, double> money)
        {
            double maxValue = 0;
            foreach (var item in money.Values)
            {
                if (maxValue < item)
                {
                    maxValue = item;
                }
            }

            return maxValue;
        }
        public static double GetPercent(int i)
        {
            double percentBet = 1;
            if (i < 700000)
            {
                double proc = i / 50000;
                proc++;
                percentBet = Math.Round(proc);
            }
            if (i >= 700000)
                percentBet = 20;
            return percentBet;
        }
    }

    public class User
    {
        public double investment { get; set; }
        public double deposit { get; set; }
        public double bet { get; set; }
    }
}