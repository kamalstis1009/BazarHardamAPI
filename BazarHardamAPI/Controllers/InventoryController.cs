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
    public class InventoryController : ApiController
    {

        private readonly IInventoryService _service;

        public InventoryController(IInventoryService service)
        {
            this._service = service; //dependency injection
        }

        //======================================================| ADD
        [Route("Api/Inventory/AddInventory")]
        [HttpPost]
        public async Task<IHttpActionResult> AddInventory([FromBody] SSL_Inventory item)
        {
            var response = await _service.AddInventory(item);
            return Ok(response);
            //return CreatedAtRoute(nameof(GetVendorById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
        }

        [Route("Api/Inventory/AddAllInventory")]
        [HttpPost]
        public async Task<IHttpActionResult> AddAllInventory([FromBody] List<SSL_Inventory> item)
        {
            var response = await _service.AddAllInventory(item);
            return Ok(response);
        }

        //======================================================| GET
        //[Authorize]
        [Route("Api/Inventory/GetAllInventory")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllInventory()
        {
            var response = await _service.GetAllInventory();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        
        //[Authorize]
        [Route("Api/Inventory/GetAllInventoryGroupBy")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllInventoryGroupBy()
        {
            var response = await _service.GetAllInventoryGroupBy();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Inventory/GetAllInvStores")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllInvStores()
        {
            var response = await _service.GetAllInvStores();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Inventory/GetAllProductUnits")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProductUnits()
        {
            var response = await _service.GetAllProductUnits();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

    }
}
