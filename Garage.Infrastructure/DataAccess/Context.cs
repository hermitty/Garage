﻿using Garage.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Garage.Infrastructure.DataAccess
{
    public class Context : DbContext
    {
        DbSet<Customer> Customer { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }
        DbSet<Job> Task { get; set; }
        DbSet<User> User { get; set; }

        public Context(DbContextOptions<Context> options)
              : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Vehicle>().ToTable("Vehicle").HasOne(v => v.Owner);
            builder.Entity<User>().ToTable("User").HasData(
                new User() {Id = 1, Login = "admin", Password = "12345", Role = Role.Admin}
                );
            builder.Entity<Job>().ToTable("Task").HasOne(v => v.Assignee);
            builder.Entity<Job>().ToTable("Task").HasOne(v => v.Vehicle);

            base.OnModelCreating(builder);
            //modelBuilder.Entity<Car>().ToTable("Car").HasOne(p => p.CarType);
            //modelBuilder.Entity<CarType>().ToTable("CarType").HasData(
            //    new CarType() { Id = 1, Name = "Sedan" },
            //    new CarType() { Id = 2, Name = "Combi" }
            //    );
        }
    }
}
