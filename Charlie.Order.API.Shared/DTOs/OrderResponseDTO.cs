namespace Charlie.Order.API.Shared.DTOs;

public class OrderResponseDTO
{
    public string OrderId { get; set; }
    public string CustomerId { get; set; }
    public List<OrderProductDTO> Products { get; set; } = new();
}