namespace MaterializedView.Domain.Entities
{
    public class OrderMaterializedView:Entity
    {
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalSold { get; set; }
        public string CustomerName { get;  set; }
    }
}
