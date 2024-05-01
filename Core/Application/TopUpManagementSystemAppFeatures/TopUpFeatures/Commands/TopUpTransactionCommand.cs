using Application.Features.BeneficiaryFeatures.Commands;
using Domain.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TopUpBeneficiaryFeatures.Commands
{
    /// <summary>
    ///  This Will Call When TopUpTransaction API Occcured
    /// </summary>
    public class TopUpTransactionCommand : IRequest<ResponseViewModel>
    {
        /// <summary>
        /// Request Model
        /// </summary>
        public readonly TopUpTransactionRequestViewModel requestModel;

        /// <summary>
        /// Handler Process
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="cancellationToken"></param>
        public TopUpTransactionCommand(TopUpTransactionRequestViewModel requestModel, CancellationToken cancellationToken = default)
        {
            this.requestModel = requestModel;
        }
    }
}
