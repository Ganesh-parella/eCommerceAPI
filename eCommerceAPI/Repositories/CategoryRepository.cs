using eCommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ECommerceDbContext _context;

        public CategoryRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllAsync() =>
        await _context.Categories.ToListAsync();

        public async Task<Category?> GetByIdAsync(int id) =>
       await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);
        public async Task AddAsync(Category category) => await _context.Categories.AddAsync(category);

        public void Update(Category category) => _context.Categories.Update(category);

        public void Delete(Category category) => _context.Categories.Remove(category);
        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}
