using APIWebApplication.DTO.Request;
using APIWebApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessLogController : ControllerBase
    {
        private readonly IAccessLogService _accessLogService;

        /// <summary>
        /// Initializes a new instance of the AccessLogController class with the specified access log service.
        /// </summary>
        /// <param name="accessLogService">The service for managing access logs.</param>
        public AccessLogController(IAccessLogService accessLogService)
        {
            _accessLogService = accessLogService;
        }

        /// <summary>
        /// Asynchronously retrieves all access logs.
        /// </summary>
        /// <returns>An ActionResult containing all access logs.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var accessLog = await _accessLogService.GetAllAsync();
            return Ok(accessLog);
        }

        /// <summary>
        /// Asynchronously retrieves a specific access log by its ID.
        /// </summary>
        /// <param name="id">The ID of the access log to retrieve.</param>
        /// <returns>An ActionResult containing the requested access log or NotFound if not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var museumAreas = await _accessLogService.GetByIdAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);

        }

        /// <summary>
        /// Asynchronously creates a new access log.
        /// </summary>
        /// <param name="model">The data for creating the access log.</param>
        /// <returns>An ActionResult containing the created access log.</returns>
        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromBody] CreateAccessLogRequest model)
        {
            var museumAreas = await _accessLogService.CreatAsync(model);
            return Ok(museumAreas);
        }

        /// <summary>
        /// Asynchronously deletes an access log by its ID.
        /// </summary>
        /// <param name="id">The ID of the access log to delete.</param>
        /// <returns>An ActionResult indicating success or NotFound if the log does not exist.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeletAsync(int id)
        {
            var museumAreas = await _accessLogService.DeletAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }

        /// <summary>
        /// Asynchronously updates an existing access log.
        /// </summary>
        /// <param name="id">The ID of the access log to update.</param>
        /// <param name="model">The updated data for the access log.</param>
        /// <returns>An ActionResult containing the updated access log or NotFound if not found.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync( int id, [FromBody] UpdateAccessLogRequest model)
        {
            var museumAreas = await _accessLogService.UpdateAsync(id, model);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }
    }
}
