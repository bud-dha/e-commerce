using System;
using System.Text;
using e_commerce.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace e_commerce.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ProductTypes> ProductTypes { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
