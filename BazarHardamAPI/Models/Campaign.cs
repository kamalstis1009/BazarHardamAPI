using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazarHardamAPI.Models
{
    public class Campaign
    {
        public List<Slider> Slider { get; set; }
        public List<CampaignProduct> CampaignProduct { get; set; }
        public List<CampaignBrand> CampaignBrand { get; set; }
    }

    public class Slider
    {
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }

    public class CampaignProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SSL_Product> Products { get; set; }
    }

    public class CampaignBrand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SSL_Brand> Brands { get; set; }
    }

}