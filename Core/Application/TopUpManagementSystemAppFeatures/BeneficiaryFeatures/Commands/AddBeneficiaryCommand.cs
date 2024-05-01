using Domain.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BeneficiaryFeatures.Commands
{
    /// <summary>
    /// This Will Call When AddBeneficiary API Occcured
    /// </summary>
    public class AddBeneficiaryCommand : IRequest<ResponseViewModel>
    {
        /// <summary>
        /// Request Model
        /// </summary>
        public readonly AddBeneficiaryViewModel requestModel;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="_requestModel"></param>
        /// <param name="cancellationToken"></param>
        public AddBeneficiaryCommand(AddBeneficiaryViewModel _requestModel, CancellationToken cancellationToken = default)
        {
            requestModel = _requestModel;
        }
    }
}
