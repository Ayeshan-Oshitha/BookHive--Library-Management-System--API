﻿using BookHive.DBClient.EntityModels;

namespace BookHive.DBClient.Contracts
{
    public interface IBookCategoryRepository
    {
        IQueryable<BookCategory> GetAllBookCategories();
        Task<BookCategory> GetBookCateogaryById(int id);
        Task<BookCategory> CreateBookCateogary(BookCategory bookCategoryModel);
        Task<BookCategory> UpdateBookCateogary(int id, BookCategory bookCategoryModel);
        Task<BookCategory> DeleteBookCateogary(int id);
    }
}
