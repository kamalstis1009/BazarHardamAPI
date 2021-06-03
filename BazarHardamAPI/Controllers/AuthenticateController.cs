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
    public class AuthenticateController : ApiController
    {
        private readonly IAuthenticateService _service;

        public AuthenticateController(IAuthenticateService service)
        {
            this._service = service; //dependency injection
        }

        //======================================================| GET
        //[Authorize]
        [Route("Api/Authenticate/GetAuthById", Name = "GetAuthById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAuthById([FromUri] Guid authId)
        {
            var response = await _service.GetAuthById(authId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [Route("Api/Authenticate/GetAuthByUserAndPass")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAuthByUserAndPass([FromUri] string username, [FromUri] string password)
        {
            var response = await _service.GetAuthByUserAndPass(username, password);
            return Ok(response);
        }

        //======================================================| ADD
        [Route("Api/Authenticate/AddAuthenticate")]
        [HttpPost]
        public async Task<IHttpActionResult> AddAuthenticate([FromBody] SSL_Authenticate model)
        {
            var response = await _service.AddAuthenticate(model);
            return Ok(response); ////return CreatedAtRoute(nameof(GetAuthById), new { id = model.Id }, model); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
        }

        //======================================================| PUT/UPDATE
        [Route("Api/Authenticate/UpdateAuthById")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAuthById([FromUri] Guid authId, [FromBody] SSL_Authenticate item)
        {
            var response = await _service.UpdateAuthById(item, authId);
            if (response > 0)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //======================================================| PUT/UPDATE
        [Route("Api/Authenticate/UpdatePasswordByAuthId")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdatePasswordByAuthId([FromUri] Guid id, [FromUri] string password)
        {
            var response = await _service.UpdatePasswordByAuthId(id, password);
            if (response > 0)
            {
                return Ok(response);
            }
            return NotFound();
        }

    }
}