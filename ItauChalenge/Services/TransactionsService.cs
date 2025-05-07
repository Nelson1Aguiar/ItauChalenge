using ItauChalenge.Interfaces;
using ItauChalenge.Models;
using ItauChalenge.Repository;

namespace ItauChalenge.Service
{
    public class TransactionsService : ITransactionsService
    {
        public void SaveTransaction(Transaction transaction)
        {
            bool isValid = ValidateTransaction(transaction);

            if (!isValid)
                throw new ApplicationException("Transação inválida");

            TransactionsRepository.AddTransaction(transaction);
        }

        public void DeleteTransactions()
        {
            TransactionsRepository.DeleteTransactions();
        }

        public Statistics GetStatistics()
        {
            return TransactionsRepository.CalculeStatistics();
        }

        private bool ValidateTransaction(Transaction transaction)
        {
            bool isValid = true;

            if (transaction.Data_Hour == null || transaction.Data_Hour > DateTime.Now)
                isValid = false;

            if (transaction.Valor == null || transaction.Valor < 0)
                isValid = false;

            return isValid;
        }
    }
}
