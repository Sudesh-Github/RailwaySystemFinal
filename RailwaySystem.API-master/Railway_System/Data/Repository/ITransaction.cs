using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public interface ITransaction
    {
        public string SaveTransaction(Transaction transaction);
        public string UpdateTransaction(Transaction transaction);
        Transaction GetTransaction(int TransactionId);
        List<Transaction> GetAllTransaction();
    }
}
