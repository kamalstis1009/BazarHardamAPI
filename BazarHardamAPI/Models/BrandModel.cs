using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazarHardamAPI.Models
{
    public class BrandModel
    {
        public SSL_Brand Brand { get; set; }
        public SSL_BrandCategory BrandCategory { get; set; }
    }
}