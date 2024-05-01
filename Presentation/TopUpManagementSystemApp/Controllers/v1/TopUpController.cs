using Application.Features.BeneficiaryFeatures.Queries;
using Application.Features.TopUpBeneficiaryFeatures.Commands;
using Application.Features.TopUpBeneficiaryFeatures.Queries;
using Domain.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TopUpManagementSystemApp.Controllers.v1
{
    /// <summary>
    /// TopUp  controller responsible To Handle Operation Related to TopUp Action
    /// </summary>
    [ApiVersion("1.0")]
    public class TopUpController : BaseApiController
    {

        /// <summary>
        /// Cotructor
        /// </summary>
        /// <param name="mediator">Inject Mediator</param>
        public TopUpController(IMediator mediator) : base(mediator) { }


        /// <summary>
        /// This API is Responsible To View All Top Up Options
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllTopUpOptions")]
        public async Task<IActionResult> GetAllTopUpOptions(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllTopUpOptionQuery(cancellationToken));

            if (result != null && result.Count > 0)
                return Ok(result);
            else
                return NotFound();
        }

        /// <summary>
        /// This API is Responsible To Perform Topup
        /// </summary>
        /// <param name="topUpTransactionRequestViewModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TopUpTransaction")]
        public async Task<IActionResult> TopUpTransaction(TopUpTransactionRequestViewModel topUpTransactionRequestViewModel, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new TopUpTransactionCommand(topUpTransactionRequestViewModel, cancellationToken));
            return Ok(result);
        }


    }
}
