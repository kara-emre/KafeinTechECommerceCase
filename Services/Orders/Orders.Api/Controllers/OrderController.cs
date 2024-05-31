using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Commands;
using Orders.Application.Reponses;
using System.Net;
using System.Security.Claims;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        [Route("CreateOrder")]
        [ProducesResponseType(typeof(CreatedOrderResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatedOrderResponse>> CreateProduct([FromBody] CreateOrderCommand orderCommand)
        {
            _logger.LogInformation("Order Started");

            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int parsedUserId))
            {
                orderCommand.UserId = parsedUserId;
                orderCommand.Address = User.FindFirstValue(ClaimTypes.StreetAddress) ?? "Address Not Found";
                orderCommand.Name = User.FindFirstValue(ClaimTypes.Name) ?? "Name Not Found";
                orderCommand.EMail = User.FindFirstValue(ClaimTypes.Email) ?? "Email Not Found";
            }
            else
                return StatusCode((int)HttpStatusCode.Forbidden, "Invalid Authorization");

            orderCommand.UserId = parsedUserId;
            CreatedOrderResponse result = await _mediator.Send(orderCommand);

            return Ok(result);
        }

    }
}
