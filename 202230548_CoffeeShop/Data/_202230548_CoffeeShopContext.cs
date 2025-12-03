using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _202230548_CoffeeShop.Models;

namespace _202230548_CoffeeShop.Data
{
    public class _202230548_CoffeeShopContext : DbContext
    {
        public _202230548_CoffeeShopContext (DbContextOptions<_202230548_CoffeeShopContext> options)
            : base(options)
        {
        }

        public DbSet<_202230548_CoffeeShop.Models.Customer> Customer { get; set; } = default!;
        public DbSet<_202230548_CoffeeShop.Models.Product> Product { get; set; } = default!;
        public DbSet<_202230548_CoffeeShop.Models.Sale> Sale { get; set; } = default!;
    }
}
