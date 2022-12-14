using RailwaySystem.API.Models;
using RailwaySystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RailwaySystem.API.Services
{
    public class TransactionS
    {
        private ITransaction _transactionRepository;
        public TransactionS(ITransaction transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public string SaveTransaction(Transaction Transaction)
        {
            return _transactionRepository.SaveTransaction(Transaction);
        }
        public string UpdateTransaction(Transaction Transaction)
        {
            return _transactionRepository.UpdateTransaction(Transaction);
        }
        public Transaction GetTransaction(int TransactionId)
        {
            return _transactionRepository.GetTransaction(TransactionId);
        }
        public List<Transaction> GetAllTransaction()
        {
            return _transactionRepository.GetAllTransaction();
        }
    }
}
