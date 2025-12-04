using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _202230548_CoffeeShop.Models;

public partial class City
{
    public Guid CityId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Province { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
