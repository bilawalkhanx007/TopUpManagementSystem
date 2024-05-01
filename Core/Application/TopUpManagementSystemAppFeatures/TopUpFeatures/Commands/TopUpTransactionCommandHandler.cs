using Application.Features.BeneficiaryFeatures.Commands;
using Domain.Abstructions;
using Domain.Entities;
using Domain.Enum;
using Domain.ViewModel;
using MediatR;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Transactions;

namespace Application.Features.TopUpBeneficiaryFeatures.Commands
{
    /// <summary>
    /// This Will Call When TopUpTransaction API Occcured
    /// Handle All Business Logic here, related to Perform topUp transaction
    /// </summary>
    public class TopUpTransactionCommandHandler : IRequestHandler<TopUpTransactionCommand, ResponseViewModel>
    {
        /// <summary>
        /// unit Of Work single use to perform single Execution point of save changes.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;
        public IBalanceManangementAppService balanceManangementAppService { get; }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="_unitOfWork"></param>
        /// <param name="mapper"></param>
        public TopUpTransactionCommandHandler(IUnitOfWork _unitOfWork, IBalanceManangementAppService _balanceManangementAppService)
        {
            unitOfWork = _unitOfWork;
            balanceManangementAppService = _balanceManangementAppService;
        }

        /// <summary>
        /// Handler Process
        /// </summary>
        /// <param name="topUpTransaction"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> Handle(TopUpTransactionCommand topUpTransaction, CancellationToken cancellationToken)
        {
            var hetUserBalanceRequestViewModel = new GetUserBalanceRequestViewModel();
            hetUserBalanceRequestViewModel.UserId = topUpTransaction.requestModel.UserId;
            var oouserCurrentBalance = await balanceManangementAppService.GetBalance(hetUserBalanceRequestViewModel);

            //validate user Exist..
            var topUpTransactionResponse = new ResponseViewModel();
            var user = await unitOfWork.UserRepository.GetUser(topUpTransaction.requestModel.UserId, cancellationToken);
            if (user == null)
            {
                topUpTransactionResponse.Message = "user not found.";
                return topUpTransactionResponse;
            }

            //set total Topup limit accordig to User status: NotVerified => 1000, Verified => 500
            var maxMonthlyTotalTopUpTobeneficiary = (user.StatusID == (int)Domain.Enum.Status.NotVerified) ? 1000 : 500;

            //validate sending amount should be less then monthly limit
            if (topUpTransaction.requestModel.Amount > maxMonthlyTotalTopUpTobeneficiary)
            {
                topUpTransactionResponse.Message = $"User can top up a maximum of AED {maxMonthlyTotalTopUpTobeneficiary} per beneficiary per month.";
                return topUpTransactionResponse;
            }


            //gets per calendar month start and end date
            DateTime startDateOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDateOfMonth = startDateOfMonth.AddMonths(1).AddDays(-1);

            var userMonthlyTopUpTrasactionList = await unitOfWork.UserTopUpTrasactionRepository
                                                .GetUserMonthlyTopUpTrasaction(topUpTransaction.requestModel.UserId,
                                                                               startDateOfMonth ,endDateOfMonth);

            //Get all amount monthly transaction to validate user Overall Monthly Max limit Topup for all beneficiaries
            var totalTopUpThisMonth = userMonthlyTopUpTrasactionList.Sum(x => x.Amount);
            if (totalTopUpThisMonth + topUpTransaction.requestModel.Amount > 3000)
            {
                topUpTransactionResponse.Message = $"Exceeded maximum monthly top-up limit for all beneficiaries.";
                return topUpTransactionResponse;
            }

            //validate Single Beneficiary monthly top-up limit as per User status: NotVerified => 1000, Verified => 500
            var beneficiaryTotalTopUpThisMonth = userMonthlyTopUpTrasactionList
                                                  .Where(x => x.BeneficiaryID == topUpTransaction.requestModel.BeneficiaryID)
                                                  .Sum(x => x.Amount);

            if ((beneficiaryTotalTopUpThisMonth + topUpTransaction.requestModel.Amount) > maxMonthlyTotalTopUpTobeneficiary)
            {
                topUpTransactionResponse.Message = $"Exceeded maximum monthly top-up limit for Beneficiary.";
                return topUpTransactionResponse;
            }


            //Sent Http request to external services to get current user balance
            var transactionCharge = 1;
            var userCurrentBalance = await balanceManangementAppService.GetBalance(hetUserBalanceRequestViewModel);

            if ((topUpTransaction.requestModel.Amount + transactionCharge) > userCurrentBalance.Balance)
            {
                topUpTransactionResponse.Message = $"Insufficient balance.";
                return topUpTransactionResponse;
            }


            var debitCreditRequestViewModel = new DebitCreditRequestViewModel();
            if (topUpTransaction?.requestModel != null)
            {
                debitCreditRequestViewModel.InjectFrom(topUpTransaction?.requestModel);
            }

            // Sent Http request to External service to perform Debit Credit
            var response  = await balanceManangementAppService.DebitCreditExecution(debitCreditRequestViewModel);
            if (response.IsSucess)
            {
                //after sucessfully perform all transaction: store transaction logs.
                await AddUserTransactionLog(debitCreditRequestViewModel);

                int isExecuted = await unitOfWork.ApplySaveChanges();
                if (isExecuted > 0)
                {
                    topUpTransactionResponse.Message = "Transaction Sucessfully";
                    topUpTransactionResponse.IsSucess = true;
                }
            }

            return topUpTransactionResponse;
        }


        /// <summary>
        /// This Method is use to add User Transaction Log
        /// </summary>
        /// <param name="debitCreditRequestViewModel"></param>
        /// <returns></returns>
        private async Task AddUserTransactionLog(DebitCreditRequestViewModel debitCreditRequestViewModel)
        {
            var userTopUpTrasaction = new UserTopUpTrasaction();
            userTopUpTrasaction.Amount = debitCreditRequestViewModel.Amount;
            userTopUpTrasaction.TopUpChargeAmount = 1;
            userTopUpTrasaction.UserID = debitCreditRequestViewModel.UserId;
            userTopUpTrasaction.TopUpOptionID = 1;
            userTopUpTrasaction.BeneficiaryID = debitCreditRequestViewModel.BeneficiaryId;

            await unitOfWork.UserTopUpTrasactionRepository.AddAsync(userTopUpTrasaction);
        }
    }
}
