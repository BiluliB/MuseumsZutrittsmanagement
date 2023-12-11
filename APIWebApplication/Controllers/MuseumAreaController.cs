using Microsoft.AspNetCore.Mvc;

namespace APIWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MuseumAreaController : ControllerBase
    {
        private readonly MuseumAreaService _museumAreaService;
        public MuseumAreaController(MuseumAreaService museumAreaService)
        {
            _museumAreaService = museumAreaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMuseumAreas()
        {
            var museumAreas = await _museumAreaService.GetAllMuseumAreasAsync();
            return Ok(museumAreas);
        }

    }
}
