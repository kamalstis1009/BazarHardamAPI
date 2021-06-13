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
    public class ProductService : IProductService
    {

        private readonly BazarHardamEntities _context = SQLDatabaseContext.Instance.GetDatabaseInstance();

        //======================================================| ADD
        public async Task<int> AddProduct(SSL_Product model)
        {
            _context.SSL_Product.Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddAllProducts(List<SSL_Product> models)
        {
            _context.SSL_Product.AddRange(models);
            return await _context.SaveChangesAsync();
        }

        //======================================================| DELETE
        public async Task<int> DeleteProductById(long id)
        {
            var item = await _context.SSL_Product.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                _context.SSL_Product.Remove(item);
                var response = await _context.SaveChangesAsync();
                if (response > 0) 
                {
                    _context.SSL_Description.RemoveRange(_context.SSL_Description.Where(index => index.Id == id).ToList());
                    await _context.SaveChangesAsync();

                    _context.SSL_Specification.RemoveRange(_context.SSL_Specification.Where(index => index.Id == id).ToList());
                    return await _context.SaveChangesAsync();
                }
                return 0;
            }
            return 0;
        }

        //======================================================| GET
        public async Task<List<SSL_Product>> GetAllProducts()
        {
            return await _context.SSL_Product.Where(index => index.Status == "Approved").ToListAsync();
        }

        public async Task<SSL_Product> GetProductById(long id)
        {
            return await _context.SSL_Product.FirstOrDefaultAsync(index => index.Id == id);
        }

        public async Task<List<SSL_Product>> GetAllProductByCategoryId(long categoryId)
        {
            return await _context.SSL_Product.Where(index => index.Status == "Approved" && index.CategoryId == categoryId).ToListAsync();
        }

        public async Task<ProductDetail> GetProductDetailsById(long id)
        {
            return await (from A in _context.SSL_Product where A.Id == id
                          //join B in _context.SSL_Brand on A.BrandId equals B.Id
                          join C in _context.SSL_InvStockSummary on A.Id equals C.ProductId
                          //let brand = (from e in _context.SSL_Brand where e.Id == A.BrandId select e).FirstOrDefault()
                          select new ProductDetail
                          {
                              Brand = _context.SSL_Brand.FirstOrDefault(index => index.Id == A.BrandId),
                              StockSummary = C
                          }).FirstOrDefaultAsync();
        }
        
        //======================================================| UPDATE
        public async Task<int> UpdateProductById(long id, SSL_Product model)
        {
            var item = await _context.SSL_Product.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                item.CategoryId = model.CategoryId;
                item.BrandId = model.BrandId;
                item.Code = model.Code;
                item.Name = model.Name;
                item.Description = model.Description;
                item.SaleUnitPrice = model.SaleUnitPrice;
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

        //======================================================| Description | Specification
        public async Task<int> AddDescription(SSL_Description model)
        {
            _context.SSL_Description.Add(model);
            return await _context.SaveChangesAsync();
        }
        public async Task<SSL_Description> GetDescriptionById(long id)
        {
            return await _context.SSL_Description.FirstOrDefaultAsync(index => index.Id == id);
        }
        public async Task<int> DeleteDescriptionById(long id)
        {
            var item = await _context.SSL_Description.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                _context.SSL_Description.Remove(item);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> AddSpecification(SSL_Specification model)
        {
            _context.SSL_Specification.Add(model);
            return await _context.SaveChangesAsync();
        }
        public async Task<SSL_Specification> GetSpecificationById(long id)
        {
            return await _context.SSL_Specification.FirstOrDefaultAsync(index => index.Id == id);
        }
        public async Task<int> DeleteSpecificationById(long id)
        {
            var item = await _context.SSL_Specification.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                _context.SSL_Specification.Remove(item);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        //======================================================| ProductCategory
        public async Task<int> AddProductCategory(SSL_ProductCategory model)
        {
            var item = await _context.SSL_ProductCategory.FirstOrDefaultAsync(index => index.Name == model.Name);
            if (item == null)
            {
                _context.SSL_ProductCategory.Add(model);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<SSL_ProductCategory>> GetAllProductCategory()
        {
            return await _context.SSL_ProductCategory.Where(index => index.IsEnabled == true).ToListAsync();
        }

        public async Task<SSL_ProductCategory> GetProductCategoryById(long id)
        {
            return await _context.SSL_ProductCategory.Where(index => index.Id == id).FirstOrDefaultAsync();
        }

        //======================================================| Brand
        public async Task<List<SSL_Brand>> GetAllBrands()
        {
            return await _context.SSL_Brand.Where(index => index.Status == "Available").ToListAsync();
        }

        public async Task<List<SSL_Product>> GetAllProductByBrandId(long brandId)
        {
            return await _context.SSL_Product.Where(index => index.BrandId == brandId).ToListAsync();
        }

        //======================================================| ProductUnit
        public async Task<List<SSL_ProductUnit>> GetAllProductUnit()
        {
            return await _context.SSL_ProductUnit.ToListAsync();
        }

        public async Task<List<ProductWithUnit>> GetAllProductsWithUnit()
        {
            return await (from A in _context.SSL_Product
                          join B in _context.SSL_ProductUnit on A.ProductUnitId equals B.Id
                          select new ProductWithUnit
                          {
                              Id = A.Id,
                              CategoryId = A.CategoryId,
                              BrandId = A.BrandId,
                              Code = A.Code,
                              Name = A.Name +" - "+ B.Name,
                              Description = A.Description,
                              ProductUnitId = A.ProductUnitId,
                              SaleUnitPrice = A.SaleUnitPrice,
                              ImageName = A.ImageName,
                              ImagePath = A.ImagePath,
                              Status = A.Status,
                              CreateUser = A.CreateUser,
                              CreateDate = A.CreateDate,
                              EditUser = A.EditUser,
                              EditDate = A.EditDate,
                              OCode = A.OCode
                          }).ToListAsync();
        }

        //======================================================| ShoppingCart
        public async Task<SSL_ShoppingCart> AddShoppingCart(Guid userId, SSL_ShoppingCart model)
        {
            var item = await _context.SSL_ShoppingCart.FirstOrDefaultAsync(index => index.ProductId == model.ProductId && index.CreateUser == userId);
            if (item == null)
            {
                _context.SSL_ShoppingCart.Add(model);
                await _context.SaveChangesAsync();
            }
            else
            {
                item.ProductId = model.ProductId;
                item.Qty = model.Qty;
                item.UnitPrice = model.UnitPrice;
                item.TotalAmount = model.TotalAmount;
                item.EditUser = model.EditUser;
                item.EditDate = model.EditDate;
                item.OCode = model.OCode;
                await _context.SaveChangesAsync(); //Updated : //If any change the response 1, do not change response 0
            }
            return model;
        }

        public async Task<List<ProductModel>> GetAllShoppingCartByUserId(Guid userId)
        {
            return await (from S in _context.SSL_ShoppingCart.Where(index => index.CreateUser == userId)
                              join P in _context.SSL_Product on S.ProductId equals P.Id
                              select new ProductModel 
                              {
                                  Id = P.Id,
                                  CategoryId = P.CategoryId,
                                  BrandId = P.BrandId,
                                  Code = P.Code,
                                  Name = P.Name,
                                  Description = P.Description,
                                  ProductUnitId = P.ProductUnitId,
                                  SaleUnitPrice = P.SaleUnitPrice,
                                  ImageName = P.ImageName,
                                  ImagePath = P.ImagePath,
                                  Status = P.Status,
                                  CreateUser = P.CreateUser,
                                  CreateDate = P.CreateDate,
                                  OCode = P.OCode,
                                  Quantity = S.Qty,
                                  TotalAmount = S.TotalAmount
                              }).ToListAsync();
        }

        public async Task<int> DeleteShoppingCartById(long productId, Guid userId)
        {
            var item = await _context.SSL_ShoppingCart.FirstOrDefaultAsync(index => index.ProductId == productId && index.CreateUser == userId);
            if (item != null)
            {
                _context.SSL_ShoppingCart.Remove(item);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }


    }
}