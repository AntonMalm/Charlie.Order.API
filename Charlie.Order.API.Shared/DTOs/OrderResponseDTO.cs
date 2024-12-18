namespace Charlie.Order.API.Shared.DTOs;

public class OrderResponseDTO
{
    public string CorrelationId { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
}