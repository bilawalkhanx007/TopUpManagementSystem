using Application.Features.BeneficiaryFeatures.Queries;
using Domain.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TopUpBeneficiaryFeatures.Queries
{
    /// <summary>
    ///  This Will Call When GetAllTopUpOption API Occcured
    /// </summary>
    public class GetAllTopUpOptionQuery : IRequest<List<GetAllTopUpOptionResponse>>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="cancellationToken"></param>
        public GetAllTopUpOptionQuery(CancellationToken cancellationToken = default)
        {
            
        }
    }
}
