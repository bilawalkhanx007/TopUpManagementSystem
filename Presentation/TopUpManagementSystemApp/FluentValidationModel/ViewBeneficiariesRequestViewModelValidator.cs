using Domain.ViewModel;
using FluentValidation;

namespace TopUpManagementSystemApp.FluentValidationModel
{

    /// <summary>
    /// Validate incoming requst to View Beneficiaries API on the bases of below rules
    /// </summary>
    public class ViewBeneficiariesRequestViewModelValidator : AbstractValidator<ViewBeneficiariesRequestViewModel>
    {
        /// <summary>
        /// Validating Business Rules
        /// </summary>
        public ViewBeneficiariesRequestViewModelValidator()
        {
            RuleFor(x => x.UserID)
                 .NotEmpty().WithMessage("UserID should be not Empty")
                 .NotNull().WithMessage("UserID should be not null")
                 .GreaterThan(0).WithMessage("UserID should be Greater Than Zero");
        }
    }
}
