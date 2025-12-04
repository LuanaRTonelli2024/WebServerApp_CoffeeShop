using System;
using System.Collections.Generic;

namespace _202230548_CoffeeShop.ModelsDb;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string CreditCardNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string? CityId { get; set; }
}
