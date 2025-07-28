using eCommerceAPI.Models;

namespace eCommerceAPI.Repositories
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<Orderitem>> GetAllAsync();
        Task<Orderitem?> GetByIdAsync(int id);
        Task<IEnumerable<Orderitem>> GetByOrderIdAsync(int orderId);
        Task AddAsync(Orderitem orderItem);
        void Update(Orderitem orderItem);
        void Delete(Orderitem orderItem);
        Task<bool> SaveChangesAsync();
    }
}
