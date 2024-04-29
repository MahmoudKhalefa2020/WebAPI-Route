namespace Talabat.APIs.Helpers
{
    public class Pagination<T>
    {
        public int PageSize { get; set; }
        public int PageIndeex { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }

        public Pagination(int pageSize, int pageIndex, int count, IReadOnlyList<T> data)
        {
            PageSize = pageSize;
            PageIndeex = pageIndex;
            Count = count;
            Data = data;
        }

    }
}
