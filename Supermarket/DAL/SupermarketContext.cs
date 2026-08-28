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
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<vw_SaleHistory> vw_SaleHistory { get; set; }
        public DbSet<StockAdjustments> StockAdjustments { get; set; }
        public DbSet<vw_Stock_adjustments> vw_Stock_adjustments { get; set; }
        public DbSet<vw_StockAlert> vw_StockAlerts { get; set; }
        public DbSet<vw_PurchasesOrder> vw_PurchasesOrders { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
    }
}
