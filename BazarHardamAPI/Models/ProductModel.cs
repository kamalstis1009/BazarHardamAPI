using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazarHardamAPI.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public Nullable<long> BrandId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ProductUnitId { get; set; }
        public decimal SaleUnitPrice { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; }
        public System.Guid CreateUser { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.Guid> EditUser { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public string OCode { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}