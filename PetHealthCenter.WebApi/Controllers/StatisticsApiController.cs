using Microsoft.AspNetCore.Mvc;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.Statistics;

namespace PetHealthStuido.WebApi.Controllers
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService service;
        public StatisticsApiController(IStatisticsService _service)
        {
            service = _service;
        }

        /// <summary>
        /// Get statistics about count of parts and health services
        /// </summary>
        /// <returns>Total parts and total health services</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStatistics()
        {
            var model =  await service.Total();

            return Ok(model);
        }
    }
}
