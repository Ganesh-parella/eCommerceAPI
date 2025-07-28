using System.ComponentModel.DataAnnotations;

namespace eCommerceAPI.DTOs
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(225)]
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
