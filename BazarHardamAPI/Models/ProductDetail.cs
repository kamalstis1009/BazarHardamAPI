using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazarHardamAPI.Models
{
    public class ProductDetail
    {
        public SSL_Brand Brand { get; set; }
        public List<SSL_Description> Description { get; set; }
        public List<SSL_Specification> Specification { get; set; }
    }
}