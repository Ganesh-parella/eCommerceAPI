namespace eCommerceAPI.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; }
        public DateTime? OrderedOn { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
