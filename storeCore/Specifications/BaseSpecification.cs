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

        /// <summary>
        /// OrderBy sorting
        /// </summary>
        public Expression<Func<T, object>> OrderBy { get; private set; }

        /// <summary>
        /// OrderByDescending  sroting
        /// </summary>
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        /// <summary>
        /// Take Pagining
        /// </summary>
        public int Take { get; private set; }

        /// <summary>
        /// Skip Pagining
        /// </summary>
        public int Skip { get; private set; }

        /// <summary>
        /// IsPaginingEnabled Pagining
        /// </summary>
        public bool IsPagingEnabled { get; private set; }





        protected void AddInclude (Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T,object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDesExpression)
        {
            OrderByDescending = orderByDesExpression;
        }


        protected void ApplyPaging(int skip,int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
