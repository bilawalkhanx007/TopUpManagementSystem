using Application.Features.BeneficiaryFeatures.Commands;
using Domain.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BeneficiaryFeatures.Queries
{

    /// <summary>
    ///  This Will Call When ViewBeneficiaries API Occcured
    /// </summary>
    public class ViewBeneficiariesQuery : IRequest<List<ViewBeneficiariesResponse>>
    {
        /// <summary>
        /// UserId
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="cancellationToken"></param>
        public ViewBeneficiariesQuery(long userID, CancellationToken cancellationToken = default)
        {
            UserID = userID;
        }
    }
}
