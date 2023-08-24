using BH.Backend.Models.Db;
using BH.Backend.Models.Enums;
using FluentValidation;

namespace BH.Backend.Models.Validators
{
    public class TransactionEntityValidator : AbstractValidator<Transaction>
    {
        public TransactionEntityValidator()
        {
            RuleFor(x => x.ID).NotEqual(Guid.Empty);

            RuleFor(x => x.TransactionType).NotEqual(TransactionType.None);

            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        }
    }
}
