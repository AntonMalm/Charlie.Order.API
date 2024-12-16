namespace Charlie.Order.API.Shared.DataModels;

public class OrderModel
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public List<int> ProductIds { get; set; }
    public decimal TotalPrice { get; set; }
}