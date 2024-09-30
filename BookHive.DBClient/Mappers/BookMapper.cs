using BookHive.DBClient.DTOs.Book;
using BookHive.DBClient.EntityModels;

namespace BookHive.DBClient.Mappers
{
    public static class BookMapper
    {
        public static BookDtoAuthor ToBookDtoAuthor (this Book BookModel)
        {
            return new BookDtoAuthor
            {
                BookId = BookModel.BookId,
                Title = BookModel.Title,
                Description = BookModel.Description,
                ISBN = BookModel.ISBN,
                StockQuantity = BookModel.StockQuantity,
                AuthorId = BookModel.AuthorId,
                CategoryId = BookModel.CategoryId,
                Price = BookModel.Price,
                CoverImageUrl = BookModel.CoverImageUrl,
                InteriorUrl = BookModel.InteriorUrl
            };
        }
    }
}
