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
        
        Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId, Address shippingAddress);

        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);

        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);

        Task<IReadOnlyList<DeliveryMethod>> GetDliveryMethodsAsync();


    }
}
