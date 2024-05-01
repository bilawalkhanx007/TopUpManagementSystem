using Application.Features.BeneficiaryFeatures.Commands;
using Domain.Abstructions;
using Domain.ViewModel;
using MediatR;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BeneficiaryFeatures.Queries
{
    /// <summary>
    ///  This Will Call When ViewBeneficiaries API Occcured
    ///  Handle All Business Logic here, related to View All Beneficiaries
    /// </summary>
    public class ViewBeneficiariesQueryHandler : IRequestHandler<ViewBeneficiariesQuery, List<ViewBeneficiariesResponse>>
    {
        /// <summary>
        /// unit Of Work single use to perform single Execution point of save changes.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="_unitOfWork"></param>
        public ViewBeneficiariesQueryHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        /// <summary>
        /// Handler Process
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<ViewBeneficiariesResponse>> Handle(ViewBeneficiariesQuery request, CancellationToken cancellationToken)
        {
            var beneficaryList = await unitOfWork.BeneficiaryRepository.GetUserBeneficiaries(request.UserID, true);
            var responseList = new List<ViewBeneficiariesResponse>();

            if (beneficaryList != null && beneficaryList.Any())
            {
                beneficaryList.ForEach(item =>
                {
                    var beneficary = new ViewBeneficiariesResponse();

                    if (item != null)
                    {
                        beneficary.InjectFrom(item);
                        responseList.Add(beneficary);
                    }
                });
            }

            return responseList;
        }
    }
}
