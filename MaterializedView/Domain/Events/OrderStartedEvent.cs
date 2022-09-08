using MediatR;

namespace MaterializedView.Domain.Events
{
    public class OrderStartedEvent : INotification
    {
        public int OrderId { get; set; }

        public OrderStartedEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
