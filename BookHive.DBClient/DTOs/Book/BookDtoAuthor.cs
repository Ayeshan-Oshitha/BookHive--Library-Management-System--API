namespace BookHive.DBClient.DTOs.Book
{
    public class BookDtoAuthor
    {
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
    }
}
