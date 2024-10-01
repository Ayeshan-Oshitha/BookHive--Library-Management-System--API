using BookHive.DBClient.DTOs.BookCateogary;
using BookHive.DBClient.EntityModels;


namespace BookHive.DBClient.Mappers
{
    public static class BookCategoryMapper
    {
        public static BookCategoryDto  ToBookCateogaryDto(this BookCategory bookCategoryModel)
        {
            return new BookCategoryDto
            {
                CateogaryId = bookCategoryModel.CateogaryId,
                Name = bookCategoryModel.Name,
                Description = bookCategoryModel.Description,
            };
        }

        public static BookCategory ToBookCateogaryFromCreateDto(this CreateBookCategoryRequestDto bookCategoryDto)
        {
            return new BookCategory
            {
                Name = bookCategoryDto.Name,
                Description = bookCategoryDto.Description,
            };
        }
    }
}
