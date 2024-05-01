using Application.Features.TopUpBeneficiaryFeatures.Commands;
using Domain.Abstructions;
using Domain.Entities;
using Domain.Enum;
using Domain.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BalanceManagmentAppFeatures.BalanceTransaction.Commands
{
    /// <summary>
    /// This Will Call When DebitCreaditTransaction API Occcured
    /// Handle All Business Logic here, related to Debit Creadit Transaction
    /// </summary>
    public class DebitCreditCommandHandler : IRequestHandler<DebitCreditCommand, ResponseViewModel>
    {

        /// <summary>
        /// unit Of Work single use to perform single Execution point of save changes.
        /// </summary>
        private readonly IBalanceManagementAppUnitOfWork unitOfWork;


        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="_unitOfWork"></param>
        public DebitCreditCommandHandler(IBalanceManagementAppUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        /// <summary>
        /// Handler Process
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> Handle(DebitCreditCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseViewModel();

            // Start Transaction here, then after sucesfully exection of all action commit changes.
            using var transaction = unitOfWork.BeginTransaction();
            try
            {
                //Get user details
                var userBalance = await unitOfWork.UserBalanceRepository.GetUserBalance(request.requestModel.UserId, cancellationToken);
                if (userBalance != null)
                {
                    //verify User has sufficient balance tp perform transaction
                    var deductibleAmount = (request.requestModel.Amount + request.requestModel.TransactionCharges);
                    if (deductibleAmount > userBalance.Balance)
                    {
                        response.Message = $"Insufficient balance.";
                        return response;
                    }

                    //IN Case: user has sufficient balance then Debit amount from his account
                    userBalance.Balance = (userBalance.Balance - deductibleAmount);
                    userBalance.OnEntityModified();
                    unitOfWork.UserBalanceRepository.Update(userBalance);
                    ;
                    // Add Balnce into Beneficiary Account
                    var newBeneficiaryBalance = new BeneficiaryBalance();
                    await AddBeneficiaryBalance(request, newBeneficiaryBalance);


                    // Execute SaveChanges
                    var isExecute = await unitOfWork.ApplySaveChanges(cancellationToken);

                    if (isExecute > 0)
                        transaction.Commit();

                    response.Message = $"Transaction Sucessfully";
                    response.IsSucess = true;
                    return response;
                }
                else
                {
                    response.Message = $"User Not Exists";
                    return response;
                }
            }
            catch (Exception)
            {

                transaction.Rollback();
            }

            return response;
        }



        /// <summary>
        /// This method is use to add Beneficiary Balance
        /// </summary>
        /// <param name="request"></param>
        /// <param name="newBeneficiaryBalance"></param>
        /// <returns></returns>
        private async Task AddBeneficiaryBalance(DebitCreditCommand request, BeneficiaryBalance newBeneficiaryBalance)
        {
            newBeneficiaryBalance.Id = 0;
            newBeneficiaryBalance.Balance = request.requestModel.Amount;
            newBeneficiaryBalance.RoleId = (int)RoleType.Beneficiary;
            newBeneficiaryBalance.BeneficiaryId = request.requestModel.BeneficiaryId;
            await unitOfWork.BeneficiaryBalanceRepository.AddAsync(newBeneficiaryBalance);
        }
    }
}
