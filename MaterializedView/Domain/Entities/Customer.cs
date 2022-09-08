namespace MaterializedView.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; set; }
    public string BillingInformation { get; set; }
    public string ShippingAddress { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
}