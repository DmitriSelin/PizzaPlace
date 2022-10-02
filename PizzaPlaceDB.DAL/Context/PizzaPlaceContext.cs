using Microsoft.EntityFrameworkCore;
using PizzaPlaceDB.DAL.Entities;

namespace PizzaPlaceDB.DAL.Context
{
    /// <summary>Db context</summary>
    public class PizzaPlaceContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Bonus> Bonuses { get; set; }

        public PizzaPlaceContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>Connecting to SQL server</summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=DIMITRY\SQLEXPRESS;Database=PizzaPlaceDb;Trusted_Connection=True;");
        }
    }
}