using Application.Features.BeneficiaryFeatures.Commands;
using Application.Features.BeneficiaryFeatures.Queries;
using Domain.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace TopUpManagementSystemApp.Controllers.v1
{
    /// <summary>
    /// Beneficiary controller responsible To Handle Operation Related to Beneficiaries Action
    /// </summary>
    [ApiVersion("1.0")]
    public class BeneficiaryController : BaseApiController
    {
        /// <summary>
        /// Cotructor
        /// </summary>
        /// <param name="mediator">Inject Mediator</param>
        public BeneficiaryController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// This API is Responsible To Add Beneficiaries
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBeneficiary")]
        public async Task<IActionResult> AddBeneficiary(AddBeneficiaryViewModel requestModel, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new AddBeneficiaryCommand(requestModel, cancellationToken));

            if(result.IsSucess)
                return Ok(result);
            else
                return BadRequest(result);
        }


        /// <summary>
        /// This API is Responsible To View Beneficiaries 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ViewBeneficiaries")]
        public async Task<IActionResult> ViewBeneficiaries([FromQuery] ViewBeneficiariesRequestViewModel requestModel, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new ViewBeneficiariesQuery(requestModel.UserID, cancellationToken));
            return Ok(result);
        }
    }
}
