using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public interface IBankCred
    {
        public string SaveBankCred(BankCred bankcred);
        public string UpdateBankCred(BankCred bankcred);
        public string DeactBankCred(int BankCredId);
        BankCred GetBankCred(int BankCredId);
        List<BankCred> GetAllBankCreds();
    }
}
