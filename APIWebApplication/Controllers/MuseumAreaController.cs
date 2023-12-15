using APIWebApplication.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace APIWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MuseumAreaController : ControllerBase
    {
        private readonly MuseumAreaService _museumAreaService;
        public MuseumAreaController(MuseumAreaService museumAreaService)
        {
            _museumAreaService = museumAreaService;
        }
        /// <summary>
        /// Asynchronously retrieves all museum areas.
        /// </summary>
        /// <returns>An ActionResult containing all museum areas.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var museumAreas = await _museumAreaService.GetAllAsync();
            return Ok(museumAreas);
        }

        /// <summary>
        /// Asynchronously retrieves a specific museum area by its ID.
        /// </summary>
        /// <param name="id">The ID of the museum area to retrieve.</param>
        /// <returns>An ActionResult containing the requested museum area or NotFound if not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var museumAreas = await _museumAreaService.GetByIdAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);

        }

        /// <summary>
        /// Asynchronously creates a new museum area.
        /// </summary>
        /// <param name="model">The data for creating the museum area.</param>
        /// <returns>An ActionResult containing the created museum area.</returns>
        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromBody] CreateMuseumAreaRequest model)
        {
            var museumAreas = await _museumAreaService.CreatAsync(model);
            return Ok(museumAreas);
        }

        /// <summary>
        /// Asynchronously deletes a museum area by its ID.
        /// </summary>
        /// <param name="id">The ID of the museum area to delete.</param>
        /// <returns>An ActionResult indicating success or NotFound if the area does not exist.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeletAsync(int id)
        {
            var museumAreas = await _museumAreaService.DeletAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }

        /// <summary>
        /// Asynchronously updates an existing museum area.
        /// </summary>
        /// <param name="id">The ID of the museum area to update.</param>
        /// <param name="model">The updated data for the museum area.</param>
        /// <returns>An ActionResult containing the updated museum area or NotFound if not found.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateMuseumAreaRequest model)
        {
            var museumAreas = await _museumAreaService.UpdateAsync(id, model);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }

    }
}
