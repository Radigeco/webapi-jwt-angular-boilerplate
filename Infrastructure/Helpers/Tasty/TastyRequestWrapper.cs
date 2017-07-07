using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Helpers
{
    public class TastyRequestWrapper
    {
        [Required]
        public int Page { get; set; }
        [Required]
        public int PageSize { get; set; }

        public string SortBy { get; set; }

        public string SortOrder { get; set; }

        public TastyRequestWrapper()
        {
            Page = -1;

        }
    }
}