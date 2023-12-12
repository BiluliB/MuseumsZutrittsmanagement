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
    }
}
