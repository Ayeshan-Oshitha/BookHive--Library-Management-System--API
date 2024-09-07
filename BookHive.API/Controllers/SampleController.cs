using BookHive.DBClient.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using log4net;
using System.Reflection;


namespace BookHive.API.Controllers
{
    [Route("api/sample")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleRepository _sampleRepository;
        private static ILog _logger;

        public SampleController(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        [Route("SampleData")]
        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            try
            {
                var sampleData = _sampleRepository.getSampleData();
                if (sampleData != null)
                {
                    return Ok(sampleData);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Error($"An error occurred in: {nameof(GetUser)} , exception: {ex.Message}.");
                return BadRequest();
            }
        }
    }
}
