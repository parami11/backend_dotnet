using BH.Backend.Models.Db;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;

namespace BH.Backend.AccountService.DataAccess
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMemoryCache _memoryCache;

        private readonly IValidator<Account> _validator;

        private const string EntityKey = "Accounts";

        public AccountRepository(
            IMemoryCache memoryCache,
            IValidator<Account> validator)
        {
            _memoryCache = memoryCache;
            _validator = validator;
        }

        public List<Account> GetValues()
        {
            _memoryCache.TryGetValue(AccountRepository.EntityKey, out List<Account> items);

            return items;
        }

        public void AddValue(Account account)
        {
            // Validate Account
            _validator.ValidateAndThrow(account);

            var items = this.GetValues();

            if (items == null)
                items = new List<Account>() { account };
            else
                items.Add(account);

            _memoryCache.Set(AccountRepository.EntityKey, items);
        }
    }
}
