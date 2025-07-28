using eCommerceAPI.DTOs;
using eCommerceAPI.Models;
using eCommerceAPI.Repositories;

namespace eCommerceAPI.Services
{
    public class OrderItemService:IOrderItemService
    {
        private readonly IOrderItemRepository _repository;
        public OrderItemService(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(i => new OrderItemDto
            {
                OrderItemId = i.OrderItemId,
                OrderId=(int)i.OrderId,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Price = i.Price,
                ProductName = i.Product?.Name
            });
        }

        public async Task<OrderItemDto?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;

            return new OrderItemDto
            {
                OrderItemId = item.OrderItemId,
                OrderId =(int) item.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price,
                ProductName = item.Product?.Name
            };
        }

        public async Task<IEnumerable<OrderItemDto>> GetByOrderIdAsync(int orderId)
        {
            var items = await _repository.GetByOrderIdAsync(orderId);
            return items.Select(i => new OrderItemDto
            {
                OrderItemId = i.OrderItemId,
                OrderId =(int) i.OrderId,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Price = i.Price,
                ProductName = i.Product?.Name
            });
        }
        public async Task<OrderItemDto> CreateAsync(CreateOrderItemDto dto)
        {
            var item = new Orderitem
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Price = dto.Price
            };

            await _repository.AddAsync(item);
            await _repository.SaveChangesAsync();

            return new OrderItemDto
            {
                OrderItemId = item.OrderItemId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return false;

            _repository.Delete(item);
            return await _repository.SaveChangesAsync();
        }

    }
}
