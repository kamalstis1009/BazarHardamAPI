using BazarHardamAPI.Models;
using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarHardamAPI.Services
{
    public interface IBrandService
    {
        Task<int> AddBrand(SSL_Brand model);
        Task<int> AddAllBrands(List<SSL_Brand> models);
        Task<int> DeleteBrandById(long id);
        Task<List<BrandModel>> GetAllBrands();
        Task<SSL_Brand> GetBrandById(long id);
        Task<int> UpdateBrandById(long id, SSL_Brand model);

        Task<int> AddBrandCategory(SSL_BrandCategory model);
        Task<List<SSL_BrandCategory>> GetAllBrandCategories();
        Task<SSL_BrandCategory> GetBrandCategoryById(long id);
    }
}
