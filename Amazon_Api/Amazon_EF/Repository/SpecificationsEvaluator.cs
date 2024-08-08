using Amazon_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon_Core.Specifications;
using Microsoft.EntityFrameworkCore;
namespace Amazon_EF.Repository
{
    public static class SpecificationsEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> getQuery(IQueryable<TEntity> inputQuery , ISpecifictations<TEntity> specifictations)
        {
            var query = inputQuery; //_dbContext.Set<T>
            if (specifictations.Criteria != null)  //p => p== ??
                query = query.Where(specifictations.Criteria); // _dbContext.Set<T>.Where(p => p== ??)


            query = specifictations.Include.Aggregate(query, (CurrentQuery, QueryExpression) => CurrentQuery.Include(QueryExpression));
            //CurrentQuery ==> query 
            //QueryExpression ==> (p => p== ??)
            return query;

            //Go to Generic Repository To Implemnt This
        }
    }
}
