using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazarHardamAPI.Models
{
    public class Inventory
    {
        public System.DateTime ChallanDate { get; set; }
        public string ChallanRef { get; set; }
        public long InvStoreId { get; set; }
        public long VendorId { get; set; }
        public string Remarks { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal CostUnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string VendorName { get; set; }

    }


    /*
public class Inventory
{
    public System.DateTime ChallanDate { get; set; }
    public string ChallanRef { get; set; }
    public string Remarks { get; set; }
    public List<InventoryDetails> Details { get; set; }

}

public class InventoryDetails
{
    public SSL_Vendor Vendor { get; set; }
    public SSL_InvStore InvStore { get; set; }
    public SSL_Product Product { get; set; }
    public decimal Quantity { get; set; }
    public decimal CostUnitPrice { get; set; }
    public decimal TotalAmount { get; set; }
}
     */
}