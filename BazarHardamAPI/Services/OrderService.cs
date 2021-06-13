using BazarHardamAPI.Models;
using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BazarHardamAPI.Services
{
    public class OrderService : IOrderService
    {

        private readonly BazarHardamEntities _context = SQLDatabaseContext.Instance.GetDatabaseInstance();

        //======================================================| ADD
        public async Task<int> AddOrder(SSL_Order model)
        {
            _context.SSL_Order.Add(model);
            var response = await _context.SaveChangesAsync();
            if (response > 0)
            {
                var item = new SSL_OrderStatus
                {
                    OrderId = model.Id,
                    Status = "Processing",
                    Comments = "Your product is now in the processing section.",
                    CreateUser = model.CreateUser,
                    CreateDate = model.CreateDate,
                    OCode = model.OCode
                };
                _context.SSL_OrderStatus.Add(item);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> AddAllOrderProduct(List<SSL_OrderDetail> products)
        {
            _context.SSL_OrderDetail.AddRange(products);
            return await _context.SaveChangesAsync();
        }

        //======================================================| GET
        public async Task<List<SSL_Order>> GetAllOrders()
        {
            return await _context.SSL_Order.ToListAsync();
        }

        public async Task<SSL_Order> GetOrderById(long id)
        {
            return await _context.SSL_Order.FirstOrDefaultAsync(index => index.Id == id);
        }

        public async Task<List<SSL_Order>> GetAllOrderByUserId(Guid userId)
        {
            return await _context.SSL_Order.Where(index => index.UserId == userId).ToListAsync();
            /*return await (from A in _context.SSL_Order
                          where A.UserId == userId
                          let list = (from model in _context.SSL_OrderDetail where model.OrderId == A.Id select model).ToList()
                          select new OrderModel
                          {
                              Order = A,
                              TotalAmount = list.Sum(i => i.TotalAmount)
                          }).ToListAsync();*/
        }

        public async Task<OrderDetailModel> GetAllOrderDetailsByOrderId(long orderId, long addressId, long paymentTypeId, string refId)
        {
            var list = await (from O in _context.SSL_OrderDetail.Where(index => index.OrderId == orderId)
                              join P in _context.SSL_Product on O.ProductId equals P.Id
                              select new { O, P = new ProductModel { Id=P.Id, CategoryId=P.CategoryId, BrandId=P.BrandId, Code = P.Code, Name =P.Name, Description=P.Description, ProductUnitId=P.ProductUnitId, SaleUnitPrice=P.SaleUnitPrice, ImageName=P.ImageName, ImagePath=P.ImagePath, Status=P.Status, CreateUser=P.CreateUser, CreateDate=P.CreateDate, OCode = P.OCode, Quantity=O.Qty, TotalAmount=O.TotalAmount } }).ToListAsync();
            //list.ForEach(index => { index.P.Quantity = index.O.Qty; index.P.TotalAmount = index.O.TotalAmount; });
            if (list != null)
            {
                var item = _context.SSL_PaymentType.FirstOrDefault(index => index.Id == paymentTypeId);
                var model = _context.SSL_Reference.FirstOrDefault(index => index.RefId == refId);
                var address = _context.SSL_Address.FirstOrDefault(index => index.Id == addressId);
                return new OrderDetailModel
                {
                    Products = list.Select(index => index.P).ToList(),
                    Address = address,
                    PaymentType = item?.Name,
                    Discount = model != null ? model.Discount : 0
                };
            }
            return null;
            
        }

        public async Task<List<SSL_OrderStatus>> GetAllOrderStatusByOrderId(long orderId)
        {
            return await _context.SSL_OrderStatus.Where(index => index.OrderId == orderId).ToListAsync();
        }

        public async Task<List<SSL_DeliveryType>> GetAllDeliveryType()
        {
            return await _context.SSL_DeliveryType.ToListAsync();
        }

        public async Task<List<SSL_PaymentType>> GetAllPaymentType()
        {
            return await _context.SSL_PaymentType.ToListAsync();
        }

        public async Task<SSL_Reference> GetReferenceByRefId(string refId)
        {
            return await _context.SSL_Reference.FirstOrDefaultAsync(index => index.RefId == refId);
        }

        //======================================================| UPDATE
        public async Task<int> UpdateOrderStatusById(int id, string status)
        {
            var item = await _context.SSL_Order.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                item.Status = status;
                return await _context.SaveChangesAsync(); //Updated : //If any change the response 1, do not change response 0
            }
            return 0;
        }

    }
}