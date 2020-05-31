using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {   
            // Entities exist in Product.cs
            // Lecture 2.11

        }

        // "Products" here is the name of the table that will be generated
        public DbSet<Product> Products { get; set; }
    }
}
