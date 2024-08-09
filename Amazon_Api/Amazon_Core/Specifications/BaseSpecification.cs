using Amazon_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Specifications
{
    public class BaseSpecification<T> : ISpecifictations<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<T, object>>> Include { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> orderBy { get; set; } = null;
        public Expression<Func<T, object>> orderByDes { get; set; } = null;

        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> CriteriaExpression)
        {
            //Get The Search Value 
            Criteria = CriteriaExpression;
       
        }

        //Add Tow Method For Sorting Functionalty 

        public void AddOrderBy(Expression<Func<T, object>> orderByEx)
        {
            orderBy = orderByEx;
        }

        public void AddOrderByDes(Expression<Func<T, object>> orderByDesEx)
        {
            orderByDes = orderByDesEx;
        }


    }


}
