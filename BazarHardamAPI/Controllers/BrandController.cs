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
    public class BrandController : ApiController
    {

        private readonly IBrandService _service;

        public BrandController(IBrandService service)
        {
            this._service = service; //dependency injection
        }

        //======================================================| Add
        [Route("Api/Brand/AddBrand")]
        [HttpPost]
        public async Task<IHttpActionResult> AddBrand([FromBody] SSL_Brand item)
        {
            var response = await _service.AddBrand(item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetBrandById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }

        [Route("Api/Brand/AddAllBrands")]
        [HttpPost]
        public async Task<IHttpActionResult> AddAllBrands([FromBody] List<SSL_Brand> items)
        {
            var response = await _service.AddAllBrands(items);
            return Ok(response);
        }

        //======================================================| Delete
        //[Authorize]
        [Route("Api/Brand/DeleteBrandById")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBrandById([FromUri] long id)
        {
            var response = await _service.DeleteBrandById(id);
            return Ok(response);
        }

        //======================================================| GET
        //[Authorize]
        [Route("Api/Brand/GetAllBrands")]
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
        [Route("Api/Brand/GetBrandById", Name = "GetBrandById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBrandById([FromUri] long id)
        {
            var response = await _service.GetBrandById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //======================================================| Put/Update
        [Route("Api/Brand/UpdateBrandById")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateBrandById([FromUri] long id, [FromBody] SSL_Brand item)
        {
            var response = await _service.UpdateBrandById(id, item);
            return Ok(response);
        }

        //======================================================| Category
        [Route("Api/Brand/AddBrandCategory")]
        [HttpPost]
        public async Task<IHttpActionResult> AddBrandCategory([FromBody] SSL_BrandCategory item)
        {
            var response = await _service.AddBrandCategory(item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetBrandCategoryById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }
        //[Authorize]
        [Route("Api/Brand/GetAllBrandCategories")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllBrandCategories()
        {
            var response = await _service.GetAllBrandCategories();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        //[Authorize]
        [Route("Api/Brand/GetBrandCategoryById", Name = "GetBrandCategoryById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBrandCategoryById([FromUri] long id)
        {
            var response = await _service.GetBrandCategoryById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

    }
}
