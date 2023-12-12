using APIWebApplication.DTO.Request;
using APIWebApplication.Models;
using APIWebApplication.Services;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var museumAreas = await _visitorCapacityService.GetAllAsync();
            return Ok(museumAreas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var museumAreas = await _visitorCapacityService.GetByIdAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);

        }

        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromBody] CreateVisitorCapacityRequest model)
        {
            var museumAreas = await _visitorCapacityService.CreatAsync(model);
            return Ok(museumAreas);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletAsync(int id)
        {
            var museumAreas = await _visitorCapacityService.DeletAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateVisitorCapacityRequest model)
        {
            var museumAreas = await _visitorCapacityService.UpdateAsync(id, model);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }
    }
}
