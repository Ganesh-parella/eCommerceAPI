using eCommerceAPI.DTOs;
using eCommerceAPI.Models;
using eCommerceAPI.Repositories;

namespace eCommerceAPI.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly ECommerceDbContext _context;

        public CategoryService(ICategoryRepository repository, ECommerceDbContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                IsActive = c.IsActive
            });
        }
       public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return null;
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive
            };

        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.IsActive ?? true
            };

            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();

            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return false;

            category.Name = dto.Name ?? category.Name;
            category.Description = dto.Description ?? category.Description;
            category.IsActive = dto.IsActive ?? category.IsActive;

            _repository.Update(category);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return false;

            _repository.Delete(category);
            return await _repository.SaveChangesAsync();
        }
    }
}
