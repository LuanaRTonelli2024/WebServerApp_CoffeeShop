using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _202230548_CoffeeShop.Models;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    [StringLength(20)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string Address { get; set; } = null!;

    [StringLength(20)]
    public string City { get; set; } = null!;

    [MinLength(6)]
    [StringLength(6)]
    public string PostalCode { get; set; } = null!;

    [Phone]
    [StringLength(20)]
    public string PhoneNumber { get; set; } = null!;

    [CreditCard]
    [MinLength(16)]
    [StringLength(16)]
    public string CreditCardNumber { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
