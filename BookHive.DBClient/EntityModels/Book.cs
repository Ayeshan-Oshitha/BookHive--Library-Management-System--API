using System.ComponentModel.DataAnnotations;

namespace BookHive.DBClient.EntityModels
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }  
        public string Description { get; set; }
        public string? ISBN { get; set; }
        public int StockQuantity { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }      
        public decimal Price { get; set; }
        public string CoverImageUrl { get; set; }
        public string? InteriorUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
