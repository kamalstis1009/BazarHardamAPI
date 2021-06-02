using BazarHardamAPI.Models;
using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarHardamAPI.Services
{
    public interface IOrderService
    {
        Task<int> AddOrder(SSL_Order model);
        Task<int> AddAllOrderProduct(List<SSL_OrderDetail> products);
        Task<List<SSL_Order>> GetAllOrders();
        Task<SSL_Order> GetOrderById(long id);
        Task<List<SSL_Order>> GetAllOrderByUserId(Guid userId);
        Task<OrderDetailModel> GetAllOrderDetailsByOrderId(long orderId, long addressId, long paymentTypeId, string refId);
        Task<List<SSL_OrderStatus>> GetAllOrderStatusByOrderId(long orderId);
        Task<List<SSL_DeliveryType>> GetAllDeliveryType();
        Task<List<SSL_PaymentType>> GetAllPaymentType();
        Task<SSL_Reference> GetReferenceByRefId(string refId);
        Task<int> UpdateOrderStatusById(int id, string status);
    }
}
