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
    public static class SpecificationsEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> getQuery(IQueryable<T> inputQuery , ISpecifictations<T> specifictations)
        {
            var query = inputQuery; //_dbContext.Set<T>
            if (specifictations.Criteria != null)  //p => p== ??
                query = query.Where(specifictations.Criteria); // _dbContext.Set<T>.Where(p => p== ??)


            if (specifictations.orderBy != null) // p => p.Price
                query = query.OrderBy(specifictations.orderBy);

           else if (specifictations.orderByDes != null) //p => p.Price
                query = query.OrderByDescending(specifictations.orderByDes);

            if (specifictations.isPaginationEnable == true)
                query = query.Skip(specifictations.Skipe).Take(specifictations.Take);

              query = specifictations.Include.Aggregate(query, (CurrentQuery, QueryExpression) => CurrentQuery.Include(QueryExpression));
            //CurrentQuery ==> query 
            //QueryExpression ==> (p => p== ??)
            return query;

            //Go to Generic Repository To Implemnt This
        }
    }
}
