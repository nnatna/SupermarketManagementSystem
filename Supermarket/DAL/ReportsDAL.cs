using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.Model;

namespace Supermarket.DAL
{
    // ==================== SALES REPORT DTOS ====================
    public class SalesReportSummaryDTO
    {
        public decimal TotalGrossSales { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalNetSales { get; set; }
        public int TotalTransactions { get; set; }
        public int TotalItemsSold { get; set; }
    }

    public class SalesReportItemDTO
    {
        public long SaleId { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime? SaleDate { get; set; }
        public int TotalItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }

    // ==================== INVENTORY REPORT DTOS ====================
    public class InventoryReportSummaryDTO
    {
        public int TotalProducts { get; set; }
        public int TotalStockQuantity { get; set; }
        public decimal TotalCostValue { get; set; }
        public decimal TotalRetailValue { get; set; }
        public decimal TotalPotentialProfit => TotalRetailValue - TotalCostValue;
        public int LowStockCount { get; set; }
        public int OutOfStockCount { get; set; }
    }

    public class InventoryReportItemDTO
    {
        public long ProductId { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public int AlertLevel { get; set; }
        public decimal TotalCost => (decimal)StockQuantity * CostPrice;
        public decimal TotalValue => (decimal)StockQuantity * SellingPrice;
        public decimal Margin => SellingPrice > 0 ? ((SellingPrice - CostPrice) / SellingPrice) * 100m : 0m;
        public string Status { get; set; }
    }

    // ==================== PROFIT & LOSS DTOS ====================
    public class ProfitLossSummaryDTO
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalCostOfGoods { get; set; }
        public decimal GrossProfit => TotalRevenue - TotalCostOfGoods;
        public decimal ProfitMargin => TotalRevenue > 0 ? (GrossProfit / TotalRevenue) * 100m : 0m;
        public int TotalSalesCount { get; set; }
        public int TotalProductsSold { get; set; }
    }

    public class ProfitLossItemDTO
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal GrossProfit => TotalRevenue - TotalCost;
        public decimal MarginPercent => TotalRevenue > 0 ? (GrossProfit / TotalRevenue) * 100m : 0m;
    }

