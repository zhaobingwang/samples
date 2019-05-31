using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sample.DotNet.CSharp
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        Expression<Func<T, object>> GroupBy { get; }

        int Take { get; }
        int Skip { get; }
        bool isPagingEnabled { get; }
    }
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        //protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        //{
        //    Includes.Add(includeExpression);
        //}
        //protected virtual void AddInclude(string includeString)
        //{
        //    IncludeStrings.Add(includeString);
        //}


        public List<string> IncludeStrings => throw new NotImplementedException();

        public Expression<Func<T, object>> OrderBy => throw new NotImplementedException();

        public Expression<Func<T, object>> OrderByDescending => throw new NotImplementedException();

        public Expression<Func<T, object>> GroupBy => throw new NotImplementedException();

        public int Take => throw new NotImplementedException();

        public int Skip => throw new NotImplementedException();

        public bool isPagingEnabled => throw new NotImplementedException();
    }

    public class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification(int userId) : base(u => u.Id == userId)
        {
            //AddInclude(u => u.Name);
        }
        public UserSpecification(string userName) : base(u => u.Name == userName)
        {

        }
    }

    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            //query = specification.Includes.Aggregate(query,
            //    (current, include) => current.Include(include));

            //query = specification.IncludeStrings.Aggregate(query,
            //    (current, include) => current.Include(include));

            //if (specification.OrderBy != null)
            //{
            //    query = query.OrderBy(specification.OrderBy);
            //}
            //else if (specification.OrderByDescending != null)
            //{
            //    query = query.OrderByDescending(specification.OrderByDescending);
            //}

            //if (specification.GroupBy != null)
            //{
            //    query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            //}

            //if (specification.isPagingEnabled)
            //{
            //    query = query.Skip(specification.Skip)
            //        .Take(specification.Take);
            //}
            return query;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
