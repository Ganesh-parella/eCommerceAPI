using eCommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.Products.Include(p => p.Category).ToListAsync();
        public async Task<Product?> GetByIdAsync(int id) =>
        await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
        public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);

        public void Update(Product product) => _context.Products.Update(product);

        public void Delete(Product product) => _context.Products.Remove(product);
        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}
