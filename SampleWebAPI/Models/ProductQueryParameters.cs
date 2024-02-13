namespace SampleWebAPI.Models
{
    public class ProductQueryParameters : QueryParameters
    {
        //Filtering
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }

        //Searching
        public string Name { get; set; } = string.Empty;
        public string sku { get; set; } = string.Empty;

        public string SearchTerm { get; set; } = string.Empty;
    }
}
