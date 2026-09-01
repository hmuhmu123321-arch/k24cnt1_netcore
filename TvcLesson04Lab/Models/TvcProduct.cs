namespace TvcLesson04Lab.Models
{
    public class TvcProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string Category { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        public string Platform { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public bool IsHot { get; set; }
        public bool IsNew { get; set; }
    }
}