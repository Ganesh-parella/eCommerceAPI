
    using eCommerceAPI.DTOs;
    using eCommerceAPI.Models;
    using eCommerceAPI.Repositories;
    using global::eCommerceAPI.DTOs;
    using global::eCommerceAPI.Models;
    using global::eCommerceAPI.Repositories;
    using Microsoft.EntityFrameworkCore;

    namespace eCommerceAPI.Services
    {
        public class ProductService : IProductService
        {
            private readonly IProductRepository _repository;
            private readonly ECommerceDbContext _context;

            public ProductService(IProductRepository repository, ECommerceDbContext context)
            {
                _repository = repository;
                _context = context;
            }

            public async Task<IEnumerable<ProductDto>> GetAllAsync()
            {
                var products = await _repository.GetAllAsync();

                return products.Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    ImageUrl = p.ImageUrl,
                    IsActive = p.IsActive,
                    CreatedOn = p.CreatedOn,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category?.Name
                });
            }

            public async Task<ProductDto?> GetByIdAsync(int id)
            {
                var product = await _repository.GetByIdAsync(id);
                if (product == null) return null;

                return new ProductDto
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ImageUrl = product.ImageUrl,
                    IsActive = product.IsActive,
                    CreatedOn = product.CreatedOn,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category?.Name
                };
            }

            public async Task<ProductDto> CreateAsync(CreateProductDto dto)
            {
                var product = new Product
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    ImageUrl = dto.ImageUrl,
                    IsActive = dto.IsActive,
                    CreatedOn = DateTime.UtcNow,
                    CategoryId = dto.CategoryId
                };

                await _repository.AddAsync(product);
                await _repository.SaveChangesAsync();

                return new ProductDto
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ImageUrl = product.ImageUrl,
                    IsActive = product.IsActive,
                    CreatedOn = product.CreatedOn,
                    CategoryId = product.CategoryId,
                    CategoryName = (await _context.Categories.FindAsync(product.CategoryId))?.Name
                };
            }

            public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
            {
                var product = await _repository.GetByIdAsync(id);
                if (product == null) return false;

                product.Name = dto.Name;
                product.Description = dto.Description;
                product.Price = dto.Price;
                product.Quantity = dto.Quantity;
                product.ImageUrl = dto.ImageUrl;
                product.IsActive = dto.IsActive;
                product.CategoryId = dto.CategoryId;

                _repository.Update(product);
                return await _repository.SaveChangesAsync();
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var product = await _repository.GetByIdAsync(id);
                if (product == null) return false;

                _repository.Delete(product);
                return await _repository.SaveChangesAsync();
            }
        }
    }


