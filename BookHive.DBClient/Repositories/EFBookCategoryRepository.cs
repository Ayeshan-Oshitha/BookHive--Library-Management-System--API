using BookHive.DBClient.Contracts;
using BookHive.DBClient.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BookHive.DBClient.Repositories
{
    public class EFBookCateogaryRepository : IBookCategoryRepository
    {
        public EFDbContext _dbContext;
        public EFBookCateogaryRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<BookCategory> GetAllBookCategories()
        {
            return _dbContext.BookCategories;
        }

        public async Task<BookCategory> GetBookCateogaryById(int id)
        {
            var bookCateogary = await _dbContext.BookCategories.FirstOrDefaultAsync( x => x.CateogaryId == id);
            if(bookCateogary == null)
            {
                return null;
            }
            return bookCateogary;
        }

        public async Task<BookCategory> CreateBookCateogary(BookCategory bookCategoryModel)
        {
            await _dbContext.BookCategories.AddAsync(bookCategoryModel);
            await _dbContext.SaveChangesAsync();
            return bookCategoryModel;
        }

        
    }
}
