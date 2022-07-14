using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace storeCore.Specifications
{
    public interface ISpecification<T> 
    {
        //Kriterler ve include lar merkezileştirmek için

        /// <summary>
        /// Criteria
        /// </summary>
        Expression<Func<T,bool>> Criteria { get; }

        /// <summary>
        /// Includes
        /// </summary>
        List<Expression<Func<T,object>>> Includes { get; }
        
        /// <summary>
        /// OrderBy sorting 
        /// </summary>
        Expression<Func<T, object>> OrderBy { get; }

        /// <summary>
        /// OrderByDescending sorting
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }

        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
