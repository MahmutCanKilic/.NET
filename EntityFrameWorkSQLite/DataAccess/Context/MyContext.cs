using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(car => car.ID);
            modelBuilder.Entity<Bus>().HasKey(bus => bus.ID);
            modelBuilder.Entity<Customer>().HasKey(customer => customer.ID);
            modelBuilder.Entity<Car>().HasOne(x => x.Customer).WithMany(x => x.CustomerCars).HasForeignKey(x => x.CustomerID);
            modelBuilder.Entity<Bus>().HasOne(x => x.Customer).WithMany(x => x.CustomerBuses).HasForeignKey(x => x.CustomerID);

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
}
