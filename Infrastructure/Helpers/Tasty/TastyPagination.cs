namespace Infrastructure.Helpers
{
    public class TastyPagination
    {
        public TastyPagination(int count, int totalCount, int page, int pages)
        {
            Count = count;
            Page = page;
            Pages = pages;
            TotalCount = totalCount;
        }
        public int Count { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
        public int TotalCount { get; set; }
    }
}