using storeCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace storeCore.Specifications
{
    public class OrdersWithItmesAndOrderingSpesification : BaseSpecification<Order>
    {
        public OrdersWithItmesAndOrderingSpesification(string email):base(o =>o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrdersWithItmesAndOrderingSpesification(int id , string email):base(o=>o.Id == id && o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
        }  
    }
}
