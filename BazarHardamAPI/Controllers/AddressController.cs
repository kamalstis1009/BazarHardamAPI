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
    public class AddressController : ApiController
    {

        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            this._service = service; //dependency injection
        }

        //======================================================| Add
        [Route("Api/Address/AddAddress")]
        [HttpPost]
        public async Task<IHttpActionResult> AddAddress([FromBody] SSL_Address item)
        {
            var response = await _service.AddAddress(item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetAddressById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }

        //======================================================| Delete
        //[Authorize]
        [Route("Api/Address/DeleteAddressById")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAddressById([FromUri] int id)
        {
            var response = await _service.DeleteAddressById(id);
            return Ok(response);
        }

        //======================================================| GET
        //[Authorize]
        [Route("Api/Address/GetAddressById", Name = "GetAddressById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAddressById([FromUri] int id)
        {
            var response = await _service.GetAddressById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        
        //[Authorize]
        [Route("Api/Address/GetAllAddressByUserId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllAddressByUserId([FromUri] Guid userId)
        {
            var response = await _service.GetAllAddressByUserId(userId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //======================================================| Put/Update
        [Route("Api/Address/UpdateAddressById")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAddressById([FromUri] int id, [FromBody] SSL_Address item)
        {
            var response = await _service.UpdateAddressById(id, item);
            return Ok(response);
        }

    }
}
