using BookHive.DBClient.Contracts;
using BookHive.DBClient.EntityModels;

namespace BookHive.DBClient.Repositories
{
    public class EFBookCateogaryRepository : IBookCategoryRepository
    {
        public EFDbContext _dbContext;
        public EFBookCateogaryRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<BookCategory> GetAllBookCategoriesByAdmin()
        {
            return _dbContext.BookCategories;
        }
    }
}
