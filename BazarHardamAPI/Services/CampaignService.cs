using BazarHardamAPI.Models;
using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BazarHardamAPI.Services
{
    public class CampaignService : ICampaignService
    {

        private readonly BazarHardamEntities _context = SQLDatabaseContext.Instance.GetDatabaseInstance();

        public async Task<Campaign> GetCampaign()
        {
            var sliders = await _context.SSL_CampaignSlider.Select(index => new Slider { ImageName = index.ImageName, ImagePath = index.ImagePath }).ToListAsync();

            var products = await (from A in _context.SSL_CampaignProductCategory
                            let list = (from B in _context.SSL_CampaignProduct join C in _context.SSL_Product on B.ProductId equals C.Id where B.CampProductCategoryId == A.Id select C).ToList()
                            select new CampaignProduct
                            {
                                Name = A.Name,
                                Description = A.Description,
                                Products = list
                            }).ToListAsync();

            var brands = await (from A in _context.SSL_CampaignBrandCategory
                                    //join B in _context.SSL_CampaignBrand on A.Id equals B.CampBrandCategoryId
                                    //let list = (from model in _context.SSL_Brand where model.Id == B.BrandId select model).ToList()
                                let list = (from B in _context.SSL_CampaignBrand join C in _context.SSL_Brand on B.BrandId equals C.Id where B.CampBrandCategoryId == A.Id select C).ToList()
                                select new CampaignBrand
                                  {
                                      Name = A.Name,
                                      Description = A.Description,
                                      Brands = list
                                  }).ToListAsync();

            return new Campaign
            {
                Slider = sliders,
                CampaignProduct = products,
                CampaignBrand = brands,
            };
        }

    }
}