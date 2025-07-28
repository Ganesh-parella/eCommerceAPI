using System.ComponentModel.DataAnnotations;

namespace eCommerceAPI.DTOs
{
    public class CreateOrderItemDto
    {
        [Required]
        public int OrderId {  get; set; }
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
