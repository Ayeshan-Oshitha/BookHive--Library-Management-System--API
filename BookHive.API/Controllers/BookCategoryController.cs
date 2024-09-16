using BookHive.DBClient.Contracts;
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


        [Route("GetAllBookCategoriesByAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAllBookCategoriesByAdmin()
        {
            try
            {
                var bookCategories = _bookCategoryRepository.GetAllBookCategoriesByAdmin();
                if (bookCategories == null)
                {
                    return NoContent();
                }
                return Ok(bookCategories);
            }
            catch (Exception ex)
            {
                _logger.Error($"An error occurred in: {nameof(GetAllBookCategoriesByAdmin)} , exception: {ex.Message}.");
                return BadRequest();
            }


        }
    }
}
