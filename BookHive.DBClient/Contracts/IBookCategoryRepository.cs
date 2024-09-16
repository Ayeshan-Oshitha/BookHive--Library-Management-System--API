using BookHive.DBClient.EntityModels;

namespace BookHive.DBClient.Contracts
{
    public interface IBookCategoryRepository
    {
        IQueryable<BookCategory> GetAllBookCategoriesByAdmin();
    }
}
