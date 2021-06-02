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
    public class VendorController : ApiController
    {
        private readonly IVendorService _service;

        public VendorController(IVendorService service)
        {
            this._service = service; //dependency injection
        }

        //======================================================| Add
        [Route("Api/Vendor/AddVendor")]
        [HttpPost]
        public async Task<IHttpActionResult> AddVendor([FromBody] SSL_Vendor item)
        {
            var response = await _service.AddVendor(item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetVendorById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }

        [Route("Api/Vendor/AddAllVendors")]
        [HttpPost]
        public async Task<IHttpActionResult> AddAllVendors([FromBody] List<SSL_Vendor> items)
        {
            var response = await _service.AddAllVendors(items);
            return Ok(response);
        }

        //======================================================| Delete
        //[Authorize]
        [Route("Api/Vendor/DeleteVendorById")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteVendorById([FromUri] int id)
        {
            var response = await _service.DeleteVendorById(id);
            return Ok(response);
        }

        //======================================================| GET
        //[Authorize]
        [Route("Api/Vendor/GetAllVendors")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllVendors()
        {
            var response = await _service.GetAllVendors();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Vendor/GetVendorById", Name = "GetVendorById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetVendorById([FromUri] int id)
        {
            var response = await _service.GetVendorById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //======================================================| Put/Update
        [Route("Api/Vendor/UpdateVendorById")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateVendorById([FromUri] int id, [FromBody] SSL_Vendor item)
        {
            var response = await _service.UpdateVendorById(id, item);
            return Ok(response);
        }
    }
}
