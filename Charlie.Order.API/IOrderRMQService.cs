using Charlie.Order.API.Shared.DTOs;

namespace Charlie.Order.API;

public interface IOrderRMQService
{
    Task<OrderResponseDTO> CreateOrderAsync(OrderRequestDTO orderRequest);
}