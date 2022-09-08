using MaterializedView.Data;
using MaterializedView.Domain.Entities;
using MaterializedView.Domain.Events;
using MediatR;

namespace MaterializedView.Application.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly WriteDbContext _context;
    private readonly IMediator _mediator;

    public CreateOrderCommandHandler(WriteDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = new (orderData: request.OrderData,
                              shippingAddress: request.ShippingAddress,
                              orderStatus: request.OrderStatus,
                              customerId: request.CustomerId);
        foreach (var item in request.OrderItems)
        {
            order.AddOrderItem(item);
        }
        _context.Orders.Add(order);

        await _context.SaveChangesAsync();
        await _mediator.Publish(new OrderStartedEvent(order.Id));

        return default;
    }
}