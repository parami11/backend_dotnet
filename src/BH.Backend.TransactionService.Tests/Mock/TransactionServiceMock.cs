using BH.Backend.Models.Db;
using BH.Backend.Models.Tests.Mock;

namespace BH.Backend.TransactionService.Tests.Mock
{
    internal class TransactionServiceMock
    {
        public static List<Transaction> ValidTransactions 
            = new List<Transaction>() { TransactionMock.Transaction_Valid };
    }
}
