using Application.Features.TopUpBeneficiaryFeatures.Commands;
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
    /// </summary>
    public class DebitCreditCommand : IRequest<ResponseViewModel>
    {

        /// <summary>
        /// Request Model
        /// </summary>
        public readonly DebitCreditRequestViewModel requestModel;


        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="requestModel"></param>
        public DebitCreditCommand(DebitCreditRequestViewModel requestModel)
        {
            this.requestModel = requestModel;
        }
    }
}
