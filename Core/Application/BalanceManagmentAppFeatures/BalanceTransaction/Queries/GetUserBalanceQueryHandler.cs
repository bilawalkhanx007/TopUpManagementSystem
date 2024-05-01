using Application.Features.BeneficiaryFeatures.Queries;
using Domain.Abstructions;
using Domain.Entities;
using Domain.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BalanceManagmentAppFeatures.BalanceTransaction.Queries
{
    /// <summary>
    /// This Will Call When GetUserBalance API Occcured
    /// Handle All Business Logic here, related to Check User current balance
    /// </summary>
    public class GetUserBalanceQueryHandler : IRequestHandler<GetUserBalanceQuery, GetUserBalanceResponse>
    {


        /// <summary>
        /// unit Of Work single use to perform single Execution point of save changes.
        /// </summary>
        private readonly IBalanceManagementAppUnitOfWork unitOfWork;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="_unitOfWork"></param>
        public GetUserBalanceQueryHandler(IBalanceManagementAppUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        /// <summary>
        /// Handler Process
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetUserBalanceResponse> Handle(GetUserBalanceQuery request, CancellationToken cancellationToken)
        {
           var response = new GetUserBalanceResponse();

            var userBalance = await unitOfWork.UserBalanceRepository.GetUserBalance(request.UserId);

            if(userBalance?.User != null)
                response.UserName = $"{userBalance.User.FirstNameEnglish} {userBalance.User.LastNameEnglish}";

            response.Balance = userBalance?.Balance?? 0;

            return response;
        }
    }
}
