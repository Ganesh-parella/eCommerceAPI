using eCommerceAPI.Models;

namespace eCommerceAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category Category);
        void Update(Category Category);
        void Delete(Category Category);
        Task<bool> SaveChangesAsync();
    }
}
