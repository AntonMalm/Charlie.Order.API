namespace Charlie.Order.API.Shared.DataModels;

public class OrderModel
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public List<OrderProduct> Products { get; set; }
    public decimal TotalPrice => Products?.Sum(p => p.Price * p.Quantity) ?? 0;
}