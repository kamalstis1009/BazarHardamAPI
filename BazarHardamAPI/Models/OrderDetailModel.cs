using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazarHardamAPI.Models
{
    public class OrderDetailModel
    {
        public List<ProductModel> Products { get; set; }
        public SSL_Address Address { get; set; }
        public string PaymentType { get; set; }
        public decimal Discount { get; set; }
    }
}