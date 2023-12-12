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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var museumAreas = await _museumAreaService.GetAllAsync();
            return Ok(museumAreas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var museumAreas = await _museumAreaService.GetByIdAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);

        }

        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromBody] CreateMuseumAreaRequest model)
        {
            var museumAreas = await _museumAreaService.CreatAsync(model);
            return Ok(museumAreas);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletAsync(int id)
        {
            var museumAreas = await _museumAreaService.DeletAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateMuseumAreaRequest model)
        {
            var museumAreas = await _museumAreaService.UpdateAsync(id, model);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }

    }
}
