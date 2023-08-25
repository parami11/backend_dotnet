using BH.Backend.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Backend.TransactionService.Service
{
    public interface ITransactionService
    {
        public Transaction Get(Guid id);

        public IEnumerable<Transaction> GetByAcccountId(Guid accountId);

        public void Add(Transaction transaction);
    }
}
