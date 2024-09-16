using BookHive.DBClient.EntityModels;

namespace BookHive.DBClient.Contracts
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooksByAdmin();
    }
}
