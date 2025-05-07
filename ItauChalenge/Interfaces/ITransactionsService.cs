using ItauChalenge.Models;

namespace ItauChalenge.Interfaces
{
    public interface ITransactionsService
    {
        void SaveTransaction(Transaction transaction);
        void DeleteTransactions();
        Statistics GetStatistics();
    }
}
