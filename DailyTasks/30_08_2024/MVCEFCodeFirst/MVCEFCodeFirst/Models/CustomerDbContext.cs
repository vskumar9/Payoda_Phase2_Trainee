﻿using Microsoft.EntityFrameworkCore;

namespace MVCEFCodeFirst.Models
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

    }
}
