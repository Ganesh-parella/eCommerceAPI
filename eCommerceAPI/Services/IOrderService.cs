using eCommerceAPI.DTOs;

namespace eCommerceAPI.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(int id);
        Task<OrderDto> CreateAsync(CreateOrderDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateOrderDto dto);
        
    }
}
