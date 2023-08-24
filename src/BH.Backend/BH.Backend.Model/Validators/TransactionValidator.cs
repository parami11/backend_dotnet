using BH.Backend.Model.Db;
using BH.Backend.Model.Enums;
using FluentValidation;

namespace BH.Backend.Model.Validators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.ID).NotEqual(Guid.Empty);

            RuleFor(x => x.TransactionType).NotEqual(TransactionType.None);

            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        }
    }
}
