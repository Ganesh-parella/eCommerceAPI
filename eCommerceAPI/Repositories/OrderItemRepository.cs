using eCommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.Repositories
{
    public class OrderItemRepository: IOrderItemRepository
    {

        private readonly ECommerceDbContext _context;

        public OrderItemRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Orderitem>> GetAllAsync()
        {
            return await _context.Orderitems.Include(o => o.Product).ToListAsync();
        }

        public async Task<Orderitem?> GetByIdAsync(int id)
        {
            return await _context.Orderitems
                .Include(o => o.Product)
                .FirstOrDefaultAsync(o => o.OrderItemId == id);
        }

        public async Task<IEnumerable<Orderitem>> GetByOrderIdAsync(int orderId)
        {
            return await _context.Orderitems
                .Where(oi => oi.OrderId == orderId)
                .Include(o => o.Product)
                .ToListAsync();
        }

        public async Task AddAsync(Orderitem orderItem)
        {
            await _context.Orderitems.AddAsync(orderItem);
        }

        public void Update(Orderitem orderItem)
        {
            _context.Orderitems.Update(orderItem);
        }

        public void Delete(Orderitem orderItem)
        {
            _context.Orderitems.Remove(orderItem);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
