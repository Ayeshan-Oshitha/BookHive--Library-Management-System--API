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

        public async Task<BookCategory> UpdateBookCateogary(int id, BookCategory bookCategoryModel)
        {
           var existingBookCateogary = await _dbContext.BookCategories.FirstOrDefaultAsync( x => x.CateogaryId == id); 
            if (existingBookCateogary == null)
            {
                return null;
            }
            existingBookCateogary.Name = bookCategoryModel.Name;
            existingBookCateogary.Description = bookCategoryModel.Description;
            await _dbContext.SaveChangesAsync();
            return existingBookCateogary;
        }

        public async Task<BookCategory> DeleteBookCateogary(int id)
        {
            var bookCateogary = await _dbContext.BookCategories.FirstOrDefaultAsync( x => x.CateogaryId == id);
            if(bookCateogary == null)
            {
                return null;
            }
            _dbContext.BookCategories.Remove(bookCateogary);
            await _dbContext.SaveChangesAsync();
            return bookCateogary;
        }
    }
}
