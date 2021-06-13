using BazarHardamAPI.Repositories;
using BazarHardamAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BazarHardamAPI.Controllers
{
    public class ProductController : ApiController
    {

        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            this._service = service; //dependency injection
        }

        //======================================================| Product

        //------------------------------------------------------| ADD
        [Route("Api/Product/AddProduct")]
        [HttpPost]
        public async Task<IHttpActionResult> AddProduct([FromBody] SSL_Product item)
        {
            var response = await _service.AddProduct(item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetProductById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }
        //------------------------------------------------------| DELETE
        //[Authorize]
        [Route("Api/Product/DeleteProductById")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProductById([FromUri] long id)
        {
            var response = await _service.DeleteProductById(id);
            return Ok(response);
        }
        //------------------------------------------------------| GET
        //[Authorize]
        [Route("Api/Product/GetAllProducts")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            var response = await _service.GetAllProducts();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        //[Authorize]
        [Route("Api/Product/GetProductById", Name = "GetProductById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProductById([FromUri] long id)
        {
            var response = await _service.GetProductById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        //[Authorize]
        [Route("Api/Product/GetProductDetailsById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProductDetailsById([FromUri] long id)
        {
            var response = await _service.GetProductDetailsById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //------------------------------------------------------| PUT/UPDATE
        [Route("Api/Product/UpdateProductById")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateProductById([FromUri] long id, [FromBody] SSL_Product item)
        {
            var response = await _service.UpdateProductById(id, item);
            return Ok(response);
        }

        //======================================================| ProductCategory
        [Route("Api/Product/AddProductCategory")]
        [HttpPost]
        public async Task<IHttpActionResult> AddProductCategory([FromBody] SSL_ProductCategory item)
        {
            var response = await _service.AddProductCategory(item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetProductCategoryById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }
        //[Authorize]
        [Route("Api/Product/GetAllProductCategory")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProductCategory()
        {
            var response = await _service.GetAllProductCategory();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        //[Authorize]
        [Route("Api/Product/GetProductCategoryById", Name = "GetProductCategoryById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProductCategoryById([FromUri] long id)
        {
            var response = await _service.GetProductCategoryById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Product/GetAllProductByCategoryId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProductByCategoryId([FromUri] long categoryId)
        {
            var response = await _service.GetAllProductByCategoryId(categoryId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //======================================================| Brand
        //[Authorize]
        [Route("Api/Product/GetAllBrands")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllBrands()
        {
            var response = await _service.GetAllBrands();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Product/GetAllProductByBrandId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProductByBrandId([FromUri] long brandId)
        {
            var response = await _service.GetAllProductByBrandId(brandId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }


        //======================================================| Description | Specification
        [Route("Api/Product/AddDescription")]
        [HttpPost]
        public async Task<IHttpActionResult> AddDescription([FromBody] SSL_Description item)
        {
            var response = await _service.AddDescription(item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetDescriptionById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }
        //[Authorize]
        [Route("Api/Product/DeleteDescriptionById")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteDescriptionById([FromUri] long id)
        {
            var response = await _service.DeleteDescriptionById(id);
            return Ok(response);
        }
        //[Authorize]
        [Route("Api/Product/GetDescriptionById", Name = "GetDescriptionById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDescriptionById([FromUri] long id)
        {
            var response = await _service.GetDescriptionById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [Route("Api/Product/AddSpecification")]
        [HttpPost]
        public async Task<IHttpActionResult> AddSpecification([FromBody] SSL_Specification item)
        {
            var response = await _service.AddSpecification(item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetSpecificationById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }
        //[Authorize]
        [Route("Api/Product/DeleteSpecificationById")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteSpecificationById([FromUri] long id)
        {
            var response = await _service.DeleteSpecificationById(id);
            return Ok(response);
        }
        //[Authorize]
        [Route("Api/Product/GetSpecificationById", Name = "GetSpecificationById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetSpecificationById([FromUri] long id)
        {
            var response = await _service.GetSpecificationById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }


        //======================================================| ProductUnit
        [Route("Api/Product/GetAllProductUnit")]
        [HttpPost]
        public async Task<IHttpActionResult> GetAllProductUnit()
        {
            var response = await _service.GetAllProductUnit();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Product/GetAllProductsWithUnit")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProductsWithUnit()
        {
            var response = await _service.GetAllProductsWithUnit();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //======================================================| ShoppingCart
        [Route("Api/Product/AddShoppingCart")]
        [HttpPost]
        public async Task<IHttpActionResult> AddShoppingCart([FromUri] Guid userId, [FromBody] SSL_ShoppingCart item)
        {
            var response = await _service.AddShoppingCart(userId, item);
            return Ok(response);
        }

        [Route("Api/Product/GetAllShoppingCartByUserId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllShoppingCartByUserId([FromUri] Guid userId)
        {
            var response = await _service.GetAllShoppingCartByUserId(userId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [Route("Api/Product/DeleteShoppingCartById")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteShoppingCartById([FromUri] long productId, [FromUri] Guid userId)
        {
            var response = await _service.DeleteShoppingCartById(productId, userId);
            return Ok(response);
        }



    }
}
