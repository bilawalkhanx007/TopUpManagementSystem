using Application.BalanceManagmentAppFeatures.BalanceTransaction.Commands;
using Application.BalanceManagmentAppFeatures.BalanceTransaction.Queries;
using Domain.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace BalanceManangementApp.Controllers.v1
{

    /// <summary>
    /// BalanceTransaction controller responsible To Handle Operation Related to Debit,Credit and balance Action
    /// </summary>
    [ApiVersion("1.0")]
    public class BalanceTransactionController : BaseApiController
    {
        /// <summary>
        /// Cotructor
        /// </summary>
        /// <param name="mediator">Inject Mediator</param>
        public BalanceTransactionController(IMediator mediator) : base(mediator) { }



        /// <summary>
        ///  This API is Responsible To Get User balance
        /// </summary>
        /// <param name="getUserBalanceViewModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserBalance")]
        public async Task<IActionResult> GetUserBalance(GetUserBalanceRequestViewModel getUserBalanceViewModel)
        {
            var result = await _mediator.Send(new GetUserBalanceQuery(getUserBalanceViewModel.UserId));
            return Ok(result);
        }

        /// <summary>
        /// This API is Responsible To perform Debit Credit
        /// </summary>
        /// <param name="debitCreditRequestViewModel"></param>
        /// <returns></returns>
        [HttpPost("DebitCreaditTransaction")]
        public async Task<IActionResult> DebitCreditTransaction(DebitCreditRequestViewModel debitCreditRequestViewModel)
        {
            var result = await _mediator.Send(new DebitCreditCommand(debitCreditRequestViewModel));
            return Ok(result);
        }

    }
}
