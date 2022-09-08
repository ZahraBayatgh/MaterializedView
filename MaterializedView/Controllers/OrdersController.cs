using MaterializedView.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaterializedView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostOrder(CreateOrderCommand order)
        {
            await _mediator.Send(order);
            return Ok();
        }

    }
}
