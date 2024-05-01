using Application.Features.BeneficiaryFeatures.Queries;
using Domain.Abstructions;
using Domain.ViewModel;
using MediatR;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TopUpBeneficiaryFeatures.Queries
{
    /// <summary>
    /// This Will Call When GetAllTopUpOption API Occcured
    /// Handle All Business Logic here, related to Get All TopUp Option
    /// </summary>
    public class GetAllTopUpOptionQueryHandler : IRequestHandler<GetAllTopUpOptionQuery, List<GetAllTopUpOptionResponse>>
    {
        /// <summary>
        /// unit Of Work single use to perform single Execution point of save changes.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="_unitOfWork"></param>
        /// <param name="mapper"></param>
        public GetAllTopUpOptionQueryHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        /// <summary>
        /// Handler Process
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GetAllTopUpOptionResponse>> Handle(GetAllTopUpOptionQuery request, CancellationToken cancellationToken)
        {
            var topUpOptionList = await unitOfWork.TopUpOptionRepository.GetAllAsync(cancellationToken);

            var responseList = new List<GetAllTopUpOptionResponse>();
            if (topUpOptionList != null && topUpOptionList.Count() > 0)
            {             
                foreach (var item in topUpOptionList)
                {
                    var topUpOption = new GetAllTopUpOptionResponse();
                    if (item != null)
                    {
                        topUpOption.Option = $"{item.Currency} {item.Amount}";
                        responseList.Add(topUpOption);
                    }
                }
            }

            return responseList;

        }
    }
}
