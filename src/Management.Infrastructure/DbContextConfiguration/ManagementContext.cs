﻿using Management.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.Infrastructure.DbContextConfiguration
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Adresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
