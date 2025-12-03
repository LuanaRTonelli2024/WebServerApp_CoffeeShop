using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _202230548_CoffeeShop.Models;

public partial class Sale
{
    public Guid SaleId { get; set; }

    [FutureDateAttribute]
    public DateOnly Date { get; set; }

    [StringLength(200)]
    public string Comment { get; set; } = null!;

    public Guid CustomerId { get; set; }

    public Guid ProductId { get; set; }

    public virtual Customer? Customer { get; set; } = null!;

    public virtual Product? Product { get; set; } = null!;
}
