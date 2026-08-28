using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model
{
    public class StoreInfo
    {
        public string StoreName { get; set; } = "Supermarket Management";
        public string BranchName { get; set; } = "Main Branch";
        public string PhoneNumber { get; set; } = "+855 12 345 678";
        public string Email { get; set; } = "info@supermarket.com";
        public string Address { get; set; } = "Phnom Penh, Cambodia";
        public decimal TaxRate { get; set; } = 10.00m;
        public string CurrencySymbol { get; set; } = "$";
        public decimal ExchangeRate { get; set; } = 4100.00m;
        public string ReceiptHeader { get; set; } = "Thank you for shopping with us!";
        public string ReceiptFooter { get; set; } = "Goods sold are not returnable. Please keep your receipt.";
    }
}
