using ItauChalenge.Interfaces;
using ItauChalenge.Models;
using ItauChalenge.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace ItauChalengeTests.Tests
{
    public class TransactionTests
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionTests()
        {
            _transactionsService = new TransactionsService();
        }
    }
}