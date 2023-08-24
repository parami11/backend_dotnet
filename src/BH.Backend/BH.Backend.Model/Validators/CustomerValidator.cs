﻿using BH.Backend.Models.Constants;
using BH.Backend.Models.Db;
using FluentValidation;

namespace BH.Backend.Models.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.ID).NotEqual(Guid.Empty);

            RuleFor(x => x.FirstName)
                .Length(CustomerConstants.Name_Min_Length, CustomerConstants.Name_Max_Length);
            
            RuleFor(x => x.LastName)
                .Length(CustomerConstants.Name_Min_Length, CustomerConstants.Name_Max_Length);
        }
    }
}