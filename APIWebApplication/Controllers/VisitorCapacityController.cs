using APIWebApplication.DTO.Request;
using APIWebApplication.Services;
using Microsoft.AspNetCore.Mvc;


namespace APIWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorCapacityController : ControllerBase
    {
        private readonly VisitorCapacityService _visitorCapacityService;

        public VisitorCapacityController(VisitorCapacityService visitorCapacityService)
        {
            _visitorCapacityService = visitorCapacityService;
        }

        /// <summary>
        /// Asynchronously retrieves all visitor capacity entries.
        /// </summary>
        /// <returns>An ActionResult containing all visitor capacity entries.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var museumAreas = await _visitorCapacityService.GetAllAsync();
            return Ok(museumAreas);
        }

        /// <summary>
        /// Asynchronously retrieves a specific visitor capacity entry by its ID.
        /// </summary>
        /// <param name="id">The ID of the visitor capacity entry to retrieve.</param>
        /// <returns>An ActionResult containing the requested visitor capacity entry or NotFound if not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var museumAreas = await _visitorCapacityService.GetByIdAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);

        }

        /// <summary>
        /// Asynchronously creates a new visitor capacity entry.
        /// </summary>
        /// <param name="model">The data for creating the visitor capacity entry.</param>
        /// <returns>An ActionResult containing the created visitor capacity entry.</returns>
        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromBody] CreateVisitorCapacityRequest model)
        {
            var museumAreas = await _visitorCapacityService.CreatAsync(model);
            return Ok(museumAreas);
        }

        /// <summary>
        /// Asynchronously deletes a visitor capacity entry by its ID.
        /// </summary>
        /// <param name="id">The ID of the visitor capacity entry to delete.</param>
        /// <returns>An ActionResult indicating success or NotFound if the entry does not exist.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeletAsync(int id)
        {
            var museumAreas = await _visitorCapacityService.DeletAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }

        /// <summary>
        /// Asynchronously updates an existing visitor capacity entry.
        /// </summary>
        /// <param name="id">The ID of the visitor capacity entry to update.</param>
        /// <param name="model">The updated data for the visitor capacity entry.</param>
        /// <returns>An ActionResult containing the updated visitor capacity entry or NotFound if not found.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateVisitorCapacityRequest model)
        {
            var museumAreas = await _visitorCapacityService.UpdateAsync(id, model);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }
    }
}
