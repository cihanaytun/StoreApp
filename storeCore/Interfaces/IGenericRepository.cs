using storeCore.Entities;
using storeCore.Entities.OrderAggregate;
using storeCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeCore.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// ListAllAsync
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAllAsync();




        /// <summary>
        /// GetEntityWithSpec
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        /// <summary>
        /// ListAsync
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        /// <summary>
        /// CountAsync
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        Task<int> CountAsync(ISpecification<T> spec);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
