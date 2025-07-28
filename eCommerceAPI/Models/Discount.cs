using System;
using System.Collections.Generic;

namespace eCommerceAPI.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool? IsActive { get; set; }
}
