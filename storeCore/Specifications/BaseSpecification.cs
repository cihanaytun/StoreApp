using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace storeCore.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }


        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        /// <summary>
        /// Criteria
        /// </summary>
        public Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Includes
        /// </summary>
        public List<Expression<Func<T, object>>> Includes { get; } =
            new  List<Expression<Func<T, object>>> ();

        protected void AddInclude (Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
