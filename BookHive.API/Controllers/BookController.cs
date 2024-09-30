using BookHive.DBClient.Contracts;
using BookHive.DBClient.Mappers;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BookHive.API.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private static ILog _logger;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }


        [Route("GetAllBooksByAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAllBooksByAdmin()
        {
            try
            {
                var books = _bookRepository.GetAllBooksByAdmin();
                if (books == null)
                {
                    return NoContent();
                }
                var bookDto = books.Select(s => s.ToBookDtoAuthor()).ToList();
                return Ok(bookDto);
            }
            catch (Exception ex)
            {
                _logger.Error($"An error occurred in: {nameof(GetAllBooksByAdmin)} , exception: {ex.Message}.");
                return BadRequest();
            }  
        }
    }
}
