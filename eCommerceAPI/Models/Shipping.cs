using System;
using System.Collections.Generic;

namespace eCommerceAPI.Models;

public partial class Shipping
{
    public int ShippingId { get; set; }

    public int? OrderId { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? ShippingStatus { get; set; }

    public DateTime? ShippedOn { get; set; }

    public virtual Order? Order { get; set; }
}
