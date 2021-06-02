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
    public class CampaignController : ApiController
    {

        private readonly ICampaignService _service;

        public CampaignController(ICampaignService service)
        {
            this._service = service; //dependency injection
        }

        //======================================================| GET
        //[Authorize]
        [Route("Api/Campaign/GetCampaign")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCampaign()
        {
            var response = await _service.GetCampaign();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }


        //[Authorize]
        [Route("Api/Campaign/GetCampaigns")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCampaigns()
        {
            var response = await _service.GetCampaign();
            if (response != null)
            {
                return Ok(new { results = response });
            }
            return NotFound();
        }

    }
}
