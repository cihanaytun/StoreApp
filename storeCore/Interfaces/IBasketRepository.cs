using storeCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeCore.Interfaces
{
    public interface IBasketRepository
    {
        /// <summary>
        /// GetBasketAsync
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        Task<CustomerBasket> GetBasketAsync(string basketId);

        /// <summary>
        /// UpdateBasketAsync
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        /// <summary>
        /// DeleteBasketAsync
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
