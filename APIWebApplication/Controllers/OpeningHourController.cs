using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIWebApplication.DTO.Response;
using APIWebApplication.Services;
using APIWebApplication.DTO.Request;


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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var openingHours = await _openingHourService.GetAllAsync();
            return Ok(openingHours);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var museumAreas = await _openingHourService.GetByIdAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);

        }

        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromBody] CreateOpeningHourRequest model)
        {
            var museumAreas = await _openingHourService.CreatAsync(model);
            return Ok(museumAreas);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletAsync(int id)
        {
            var museumAreas = await _openingHourService.DeletAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateOpeningHourRequest model)
        {
            var museumAreas = await _openingHourService.UpdateAsync(id, model);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }
    }
}