    internal class ReportsDAL
    {
        // ==================== 1. SALES REPORT ====================
        public async Task<List<SalesReportItemDTO>> GetSalesReportAsync(DateTime startDate, DateTime endDate, string paymentMethod = null, string status = null)
        {
            var result = new List<SalesReportItemDTO>();

            try
            {
                using (var db = new SupermarketContext())
                {
                    DateTime start = startDate.Date;
                    DateTime end = endDate.Date.AddDays(1);

                    var sales = await db.Sales
                        .Where(s => s.Sale_date.HasValue && s.Sale_date.Value >= start && s.Sale_date.Value < end)
                        .OrderByDescending(s => s.Sale_date)
                        .ToListAsync();

                    if (!string.IsNullOrWhiteSpace(paymentMethod) && !paymentMethod.StartsWith("All", StringComparison.OrdinalIgnoreCase))
                    {
                        sales = sales.Where(s => string.Equals(s.Payment_method, paymentMethod, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(status) && !status.StartsWith("All", StringComparison.OrdinalIgnoreCase))
                    {
                        sales = sales.Where(s => string.Equals(s.Status, status, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    var saleIds = sales.Select(s => s.Id).ToList();
                    var details = await db.SalesDetails
                        .Where(sd => saleIds.Contains(sd.Sale_id))
                        .ToListAsync();

                    var customerIds = sales.Where(s => s.Customer_id.HasValue).Select(s => s.Customer_id.Value).Distinct().ToList();
                    var customers = await db.Customers
                        .Where(c => customerIds.Contains(c.Id))
                        .ToDictionaryAsync(c => c.Id, c => c.Name);

                    foreach (var s in sales)
                    {
                        var saleDetails = details.Where(d => d.Sale_id == s.Id).ToList();
                        string custName = s.Customer_id.HasValue && customers.ContainsKey(s.Customer_id.Value)
                            ? customers[s.Customer_id.Value]
                            : "General Customer";

                        result.Add(new SalesReportItemDTO
                        {
                            SaleId = s.Id,
                            InvoiceNumber = s.Invoice_number,
                            CustomerName = custName,
                            SaleDate = s.Sale_date,
                            TotalItems = saleDetails.Sum(d => d.Quantity),
                            Subtotal = s.Subtotal ?? 0m,
                            Discount = s.Discount_amount ?? 0m,
                            GrandTotal = s.Grand_total ?? 0m,
                            PaymentMethod = s.Payment_method ?? "Cash",
                            Status = string.IsNullOrWhiteSpace(s.Status) ? "Completed" : s.Status
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetSalesReportAsync Error: " + ex.Message);
            }

            return result;
        }

        // ==================== 2. INVENTORY REPORT ====================
        public async Task<List<InventoryReportItemDTO>> GetInventoryReportAsync(string categoryFilter = null, string stockStatusFilter = null)
        {
            var result = new List<InventoryReportItemDTO>();

            try
            {
                using (var db = new SupermarketContext())
                {
                    var products = await db.Products.ToListAsync();
                    var categories = await db.Categories.ToDictionaryAsync(c => c.CategoryId, c => c.CategoryName);

                    foreach (var p in products)
                    {
                        string catName = p.CategoryId.HasValue && categories.ContainsKey(p.CategoryId.Value)
                            ? categories[p.CategoryId.Value]
                            : (!string.IsNullOrWhiteSpace(p.Category) ? p.Category : "General");

                        string status = p.Stock_quantity <= 0 ? "Out of Stock" : (p.Stock_quantity <= p.Stock_alert_level ? "Low Stock" : "Normal");

                        result.Add(new InventoryReportItemDTO
                        {
                            ProductId = p.Id,
                            Barcode = p.Barcode,
                            ProductName = p.Name,
                            CategoryName = catName,
                            CostPrice = p.Cost_price,
                            SellingPrice = p.Selling_price,
                            StockQuantity = p.Stock_quantity,
                            AlertLevel = p.Stock_alert_level,
                            Status = status
                        });
                    }

                    if (!string.IsNullOrWhiteSpace(categoryFilter) && !categoryFilter.StartsWith("All", StringComparison.OrdinalIgnoreCase))
                    {
                        result = result.Where(r => string.Equals(r.CategoryName, categoryFilter, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(stockStatusFilter) && !stockStatusFilter.StartsWith("All", StringComparison.OrdinalIgnoreCase))
                    {
                        result = result.Where(r => string.Equals(r.Status, stockStatusFilter, StringComparison.OrdinalIgnoreCase)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetInventoryReportAsync Error: " + ex.Message);
            }

            return result;
        }

        // ==================== 3. PROFIT & LOSS REPORT ====================
        public async Task<Tuple<ProfitLossSummaryDTO, List<ProfitLossItemDTO>>> GetProfitLossReportAsync(DateTime startDate, DateTime endDate)
        {
            var summary = new ProfitLossSummaryDTO();
            var items = new List<ProfitLossItemDTO>();

            try
            {
                using (var db = new SupermarketContext())
                {
                    DateTime start = startDate.Date;
                    DateTime end = endDate.Date.AddDays(1);

                    var sales = await db.Sales
                        .Where(s => s.Sale_date.HasValue && s.Sale_date.Value >= start && s.Sale_date.Value < end)
                        .ToListAsync();

                    var activeSales = sales
                        .Where(s => string.IsNullOrEmpty(s.Status) || !s.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    var activeSaleIds = activeSales.Select(s => s.Id).ToList();

                    var details = await db.SalesDetails
                        .Where(sd => activeSaleIds.Contains(sd.Sale_id))
                        .ToListAsync();

                    var activeDetails = details
                        .Where(sd => string.IsNullOrEmpty(sd.Status) || !sd.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    var productIds = activeDetails.Select(d => d.Product_id).Distinct().ToList();
                    var products = await db.Products
                        .Where(p => productIds.Contains(p.Id))
                        .ToListAsync();

                    var categories = await db.Categories.ToDictionaryAsync(c => c.CategoryId, c => c.CategoryName);

                    var grouped = activeDetails.GroupBy(d => d.Product_id).ToList();

                    foreach (var g in grouped)
                    {
                        var prod = products.FirstOrDefault(p => p.Id == g.Key);
                        string prodName = prod != null ? prod.Name : $"Product #{g.Key}";
                        string catName = "General";
                        if (prod != null && prod.CategoryId.HasValue && categories.ContainsKey(prod.CategoryId.Value))
                        {
                            catName = categories[prod.CategoryId.Value];
                        }
                        else if (prod != null && !string.IsNullOrWhiteSpace(prod.Category))
                        {
                            catName = prod.Category;
                        }

                        decimal costPerUnit = prod != null ? prod.Cost_price : 0m;
                        int totalQty = g.Sum(x => x.Quantity);
                        decimal totalRev = g.Sum(x => x.Subtotal);
                        decimal totalCost = totalQty * costPerUnit;

                        items.Add(new ProfitLossItemDTO
                        {
                            ProductId = g.Key,
                            ProductName = prodName,
                            CategoryName = catName,
                            QuantitySold = totalQty,
                            TotalRevenue = totalRev,
                            TotalCost = totalCost
                        });
                    }

                    items = items.OrderByDescending(i => i.GrossProfit).ToList();

                    summary.TotalRevenue = items.Sum(i => i.TotalRevenue);
                    summary.TotalCostOfGoods = items.Sum(i => i.TotalCost);
                    summary.TotalSalesCount = activeSales.Count;
                    summary.TotalProductsSold = items.Sum(i => i.QuantitySold);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetProfitLossReportAsync Error: " + ex.Message);
            }

            return Tuple.Create(summary, items);
        }
    }
}
