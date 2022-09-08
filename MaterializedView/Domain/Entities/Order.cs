namespace MaterializedView.Domain.Entities;

public class Order : Entity
{
    public Order(DateTime orderData, string shippingAddress, OrderStatus orderStatus, int customerId)
    {
        OrderData = orderData;
        ShippingAddress = shippingAddress;
        OrderStatus = orderStatus;
        CustomerId = customerId;
        OrderItems = new List<OrderItem>();
    }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderData { get; set; }
    public string ShippingAddress { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }

    public void AddOrderItem(OrderItem orderItem)
    {
        OrderItems.Add(orderItem);
    }
}