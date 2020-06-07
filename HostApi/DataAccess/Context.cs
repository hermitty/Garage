using Garage.Services.CustomerManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace Garage.HostApi.DataAccess
{
    public class Context : DbContext
    {
        DbSet<Customer> Customer { get; set; }

        public Context(DbContextOptions<Context> options)
              : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasKey(m => m.CustomerId);
            builder.Entity<Customer>().ToTable("Customer");
            base.OnModelCreating(builder);
            //modelBuilder.Entity<Car>().ToTable("Car").HasOne(p => p.CarType);
            //modelBuilder.Entity<CarType>().ToTable("CarType").HasData(
            //    new CarType() { Id = 1, Name = "Sedan" },
            //    new CarType() { Id = 2, Name = "Combi" }
            //    );
        }
    }
}
