using BH.Backend.Api.Entities;

namespace BH.Backend.Api.Tests.Mock
{
    public class AccountRequestMock
    {
        public static AccountRequest AccountRequest_Valid = new AccountRequest()
        {
            CustomerId = Guid.NewGuid(),
            InitialCredit = 0
        };

        public static AccountRequest AccountRequest_InValid_EmptyCustomerId = new AccountRequest()
        {
            InitialCredit = 0
        };

        public static AccountRequest AccountRequest_Invalid_NegativeCredit = new AccountRequest()
        {
            CustomerId = Guid.NewGuid(),
            InitialCredit = -4
        };
    }
}
