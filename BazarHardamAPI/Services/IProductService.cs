using BazarHardamAPI.Models;
using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarHardamAPI.Services
{
    public interface IProductService
    {
        Task<int> AddProduct(SSL_Product model);
        Task<int> AddAllProducts(List<SSL_Product> models);

        Task<int> DeleteProductById(long id);

        Task<List<SSL_Product>> GetAllProducts();
        Task<SSL_Product> GetProductById(long id);
        Task<ProductDetail> GetProductDetailsById(long id);

        Task<int> UpdateProductById(long id, SSL_Product model);

        Task<int> AddDescription(SSL_Description model);
        Task<SSL_Description> GetDescriptionById(long id);
        Task<int> DeleteDescriptionById(long id);

        Task<int> AddSpecification(SSL_Specification model);
        Task<SSL_Specification> GetSpecificationById(long id);
        Task<int> DeleteSpecificationById(long id);

        Task<int> AddProductCategory(SSL_ProductCategory model);
        Task<List<SSL_ProductCategory>> GetAllProductCategory();
        Task<SSL_ProductCategory> GetProductCategoryById(long id);
        Task<List<SSL_Product>> GetAllProductByCategoryId(long categoryId);
        Task<List<SSL_Brand>> GetAllBrands();
        Task<List<SSL_Product>> GetAllProductByBrandId(long brandId);

        Task<List<SSL_ProductUnit>> GetAllProductUnit();
        Task<List<ProductWithUnit>> GetAllProductsWithUnit();

        Task<SSL_ShoppingCart> AddShoppingCart(Guid userId, SSL_ShoppingCart model);
        Task<List<ProductModel>> GetAllShoppingCartByUserId(Guid userId);
        Task<int> DeleteShoppingCartById(long productId, Guid userId);
    }
}
