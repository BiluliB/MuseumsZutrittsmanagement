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

    }
}
