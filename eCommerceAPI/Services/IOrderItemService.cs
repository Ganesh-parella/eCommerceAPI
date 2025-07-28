using eCommerceAPI.DTOs;

namespace eCommerceAPI.Services
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetAllAsync();
        Task<OrderItemDto?> GetByIdAsync(int id);
        Task<IEnumerable<OrderItemDto>> GetByOrderIdAsync(int orderId);
        Task<OrderItemDto> CreateAsync(CreateOrderItemDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
