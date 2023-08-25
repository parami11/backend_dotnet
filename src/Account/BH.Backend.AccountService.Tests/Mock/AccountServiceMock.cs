using BH.Backend.Models.Db;
using BH.Backend.Models.Tests.Mock;

namespace BH.Backend.AccountService.Tests.Mock
{
    public class AccountServiceMock
    {
        public static List<Account> ValidAccounts 
            = new List<Account>() { AccountMock.Account_Valid };
    }
}
