using APIWebApplication.DTO.Request;
using APIWebApplication.Services;
using Microsoft.AspNetCore.Mvc;


namespace APIWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningHourController : ControllerBase
    {
        private readonly OpeningHourService _openingHourService;
        public OpeningHourController(OpeningHourService openingHourService)
        {
            _openingHourService = openingHourService;
        }

        /// <summary>
        /// Asynchronously retrieves all opening hours.
        /// </summary>
        /// <returns>An ActionResult containing all opening hours.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var openingHours = await _openingHourService.GetAllAsync();
            return Ok(openingHours);
        }

        /// <summary>
        /// Asynchronously retrieves a specific opening hour entry by its ID.
        /// </summary>
        /// <param name="id">The ID of the opening hour entry to retrieve.</param>
        /// <returns>An ActionResult containing the requested opening hour entry or NotFound if not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var museumAreas = await _openingHourService.GetByIdAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);

        }

        /// <summary>
        /// Asynchronously creates a new opening hour entry.
        /// </summary>
        /// <param name="model">The data for creating the opening hour entry.</param>
        /// <returns>An ActionResult containing the created opening hour entry.</returns>
        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromBody] CreateOpeningHourRequest model)
        {
            var museumAreas = await _openingHourService.CreatAsync(model);
            return Ok(museumAreas);
        }

        /// <summary>
        /// Asynchronously deletes an opening hour entry by its ID.
        /// </summary>
        /// <param name="id">The ID of the opening hour entry to delete.</param>
        /// <returns>An ActionResult indicating success or NotFound if the entry does not exist.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeletAsync(int id)
        {
            var museumAreas = await _openingHourService.DeletAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }

        /// <summary>
        /// Asynchronously updates an existing opening hour entry.
        /// </summary>
        /// <param name="id">The ID of the opening hour entry to update.</param>
        /// <param name="model">The updated data for the opening hour entry.</param>
        /// <returns>An ActionResult containing the updated opening hour entry or NotFound if not found.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateOpeningHourRequest model)
        {
            var museumAreas = await _openingHourService.UpdateAsync(id, model);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }
    }
}
