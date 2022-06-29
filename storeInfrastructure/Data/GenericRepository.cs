using Microsoft.EntityFrameworkCore;
using storeCore.Entities;
using storeCore.Interfaces;
using storeCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeInfrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        /// <summary>
        /// Generic GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _storeContext.Set<T>().FindAsync(id);
        }



        /// <summary>
        /// Generic ListAll
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _storeContext.Set<T>().ToListAsync();
        }




        /// <summary>
        /// GetEntityWithSpec
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySepcification(spec).FirstOrDefaultAsync();
        }

 
        /// <summary>
        /// ListAsync
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySepcification(spec).ToListAsync();
        }


        private IQueryable<T>ApplySepcification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_storeContext.Set<T>().AsQueryable(), spec);
        }
    }
}
