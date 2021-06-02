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
    public class BrandService : IBrandService
    {

        private readonly BazarHardamEntities _context = SQLDatabaseContext.Instance.GetDatabaseInstance();

        //======================================================| ADD
        public async Task<int> AddBrand(SSL_Brand model)
        {
            var item = await _context.SSL_Brand.FirstOrDefaultAsync(index => index.Name == model.Name);
            if (item == null)
            {
                _context.SSL_Brand.Add(model);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> AddAllBrands(List<SSL_Brand> models)
        {
            _context.SSL_Brand.AddRange(models);
            return await _context.SaveChangesAsync();
        }

        //======================================================| DELETE
        public async Task<int> DeleteBrandById(long id)
        {
            var item = await _context.SSL_Brand.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                _context.SSL_Brand.Remove(item);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        //======================================================| GET
        public async Task<List<BrandModel>> GetAllBrands()
        {
            //return await _context.SSL_Brand.ToListAsync();
            return await (from model in _context.SSL_Brand
                          join item in _context.SSL_BrandCategory on model.CategoryId equals item.Id
                          select new BrandModel
                          {
                              Brand = model,
                              BrandCategory = item
                          }).ToListAsync();
        }

        public async Task<SSL_Brand> GetBrandById(long id)
        {
            return await _context.SSL_Brand.FirstOrDefaultAsync(index => index.Id == id);
        }

        //======================================================| UPDATE
        public async Task<int> UpdateBrandById(long id, SSL_Brand model)
        {
            var item = await _context.SSL_Brand.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                item.CategoryId = model.CategoryId;
                item.Name = model.Name;
                item.Description = model.Description;
                item.ImageName = model.ImageName;
                item.ImagePath = model.ImagePath;
                item.Status = model.Status;
                item.EditUser = model.EditUser;
                item.EditDate = model.EditDate;
                item.OCode = model.OCode;
                return await _context.SaveChangesAsync(); //Updated : //If any change the response 1, do not change response 0
            }
            return 0;
        }

        //======================================================| Category
        public async Task<int> AddBrandCategory(SSL_BrandCategory model)
        {
            var item = await _context.SSL_BrandCategory.FirstOrDefaultAsync(index => index.Name == model.Name);
            if (item == null)
            {
                _context.SSL_BrandCategory.Add(model);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<List<SSL_BrandCategory>> GetAllBrandCategories()
        {
            return await _context.SSL_BrandCategory.ToListAsync();
        }
        public async Task<SSL_BrandCategory> GetBrandCategoryById(long id)
        {
            return await _context.SSL_BrandCategory.FirstOrDefaultAsync(index => index.Id == id);
        }

    }
}