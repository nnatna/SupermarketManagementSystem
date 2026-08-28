using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.Model;

namespace Supermarket.DAL
{
    public class DashboardSummaryDTO
    {
        public decimal TodaySales { get; set; }
        public int TodayOrders { get; set; }
        public decimal MonthlySales { get; set; }
        public int MonthlyOrders { get; set; }
        public int TotalProducts { get; set; }
        public int TotalCustomers { get; set; }
        public int LowStockCount { get; set; }
        public int OutOfStockCount { get; set; }
        public decimal TotalInventoryValue { get; set; }
    }

    public class ChartDataPointDTO
    {
        public string Label { get; set; }
        public decimal Value { get; set; }
        public int SecondaryValue { get; set; }
    }

    public class TopProductDTO
    {
        public string ProductName { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class CategoryShareDTO
    {
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalValue { get; set; }
    }

    public class RecentSaleDTO
    {
        public long Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }

    public class LowStockItemDTO
    {
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string CategoryName { get; set; }
        public int CurrentStock { get; set; }
        public int AlertLevel { get; set; }
        public string Status { get; set; }
    }

    internal class DashboardDAL
    {
        public async Task<DashboardSummaryDTO> GetSummaryMetricsAsync()
        {
            var summary = new DashboardSummaryDTO();

            try
            {
                using (var db = new SupermarketContext())
                {
                    DateTime today = DateTime.Today;
                    DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime tomorrow = today.AddDays(1);

                    // 1. Sales metrics (Fetch all recent completed sales)
                    var allSales = await db.Sales
                        .Where(s => s.Sale_date.HasValue)
                        .ToListAsync();

                    var activeSales = allSales
                        .Where(s => string.IsNullOrEmpty(s.Status) || !s.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    var todaySalesList = activeSales
                        .Where(s => s.Sale_date.Value >= today && s.Sale_date.Value < tomorrow)
                        .ToList();

                    summary.TodaySales = todaySalesList.Sum(s => s.Grand_total ?? 0m);
                    summary.TodayOrders = todaySalesList.Count;

                    var monthSalesList = activeSales
                        .Where(s => s.Sale_date.Value >= firstDayOfMonth && s.Sale_date.Value < tomorrow)
                        .ToList();

                    summary.MonthlySales = monthSalesList.Sum(s => s.Grand_total ?? 0m);
                    summary.MonthlyOrders = monthSalesList.Count;

                    // 2. Product & Inventory metrics
                    var products = await db.Products.ToListAsync();
                    summary.TotalProducts = products.Count;
                    summary.LowStockCount = products.Count(p => p.Stock_quantity > 0 && p.Stock_quantity <= p.Stock_alert_level);
                    summary.OutOfStockCount = products.Count(p => p.Stock_quantity <= 0);
                    summary.TotalInventoryValue = products.Sum(p => (decimal)p.Stock_quantity * p.Selling_price);

                    // 3. Customers
                    summary.TotalCustomers = await db.Customers.CountAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DashboardDAL Summary Error: " + ex.Message);
            }

            return summary;
        }

        public async Task<List<ChartDataPointDTO>> GetSalesTrendLast7DaysAsync()
        {
            var points = new List<ChartDataPointDTO>();

            try
            {
                using (var db = new SupermarketContext())
                {
                    DateTime today = DateTime.Today;
                    DateTime sevenDaysAgo = today.AddDays(-6);

                    var allSales = await db.Sales
                        .Where(s => s.Sale_date.HasValue && s.Sale_date.Value >= sevenDaysAgo)
                        .ToListAsync();

                    var activeSales = allSales
                        .Where(s => string.IsNullOrEmpty(s.Status) || !s.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    for (int i = -6; i <= 0; i++)
                    {
                        DateTime targetDate = today.AddDays(i);
                        string dayLabel = targetDate.ToString("ddd (MM/dd)");

                        var daySales = activeSales.Where(s => s.Sale_date.Value.Date == targetDate).ToList();
                        decimal dayTotal = daySales.Sum(s => s.Grand_total ?? 0m);
                        int count = daySales.Count;

                        points.Add(new ChartDataPointDTO
                        {
                            Label = dayLabel,
                            Value = dayTotal,
                            SecondaryValue = count
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DashboardDAL Trend Error: " + ex.Message);
            }

            return points;
        }

        public async Task<List<TopProductDTO>> GetTopSellingProductsAsync(int topCount = 5)
        {
            var list = new List<TopProductDTO>();

            try
            {
                using (var db = new SupermarketContext())
                {
                    var allDetails = await db.SalesDetails.ToListAsync();
                    var activeDetails = allDetails
                        .Where(sd => string.IsNullOrEmpty(sd.Status) || !sd.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                        .GroupBy(sd => sd.Product_id)
                        .Select(g => new
                        {
                            ProductId = g.Key,
                            TotalQuantity = g.Sum(x => x.Quantity),
                            TotalRevenue = g.Sum(x => x.Subtotal)
                        })
                        .OrderByDescending(x => x.TotalQuantity)
                        .Take(topCount)
                        .ToList();

                    var productIds = activeDetails.Select(d => d.ProductId).ToList();
                    var products = await db.Products.Where(p => productIds.Contains(p.Id)).ToDictionaryAsync(p => p.Id, p => p.Name);

                    foreach (var item in activeDetails)
                    {
                        string name = products.ContainsKey(item.ProductId) ? products[item.ProductId] : $"Product #{item.ProductId}";
                        list.Add(new TopProductDTO
                        {
                            ProductName = name,
                            TotalQuantitySold = item.TotalQuantity,
                            TotalRevenue = item.TotalRevenue
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DashboardDAL Top Products Error: " + ex.Message);
            }

            return list;
        }

        public async Task<List<CategoryShareDTO>> GetCategoryDistributionAsync()
        {
            var list = new List<CategoryShareDTO>();

            try
            {
                using (var db = new SupermarketContext())
                {
                    var categories = await db.Categories.ToListAsync();
                    var products = await db.Products.ToListAsync();

                    foreach (var cat in categories)
                    {
                        var catProds = products.Where(p => p.CategoryId == cat.CategoryId ||
                            string.Equals(p.Category, cat.CategoryName, StringComparison.OrdinalIgnoreCase)).ToList();

                        if (catProds.Count > 0)
                        {
                            list.Add(new CategoryShareDTO
                            {
                                CategoryName = cat.CategoryName,
                                ProductCount = catProds.Count,
                                TotalValue = catProds.Sum(p => (decimal)p.Stock_quantity * p.Selling_price)
                            });
                        }
                    }

                    // Add Uncategorized if any
                    var uncatProds = products.Where(p => !p.CategoryId.HasValue && string.IsNullOrWhiteSpace(p.Category)).ToList();
                    if (uncatProds.Count > 0)
                    {
                        list.Add(new CategoryShareDTO
                        {
                            CategoryName = "Other",
                            ProductCount = uncatProds.Count,
                            TotalValue = uncatProds.Sum(p => (decimal)p.Stock_quantity * p.Selling_price)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DashboardDAL Category Share Error: " + ex.Message);
            }

            return list;
        }

        public async Task<List<RecentSaleDTO>> GetRecentSalesAsync(int count = 10)
        {
            var list = new List<RecentSaleDTO>();

            try
            {
                using (var db = new SupermarketContext())
                {
                    var sales = await db.Sales
                        .OrderByDescending(s => s.Sale_date)
                        .Take(count)
                        .ToListAsync();

                    var customerIds = sales.Where(s => s.Customer_id.HasValue).Select(s => s.Customer_id.Value).Distinct().ToList();
                    var customers = await db.Customers.Where(c => customerIds.Contains(c.Id)).ToDictionaryAsync(c => c.Id, c => c.Name);

                    foreach (var s in sales)
                    {
                        string custName = "General Customer";
                        if (s.Customer_id.HasValue && customers.ContainsKey(s.Customer_id.Value))
                        {
                            custName = customers[s.Customer_id.Value];
                        }

                        list.Add(new RecentSaleDTO
                        {
                            Id = s.Id,
                            InvoiceNumber = s.Invoice_number,
                            CustomerName = custName,
                            SaleDate = s.Sale_date,
                            Amount = s.Grand_total ?? 0m,
                            PaymentMethod = s.Payment_method ?? "Cash",
                            Status = string.IsNullOrWhiteSpace(s.Status) ? "Completed" : s.Status
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DashboardDAL Recent Sales Error: " + ex.Message);
            }

            return list;
        }

        public async Task<List<LowStockItemDTO>> GetCriticalStockAlertsAsync(int count = 10)
        {
            var list = new List<LowStockItemDTO>();

            try
            {
                using (var db = new SupermarketContext())
                {
                    var lowStockProducts = await db.Products
                        .Where(p => p.Stock_quantity <= p.Stock_alert_level * 2)
                        .OrderBy(p => p.Stock_quantity)
                        .Take(count)
                        .ToListAsync();

                    foreach (var p in lowStockProducts)
                    {
                        string status = p.Stock_quantity == 0 ? "Out of Stock" : (p.Stock_quantity <= p.Stock_alert_level ? "Low Stock" : "Medium Stock");

                        list.Add(new LowStockItemDTO
                        {
                            ProductName = p.Name,
                            Barcode = p.Barcode,
                            CategoryName = string.IsNullOrWhiteSpace(p.Category) ? "General" : p.Category,
                            CurrentStock = p.Stock_quantity,
                            AlertLevel = p.Stock_alert_level,
                            Status = status
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DashboardDAL Stock Alerts Error: " + ex.Message);
            }

            return list;
        }
    }
}
