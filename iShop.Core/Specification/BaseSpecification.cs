using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace iShop.Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Critera = criteria;
        }

        public Expression<Func<T, bool>> Critera { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public Expression<Func<T, object>> OrderBy => throw new NotImplementedException();

        public Expression<Func<T, object>> OrderByDescending => throw new NotImplementedException();
    }
}
