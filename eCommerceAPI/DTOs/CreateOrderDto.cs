using System.ComponentModel.DataAnnotations;

namespace eCommerceAPI.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public List<CreateOrderItemDto> OrderItems { get; set; } = new();

        public string? Status { get; set; } = "Pending";
    }
}
