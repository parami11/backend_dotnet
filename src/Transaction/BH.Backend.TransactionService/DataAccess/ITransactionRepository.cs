using BH.Backend.Models.Db;

namespace BH.Backend.TransactionService.DataAccess
{
    public interface ITransactionRepository
    {
        public Transaction GetById(Guid id);

        public IEnumerable<Transaction> GetByAccountId(Guid accountId);

        public void AddValue(Transaction transaction);
    }
}
