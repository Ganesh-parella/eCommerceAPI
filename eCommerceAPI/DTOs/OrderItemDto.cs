namespace eCommerceAPI.DTOs
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }  
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
