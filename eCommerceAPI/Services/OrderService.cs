using eCommerceAPI.DTOs;
using eCommerceAPI.Models;
using eCommerceAPI.Repositories;

namespace eCommerceAPI.Services
{
    public class OrderService:IOrderService
    {
      
            private readonly IOrderRepository _orderRepository;
            private readonly IOrderItemRepository _orderItemRepository;

            public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
            {
                _orderRepository = orderRepository;
                _orderItemRepository = orderItemRepository;
            }

            public async Task<IEnumerable<OrderDto>> GetAllAsync()
            {
                var orders = await _orderRepository.GetAllAsync();
                return orders.Select(order => new OrderDto
                {
                    OrderId = order.OrderId,
                    UserId = order.UserId,
                    TotalAmount = order.TotalAmount,
                    Status = order.Status,
                    OrderedOn = order.OrderedOn,
                    OrderItems = order.Orderitems?.Select(item => new OrderItemDto
                    {
                        OrderItemId = item.OrderItemId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    }).ToList()
                });
            }

            public async Task<OrderDto?> GetByIdAsync(int id)
            {
                var order = await _orderRepository.GetByIdAsync(id);
                if (order == null) return null;

                return new OrderDto
                {
                    OrderId = order.OrderId,
                    UserId = order.UserId,
                    TotalAmount = order.TotalAmount,
                    Status = order.Status,
                    OrderedOn = order.OrderedOn,
                    OrderItems = order.Orderitems?.Select(item => new OrderItemDto
                    {
                        OrderItemId = item.OrderItemId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    }).ToList()
                };
            }

            public async Task<OrderDto> CreateAsync(CreateOrderDto dto)
            {
                var order = new Order
                {
                    UserId = dto.UserId,
                    Status = "Pending",
                    OrderedOn = DateTime.UtcNow,
                    TotalAmount = 0,
                };

                await _orderRepository.AddAsync(order);
                await _orderRepository.SaveChangesAsync();

                decimal total = 0;
                foreach (var item in dto.OrderItems)
                {
                    var orderItem = new Orderitem
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };

                if (item.Quantity < 0 || item.Price < 0)
                {
                    total += 0;
                }else
                   total += item.Quantity * item.Price;
                   
                
                    await _orderItemRepository.AddAsync(orderItem);
                }

                order.TotalAmount = total;
                await _orderItemRepository.SaveChangesAsync();
                await _orderRepository.SaveChangesAsync();

                return await GetByIdAsync(order.OrderId) ?? throw new Exception("Order creation failed");
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var order = await _orderRepository.GetByIdAsync(id);
                if (order == null) return false;

                _orderRepository.Delete(order);
                return await _orderRepository.SaveChangesAsync();
            }
        public async Task<bool> UpdateAsync(int id, UpdateOrderDto dto)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return false;

            order.Status = dto.Status;
            order.TotalAmount = dto.TotalAmount; // Optional
            await _orderRepository.SaveChangesAsync();
            return true;
        }
    }
    }


