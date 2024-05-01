using Domain.ViewModel;
using FluentValidation;

namespace TopUpManagementSystemApp.FluentValidationModel
{
    /// <summary>
    /// Validate incoming requst to Add Beneficiary API on the bases of below rules
    /// </summary>
    public class AddBeneficiaryViewModelValidator : AbstractValidator<AddBeneficiaryViewModel>
    {
        /// <summary>
        /// Validating Business Rules
        /// </summary>
        public AddBeneficiaryViewModelValidator()
        {
            RuleFor(x => x.NickName)
                 .NotEmpty().WithMessage("NickName should be not Empty")
                 .NotNull().WithMessage("NickName should be not null")
                 .Length(2, 20).WithMessage("NickName must be longer than 2 and less then 20 characters");


            RuleFor(x => x.MobileNumber)
                  .NotEmpty().WithMessage("MobileNumber should be not Empty")
                  .NotNull().WithMessage("MobileNumber should be not Empty")
                  .Matches(@"^\d{10}$")
                  .WithMessage("Invalid MobileNumber.");

            RuleFor(x => x.UserID)
                 .NotEmpty().WithMessage("UserID should be not Empty")
                 .NotNull().WithMessage("UserID should be not null");
        }
    }
}
