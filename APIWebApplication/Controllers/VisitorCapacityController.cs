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
    }
}
