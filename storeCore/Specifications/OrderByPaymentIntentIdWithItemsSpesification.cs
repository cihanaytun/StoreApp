using storeCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeCore.Specifications
{
    public class OrderByPaymentIntentIdSpesification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdSpesification(string paymentIntentId) : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}
