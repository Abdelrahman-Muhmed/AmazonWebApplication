using Amazon_Api.Dtos;

namespace Amazon_Api.Helpers
{
    public class Pagination<T>
    {
        
        public int PgaeSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    

        public Pagination(int pageSize, int pageIndex, IReadOnlyList<T> data , int count)
        {
            PgaeSize = pageSize;
            PageIndex = pageIndex;
            Data = data;
            Count = count;
        }
    }
}
