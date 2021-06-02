using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazarHardamAPI.Models
{
    public class Inventory
    {
        public SSL_Vendor Vendor { get; set; }
        public SSL_Product Product { get; set; }
        public System.DateTime ChallanDate { get; set; }
        public string ChallanRef { get; set; }
        public int Quantity { get; set; }
        public decimal CostUnitPrice { get; set; }
        public decimal SaleUnitPrice { get; set; }
        public decimal TotalAmount { get; set; }

    }
}