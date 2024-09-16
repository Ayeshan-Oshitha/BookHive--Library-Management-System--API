using BookHive.DBClient.Contracts;
using BookHive.DBClient.EntityModels;

namespace BookHive.DBClient.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        public EFDbContext _DbContext { get; set; }

        public EFBookRepository(EFDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public IQueryable<Book> GetAllBooksByAdmin()
        {
            var books = _DbContext.Books;
            return books;
        }
    }
}
