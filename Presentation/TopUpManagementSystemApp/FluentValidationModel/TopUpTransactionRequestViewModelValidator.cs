using Domain.ViewModel;
using FluentValidation;

namespace TopUpManagementSystemApp.FluentValidationModel
{

    /// <summary>
    /// Validate incoming requst to TopUp Transaction API on the bases of below rules
    /// </summary>
    public class TopUpTransactionRequestViewModelValidator : AbstractValidator<TopUpTransactionRequestViewModel>
    {
        /// <summary>
        /// Validating Business Rules
        /// </summary>
        public TopUpTransactionRequestViewModelValidator()
        {
            RuleFor(x => x.UserId)
                 .NotEmpty().WithMessage("UserID should be not Empty")
                 .NotNull().WithMessage("UserID should be not null")
                 .GreaterThan(0).WithMessage("UserID should be Greater Than Zero");
        }
    }
}
