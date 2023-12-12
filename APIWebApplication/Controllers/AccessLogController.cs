using APIWebApplication.DTO.Request;
using APIWebApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessLogController : ControllerBase
    {
        private readonly AccessLogService _accessLogService;

        public AccessLogController(AccessLogService accessLogService)
        {
            _accessLogService = accessLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var accessLog = await _accessLogService.GetAllAsync();
            return Ok(accessLog);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var museumAreas = await _accessLogService.GetByIdAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);

        }

        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromBody] CreateAccessLogRequest model)
        {
            var museumAreas = await _accessLogService.CreatAsync(model);
            return Ok(museumAreas);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletAsync(int id)
        {
            var museumAreas = await _accessLogService.DeletAsync(id);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync( int id, [FromBody] UpdateAccessLogRequest model)
        {
            var museumAreas = await _accessLogService.UpdateAsync(id, model);

            return museumAreas == null ? NotFound() : Ok(museumAreas);
        }
    }
}
