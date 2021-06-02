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
    public class OrderController : ApiController
    {

        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            this._service = service; //dependency injection
        }

        //======================================================| GET
        //[Authorize]
        [Route("Api/Order/GetAllOrders")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllOrders()
        {
            var response = await _service.GetAllOrders();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Order/GetAllOrderByUserId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllOrderByUserId([FromUri] Guid userId)
        {
            var response = await _service.GetAllOrderByUserId(userId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Order/GetAllOrderDetailsByOrderId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllOrderDetailsByOrderId([FromUri] long orderId, [FromUri] long addressId, [FromUri] long paymentTypeId, [FromUri] string refId)
        {
            var response = await _service.GetAllOrderDetailsByOrderId(orderId, addressId, paymentTypeId, refId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Order/GetAllOrderStatusByOrderId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllOrderStatusByOrderId([FromUri] long orderId)
        {
            var response = await _service.GetAllOrderStatusByOrderId(orderId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Order/GetAllDeliveryType")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllDeliveryType()
        {
            var response = await _service.GetAllDeliveryType();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        
        //[Authorize]
        [Route("Api/Order/GetAllPaymentType")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllPaymentType()
        {
            var response = await _service.GetAllPaymentType();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Order/GetReferenceByRefId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetReferenceByRefId([FromUri] string refId)
        {
            var response = await _service.GetReferenceByRefId(refId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //======================================================| Add
        [Route("Api/Order/AddOrder")]
        [HttpPost]
        public async Task<IHttpActionResult> AddOrder([FromBody] SSL_Order model)
        {
            var response = await _service.AddOrder(model);
            if (response > 0)
            {
                //return Ok(response);
                return CreatedAtRoute(nameof(GetOrderById), new { id = model.Id }, model); //https://www.jasoncavett.com/blog/converting-to-attribute-routing-in-webapi-applications/
            }
            return NotFound();
        }

        //[Authorize]
        [Route("Api/Order/GetOrderById", Name = "GetOrderById")]
        [HttpGet]
        public async Task<IHttpActionResult> GetOrderById([FromUri] long id)
        {
            var response = await _service.GetOrderById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [Route("Api/Order/AddAllOrderProduct")]
        [HttpPost]
        public async Task<IHttpActionResult> AddAllOrderProduct([FromBody] List<SSL_OrderDetail> products)
        {
            var response = await _service.AddAllOrderProduct(products);
            if (response > 0)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //======================================================| Put/Update
        [Route("Api/Order/UpdateOrderStatusById")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateOrderStatusById([FromUri] int id, [FromUri] string status)
        {
            var response = await _service.UpdateOrderStatusById(id, status);
            return Ok(response);
        }

    }
}
