using System.Collections.Generic;

namespace Infrastructure.Helpers
{
    public class TastyResponseWrapper<T>
    {
        public Dictionary<string, string> Headers { get; set; }
        public TastyPagination Pagination { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public List<T> Data { get; set; }

        public TastyResponseWrapper()
        {
            Headers = new Dictionary<string, string>();
            Data = new List<T>();
        }

        public TastyResponseWrapper(List<T> data, string sortBy, string sortOrder)
        {
            Headers = new Dictionary<string, string>();
            Data = new List<T>();
            Data = data;
            SortBy = sortBy;
            SortOrder = sortOrder;
        }
    }
}