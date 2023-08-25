using BH.Backend.Models.Db;

namespace BH.Backend.Models.Tests.Mock
{
    public class AccountMock
    {
        private const string AccountNumber_Valid = "NLABNA";

        private const string AccountNumber_InvalidLength = "NLABN";

        public static Account Account_Valid = new Account()
        {
            CustomerId = Guid.NewGuid(),
            AccountNumber = AccountNumber_Valid,
        };

        public static Account Account_Invalid_InvalidAccountNumber = new Account()
        {
            CustomerId = Guid.NewGuid(),
            AccountNumber = AccountNumber_InvalidLength,
        };

        public static Account Account_Invalid_EmptyAccountNumber = new Account()
        {
            CustomerId = Guid.NewGuid(),
            AccountNumber = string.Empty,
        };

        public static Account Account_Invalid_NegativeBalance = new Account()
        {
            CustomerId = Guid.NewGuid(),
            AccountNumber = AccountNumber_Valid,
            CurrentBalance = -6,
        };

        public static Account Account_Invalid_EmptyCustomerId = new Account()
        {
            AccountNumber = AccountNumber_Valid,
        };
    }
}
