using Application.Features.BeneficiaryFeatures.Queries;
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
    ///  This Will Call When GetUserBalance API Occcured
    /// </summary>
    public class GetUserBalanceQuery : IRequest<GetUserBalanceResponse>
    {
        /// <summary>
        /// UserId
        /// </summary>
        public long UserId { get; set; }


        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="userId"></param>
        public GetUserBalanceQuery(long userId)
        {
            UserId = userId;
        }
    }
}
