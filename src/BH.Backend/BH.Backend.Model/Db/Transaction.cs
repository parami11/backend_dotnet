using BH.Backend.Model.Enums;

namespace BH.Backend.Model.Db
{
    public class Transaction
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public TransactionType TransactionType { get; set; }

        public double Amount { get; set; }
    }
}
