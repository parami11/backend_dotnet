using BH.Backend.Models.Db;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Principal;

namespace BH.Backend.TransactionService.DataAccess
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IMemoryCache _memoryCache;

        private readonly IValidator<Transaction> _validator;

        private const string EntityKey = "Transactions";

        public TransactionRepository(
            IMemoryCache memoryCache,
            IValidator<Transaction> validator)
        {
            _memoryCache = memoryCache;
            _validator = validator;
        }

        public Transaction GetById(Guid Id)
        {
            var items = this.GetAll();

            return items.Where(m => m.ID.Equals(Id)).First();
        }

        public IEnumerable<Transaction> GetByAccountId(Guid accountId)
        {
            var items = this.GetAll();

            if (items != null)
                return items.Where(m => m.AccountId.Equals(accountId));

            return null;
        }

        public void AddValue(Transaction transaction)
        {
            // Validate Transaction
            _validator.ValidateAndThrow(transaction);

            var items = this.GetAll();

            if (items == null)
                items = new List<Transaction>() { transaction };
            else
                items.Add(transaction);

            _memoryCache.Set(TransactionRepository.EntityKey, items);
        }

        private List<Transaction> GetAll()
        {
            _memoryCache.TryGetValue(TransactionRepository.EntityKey, out List<Transaction> items);

            return items;
        }
    }
}
