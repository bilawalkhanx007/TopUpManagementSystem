using Domain.ViewModel;
using FluentValidation;

namespace BalanceManangementApp.FluentValidationModel
{
    /// <summary>
    /// Validate incoming requst to Debit Credit Request API on the bases of below rules
    /// </summary>
    public class DebitCreditRequestViewModelValidator : AbstractValidator<DebitCreditRequestViewModel>
    {
        /// <summary>
        /// Validating Business Rules
        /// </summary>
        public DebitCreditRequestViewModelValidator()
        {
            RuleFor(x => x.UserId)
                 .NotEmpty().WithMessage("UserID should be not Empty")
                 .NotNull().WithMessage("UserID should be not null")
                 .GreaterThan(0).WithMessage("UserID should be Greater Than Zero");

            RuleFor(x => x.BeneficiaryId)
                 .NotEmpty().WithMessage("BeneficiaryId should be not Empty")
                 .NotNull().WithMessage("BeneficiaryId should be not null")
                 .GreaterThan(0).WithMessage("BeneficiaryId should be Greater Than Zero");

            RuleFor(x => x.Amount)
                 .NotEmpty().WithMessage("Amount should be not Empty")
                 .NotNull().WithMessage("Amount should be not null")
                 .GreaterThan(0).WithMessage("Amount should be Greater Than Zero");

            RuleFor(x => x.TransactionCharges)
                 .NotEmpty().WithMessage("TransactionCharges should be not Empty")
                 .NotNull().WithMessage("TransactionCharges should be not null")
                 .GreaterThan(0).WithMessage("TransactionCharges should be Greater Than Zero");
        }
    }
}
