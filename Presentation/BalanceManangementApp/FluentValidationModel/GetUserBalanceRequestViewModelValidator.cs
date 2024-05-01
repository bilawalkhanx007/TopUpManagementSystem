using Domain.ViewModel;
using FluentValidation;

namespace BalanceManangementApp.FluentValidationModel
{
    /// <summary>
    /// Validate incoming requst to Get User Balance Request API on the bases of below rules
    /// </summary>
    public class GetUserBalanceRequestViewModelValidator : AbstractValidator<GetUserBalanceRequestViewModel>
    {
        /// <summary>
        /// Validating Business Rules
        /// </summary>
        public GetUserBalanceRequestViewModelValidator()
        {
            RuleFor(x => x.UserId)
                 .NotEmpty().WithMessage("UserID should be not Empty")
                 .NotNull().WithMessage("UserID should be not null")
                 .GreaterThan(0).WithMessage("UserID should be Greater Than Zero");
        }
    }
}
