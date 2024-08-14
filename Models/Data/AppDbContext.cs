using Microsoft.EntityFrameworkCore;
using SmallEcommerceProject.Models.Data.config;
using System;
namespace SmallEcommerceProject.Models.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfigurations).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configurations = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var constr = configurations.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }
    }
}
