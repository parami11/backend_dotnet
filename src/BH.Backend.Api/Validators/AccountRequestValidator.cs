using BH.Backend.Api.Entities;
using FluentValidation;

namespace BH.Backend.Api.Validators
{
    public class AccountRequestValidator : AbstractValidator<AccountRequest>
    {
        public AccountRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEqual(Guid.Empty);

            RuleFor(x => x.InitialCredit).GreaterThanOrEqualTo(0);
        }
    }
}
