using System.ComponentModel.DataAnnotations;

namespace eCommerceAPI.DTOs
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Product name is required.")]
        [MaxLength(100, ErrorMessage = "Name can't exceed 100 characters.")]
        public string? Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Description can't exceed 1000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, 10000, ErrorMessage = "Quantity must be between 0 and 10,000.")]
        public int Quantity { get; set; }

        [MaxLength(200, ErrorMessage = "Image URL can't exceed 200 characters.")]
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
    }
}
