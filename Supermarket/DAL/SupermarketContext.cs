using System;
using System.Data.Entity;
using Supermarket.Model;

namespace Supermarket.DAL
{
    internal class SupermarketContext : DbContext
    {
        public SupermarketContext() : base(@"Server=.\SQLEXPRESS; Database=SupermarketManagement; User Id=sa; Password=123; TrustServerCertificate=True;")
        {
            Database.SetInitializer<SupermarketContext>(null);
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
    }
}
