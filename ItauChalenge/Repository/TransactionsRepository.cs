using ItauChalenge.Models;

namespace ItauChalenge.Repository
{
    public class TransactionsRepository
    {
        private static List<Transaction> transactions = new List<Transaction>();

        public static void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public static void DeleteTransactions()
        {
            transactions.Clear();
        }

        public static Statistics CalculeStatistics()
        {
            const decimal defaultValue = 0;

            DateTime startDate = DateTime.Now.AddSeconds(-60);

            List<Transaction> transactionsInRange = transactions
                .Where(t => t.Data_Hour >= startDate)
                .ToList();

            return transactionsInRange.Any()
                 ? new Statistics
                 {
                     Count = transactionsInRange.Count,
                     Sum = transactionsInRange.Sum(t => t.Valor),
                     Min = transactionsInRange.Min(t => t.Valor),
                     Max = transactionsInRange.Max(t => t.Valor),
                     Avg = transactionsInRange.Average(t => t.Valor),
                 }
                 : new Statistics
                 {
                     Count = 0,
                     Sum = defaultValue,
                     Min = defaultValue,
                     Max = defaultValue,
                     Avg = defaultValue,
                 };
        }
    }
}
