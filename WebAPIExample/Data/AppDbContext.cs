using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIExample.Models;

namespace WebAPIExample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPIExample.Models.Customer> Customers { get; set; } = default!;
        public DbSet<WebAPIExample.Models.Order> Orders { get; set; } = default!;
        public DbSet<WebAPIExample.Models.OrderLine> OrderLines { get; set; } = default!;
    }
}
