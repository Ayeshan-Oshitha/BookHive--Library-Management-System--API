using BookHive.DBClient.Contracts;
using BookHive.DBClient.DTOs.BookCateogary;
using BookHive.DBClient.EntityModels;
using BookHive.DBClient.Mappers;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BookHive.API.Controllers
{
    [Route("api/BookCategory")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;
        private static ILog _logger;

        public BookCategoryController(IBookCategoryRepository bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }


        [Route("GetAllBookCategories")]
        [HttpGet]
        public async Task<IActionResult> GetAllBookCategoriesByAdmin()
        {
            try
            {
                var bookCategories = _bookCategoryRepository.GetAllBookCategories();
                if (bookCategories == null)
                {
                    return NoContent();
                }
                var bookCategaryDto = bookCategories.Select(s => s.ToBookCateogaryDto()).ToList();
                return Ok(bookCategaryDto);
            }
            catch (Exception ex)
            {
                _logger.Error($"An error occurred in: {nameof(GetAllBookCategoriesByAdmin)} , exception: {ex.Message}.");
                return BadRequest();
            }
        }

        [Route("GetBookCategoryById/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetBookCategoryById([FromRoute] int id)
        {
            var bookCategory = await _bookCategoryRepository.GetBookCateogaryById(id);
            if (bookCategory == null)
            {
                return NoContent();
            }
            return Ok(bookCategory.ToBookCateogaryDto());
        }


        [Route("CreateBookCateogary")]
        [HttpPost]
        public async Task<IActionResult> CreateBookCateogary([FromBody] CreateBookCategoryRequestDto bookCateogaryDto)
        {
            var bookCategoryModel = bookCateogaryDto.ToBookCateogaryFromCreateDto();
            await _bookCategoryRepository.CreateBookCateogary(bookCategoryModel);
            return CreatedAtAction( nameof(GetBookCategoryById), new { id = bookCategoryModel.CateogaryId  }, bookCategoryModel.ToBookCateogaryDto());
        }

    }
}


