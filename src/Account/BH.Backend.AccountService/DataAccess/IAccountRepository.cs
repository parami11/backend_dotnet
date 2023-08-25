using BH.Backend.Models.Db;

namespace BH.Backend.AccountService.DataAccess
{
    public interface IAccountRepository
    {
        public List<Account> GetValues();

        public void AddValue(Account account);
    }
}
