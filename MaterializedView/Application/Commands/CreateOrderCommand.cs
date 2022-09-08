using MaterializedView.Domain.Entities;
using MediatR;

namespace MaterializedView.Application.Commands;
public class CreateOrderCommand : IRequest
{
    public DateTime OrderData { get; set; }
    public string ShippingAddress { get; set; }
    public decimal TotalInvoice { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public int CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}