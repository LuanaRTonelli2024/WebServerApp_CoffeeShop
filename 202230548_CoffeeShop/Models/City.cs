using System;
using System.Collections.Generic;

namespace _202230548_CoffeeShop.Models;

public partial class City
{
    public Guid CityId { get; set; }

    public string Name { get; set; } = null!;

    public string Province { get; set; } = null!;
}
