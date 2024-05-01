using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BalanceManangementApp.Controllers
{
    /// <summary>
    /// This is Base controller to handle basic configuration
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        /// <summary>
        /// IMediator
        /// </summary>
        protected readonly IMediator _mediator;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="mediator"></param>
        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}
