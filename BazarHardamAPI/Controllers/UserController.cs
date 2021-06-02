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
    public class UserController : ApiController
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            this._service = service; //dependency injection
        }

        //======================================================| GET
        //[Authorize]
        [Route("Api/User/GetUserByUserAndPass")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserByUserAndPass([FromUri] string username, [FromUri] string password)
        {
            var response = await _service.GetUserByUserPass(username, password);
            return Ok(response);
        }

        //[Authorize]
        [Route("Api/User/GetUserById", Name = "GetUserById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserById([FromUri] Guid id)
        {
            var response = await _service.GetUserById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/User/GetOnlineBankingById", Name = "GetOnlineBankingById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetOnlineBankingById([FromUri] long id)
        {
            var response = await _service.GetOnlineBankingById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        
        //[Authorize]
        [Route("Api/User/GetAllOnlineBankingByUserId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllOnlineBankingByUserId([FromUri] Guid userId)
        {
            var response = await _service.GetAllOnlineBankingByUserId(userId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        
        //[Authorize]
        [Route("Api/User/GetBalanceByUserId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBalanceByUserId([FromUri] Guid userId)
        {
            var response = await _service.GetBalanceByUserId(userId);
            return Ok(response);
        }
        
        //[Authorize]
        [Route("Api/User/GetAllPaymentHistoryByUserId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllPaymentHistoryByUserId([FromUri] Guid userId)
        {
            var response = await _service.GetAllPaymentHistoryByUserId(userId);
            return Ok(response);
        }

        //======================================================| Add
        [Route("Api/User/AddUser")]
        [HttpPost]
        public async Task<IHttpActionResult> AddUser([FromBody] SSL_User item)
        {
            var response = await _service.AddUser(item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetUserById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }

        [Route("Api/User/AddOnlineBanking")]
        [HttpPost]
        public async Task<IHttpActionResult> AddOnlineBanking([FromBody] SSL_OnlineBanking item)
        {
            var response = await _service.AddOnlineBanking(item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetOnlineBankingById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }

        //======================================================| Put/Update
        [Route("Api/User/UpdateUserById")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateUserById([FromUri] Guid id, [FromBody] SSL_User item)
        {
            var response = await _service.UpdateUserById(id, item);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetUserById), new { id = item.Id }, item); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }







        /*
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
        public async Task<IHttpActionResult> DeleteVendorById([FromUri] Guid id)
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
        public async Task<IHttpActionResult> GetVendorById([FromUri] Guid id)
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
        public async Task<IHttpActionResult> UpdateVendorById([FromUri] Guid id, [FromBody] SSL_Vendor item)
        {
            var response = await _service.UpdateVendorById(id, item);
            return Ok(response);
        }
         */
    }
}
