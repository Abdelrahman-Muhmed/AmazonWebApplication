using Amazon_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Specifications
{
    public interface ISpecifictations<T> where T : BaseEntity
    {
        public Expression<Func<T , bool>>? Criteria { get; set; }  //p => p
        public  List<Expression<Func<T , object>>> Include { get; set; }

        //Add Tow Prop Signture  For Sorting 
        public Expression<Func<T, object>> orderBy { get; set; }
        public Expression<Func<T, object>> orderByDes { get; set; }


        //Here i will add this properity(prop Signture) to handle pagination 
        public int Take { get; set; }
        public int Skipe { get; set; }
        public bool isPaginationEnable { get; set; }

    }
}
