using System.ComponentModel.DataAnnotations;

namespace eCommerceAPI.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
       
        public string? Name { get; set; }
        public string? Description { get; set; }

        public bool? IsActive { get; set; }
    }
}
