using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIWebApplication.DTO.Response;
using APIWebApplication.Services;


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
    }
}
