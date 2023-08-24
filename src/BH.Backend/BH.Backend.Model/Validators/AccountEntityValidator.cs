using BH.Backend.Model.Constants;
using BH.Backend.Model.Db;
using FluentValidation;

namespace BH.Backend.Model.Validators
{
    public class AccountEntityValidator : AbstractValidator<Account>
    {
        public AccountEntityValidator()
        {
            RuleFor(x => x.ID).NotEqual(Guid.Empty);

            RuleFor(x => x.AccountNumber).NotNull();
            RuleFor(x => x.AccountNumber).NotEmpty().When(m => m.AccountNumber != null);
            RuleFor(x => x.AccountNumber)
                .Length(AccountConstants.AccountNumber_Length, AccountConstants.AccountNumber_Length)
                .When(m => m.AccountNumber != null).When(m => m.AccountNumber != string.Empty);

            RuleFor(x => x.CurrentBalance).GreaterThanOrEqualTo(0);
        }
    }
}
