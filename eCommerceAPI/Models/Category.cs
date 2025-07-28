using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCommerceAPI.Models;

public partial class Category
{
    public int CategoryId { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
