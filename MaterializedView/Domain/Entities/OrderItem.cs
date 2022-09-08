namespace MaterializedView.Domain.Entities;

public class OrderItem : Entity
{
    public OrderItem(string product, decimal unitPrice, int amount, decimal total)
    {
        Product = product;
        UnitPrice = unitPrice;
        Amount = amount;
        Total = total;
    }

    public string Product { get; set; }
    public decimal UnitPrice { get; set; }
    public int Amount { get; set; }
    public decimal Total { get; set; }
}