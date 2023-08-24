using BH.Backend.Models.Db;

namespace BH.Backend.AccountService.DataAccess
{
    public interface IAccountRepository
    {
        public IEnumerable<Account> GetValues();

        public void AddValue(Account account);
    }
}
