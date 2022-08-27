using storeCore.Entities.Identity;
using storeCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Address = storeCore.Entities.OrderAggregate.Address;

namespace storeCore.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// CreateOrderAsync
        /// </summary>
        /// <param name="buyerEmail"></param>
        /// <param name="deliveryMethod"></param>
        /// <param name="basketId"></param>
        /// <param name="shippingAddress"></param>
        /// <returns></returns>
        Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId, Address shippingAddress);

        
        
        /// <summary>
        /// GetOrdersForUserAsync
        /// </summary>
        /// <param name="buyerEmail"></param>
        /// <returns></returns>
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);


        /// <summary>
        /// GetOrderByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <param name="buyerEmail"></param>
        /// <returns></returns>
        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);


        /// <summary>
        /// GetDliveryMethodsAsync
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<DeliveryMethod>> GetDliveryMethodsAsync();


    }
}
