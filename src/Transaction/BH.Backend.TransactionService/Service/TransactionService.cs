using BH.Backend.Models.Db;
using BH.Backend.TransactionService.DataAccess;

namespace BH.Backend.TransactionService.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Add(Transaction transaction)
        {
            _transactionRepository.AddValue(transaction);
        }

        public Transaction Get(Guid id)
        {
            return _transactionRepository.GetById(id);
        }

        public IEnumerable<Transaction> GetByAcccountId(Guid accountId)
        {
            var values = _transactionRepository.GetByAccountId(accountId);

            if (values != null)
                return values.Where(m => m.AccountId.Equals(accountId));

            return null;
        }
    }
}
