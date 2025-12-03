using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _202230548_CoffeeShop.Models;

public partial class Product
{
    public Guid ProductId { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [Range(0, 2500.00)]
    public decimal Price { get; set; }

    [Range(0, 120)]
    public byte AvailableQuantity { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
