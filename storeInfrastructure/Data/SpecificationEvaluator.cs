using Microsoft.EntityFrameworkCore;
using storeCore.Entities;
using storeCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeInfrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {

        /// <summary>
        /// GetQuery
        /// </summary>
        /// <param name="inputQuery"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // p => p.ProductTypeId == id ---> örnek
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            
            return query;
        }
    }
}
